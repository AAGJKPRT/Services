using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DataAccessLayer
{
    public class StaticFunctions
    {
        public static bool IsBlank(string value)
        {
            return value == null || value.Length == 0;
        }
    }
    public class DatabaseSettings
    {
        private static string connection = null;
        private static string maxResults = null;

        public static string Connection
        {
            get
            {
                if (connection == null)
                    connection = ConfigurationManager.AppSettings["DatabaseConnectionString"] as string;
                return connection;
            }
        }

        public static string MaxResults
        {
            get
            {
                if (maxResults == null)
                    maxResults = ConfigurationManager.AppSettings["maxResult"] as string;
                return maxResults;
            }
        }
    }
    public class DatabaseConnection
    {
        public static bool needTransaction = false;
        private DatabaseConnection()
        {
        }

        private static SqlConnection currentConnection
        {
            get
            {
                object currentConnectionObj = HttpContext.Current.Items["currentConnection"];
                if (currentConnectionObj is SqlConnection)
                    return (SqlConnection)currentConnectionObj;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Items["currentConnection"] = value;
            }
        }

        private static SqlTransaction currentTransaction
        {
            get
            {
                object currentTransactionObj = HttpContext.Current.Items["currentTransaction"];
                if (currentTransactionObj is SqlTransaction)
                    return (SqlTransaction)currentTransactionObj;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Items["currentTransaction"] = value;
            }
        }

        public static SqlConnection GetNewConnection
        {
            get { return new SqlConnection(DatabaseSettings.Connection); }
        }

        public static SqlConnection GetConnection
        {
            get
            {
                if (currentConnection == null)
                {
                    currentConnection = GetNewConnection;
                }
                if (currentConnection.State != ConnectionState.Open)
                {
                    currentConnection.Open();
                    try
                    {
                        if (needTransaction)
                        {
                            if (HttpContext.Current.Application["noShapshot"] == null)
                            {
                                //currentTransaction = currentConnection.BeginTransaction(IsolationLevel.Snapshot);
                                currentTransaction = currentConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                            }
                            else
                            {
                                currentTransaction = currentConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                            }
                        }
                    }
                    catch
                    {
                        HttpContext.Current.Application["noShapshot"] = true;
                        currentTransaction = currentConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    }

                }

                return currentConnection;
            }
        }

        public static SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
        }

        public static bool IsTransaction
        {
            get
            {
                return (CurrentTransaction != null);
            }
        }

        public static void RollBackTransaction()
        {
            if (currentConnection == null)
                return;
            if (currentTransaction != null)
            {
                try
                {
                    currentTransaction.Rollback();
                }
                catch
                {
                    currentTransaction = null;
                    currentConnection.Close();
                    currentConnection = null;
                }
            }
            currentTransaction = null;
        }

        public static void CommitTransaction()
        {
            if (currentConnection == null)
                return;
            if (currentTransaction != null)
            {
                currentTransaction.Commit();
                currentTransaction = null;
            }

            if (currentConnection.State != ConnectionState.Open)
                currentConnection.Close();
        }

        private static string maxResult = null;

        public static string MaxResult
        {
            get
            {
                if (maxResult == null)
                {
                    maxResult = DatabaseSettings.MaxResults;
                    if (StaticFunctions.IsBlank(maxResult))
                        maxResult = "100";
                }
                return maxResult;
            }
        }

        public static void DoCommand(string sql, DbSqlParameterCollection sqlParams)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                if (currentTransaction != null)
                    cmd.Transaction = currentTransaction;
                foreach (DbSqlParameter p in sqlParams)
                {
                    cmd.Parameters.Add(p.Parameter);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }

        }

        //OverLoad of DoCommand Function WithOut Procedure Parameters
        public static void DoCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                if (currentTransaction != null)
                    cmd.Transaction = currentTransaction;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }
        }

        public static void DoCommandWithoutTransaction(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetNewConnection);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static void DoStored(string sqlStored, DbSqlParameterCollection sqlParams)
        {
            DoStored(sqlStored, sqlParams, IsTransaction);
        }

        public static void DoStored(string sqlStored, DbSqlParameterCollection sqlParams, bool transactional)
        {
            SqlCommand myCommand = new SqlCommand(sqlStored, (transactional) ? DatabaseConnection.GetConnection : DatabaseConnection.GetNewConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            foreach (DbSqlParameter p in sqlParams)
            {
                myCommand.Parameters.Add(p.Parameter);
            }
            if (myCommand.Connection.State != ConnectionState.Open)
                myCommand.Connection.Open();
            if (currentTransaction != null)
                myCommand.Transaction = currentTransaction;
            myCommand.ExecuteNonQuery();
            if (!IsTransaction)
                myCommand.Connection.Close();
        }

        public static object DoStoredScalar(string sqlStored, DbSqlParameterCollection sqlParams, bool transactional)
        {
            SqlCommand myCommand = new SqlCommand(sqlStored, (transactional) ? DatabaseConnection.GetConnection : DatabaseConnection.GetNewConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            foreach (DbSqlParameter p in sqlParams)
            {
                myCommand.Parameters.Add(p.Parameter);
            }
            if (myCommand.Connection.State != ConnectionState.Open)
                myCommand.Connection.Open();
            if (transactional)
            {
                if (currentTransaction != null)
                    myCommand.Transaction = currentTransaction;
            }
            else
            {
                object ret = myCommand.ExecuteScalar();
                myCommand.Connection.Close();
                return ret;
            }
            return myCommand.ExecuteScalar();
        }

        public static DataTable DoStoredTable(string sqlStored, DbSqlParameterCollection sqlParams)
        {
            bool isTransaction = IsTransaction;
            SqlCommand myCommand = new SqlCommand(sqlStored, (isTransaction) ? DatabaseConnection.GetConnection : DatabaseConnection.GetNewConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            foreach (DbSqlParameter p in sqlParams)
            {
                myCommand.Parameters.Add(p.Parameter);
            }
            if (myCommand.Connection.State != ConnectionState.Open)
                myCommand.Connection.Open();
            if (isTransaction)
                myCommand.Transaction = currentTransaction;

            SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        public static string SqlScalar(string sql)
        {
            string r = String.Empty;
            try
            {
                r = SqlScalartoObj(sql).ToString();
            }
            catch
            {
                r = String.Empty;
            }
            return r;
        }

        public static object SqlScalartoObj(string sql)
        {
            bool isTransaction = IsTransaction;
            SqlCommand cmd = new SqlCommand(sql, (isTransaction) ? GetConnection : GetNewConnection);

            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                if (isTransaction)
                    cmd.Transaction = currentTransaction;
                return cmd.ExecuteScalar();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (!isTransaction)
                    cmd.Connection.Close();
            }
        }

        //OverLoad of the SqlScalartoObj Function with Query Parameter
        public static object SqlScalartoObj(string sqlQuery, DbSqlParameterCollection sqlParams)
        {
            bool isTransaction = IsTransaction;
            SqlCommand myCommand = new SqlCommand(sqlQuery, (isTransaction) ? GetConnection : GetNewConnection);
            foreach (DbSqlParameter p in sqlParams)
            {
                myCommand.Parameters.Add(p.Parameter);
            }
            if (myCommand.Connection.State != ConnectionState.Open)
                myCommand.Connection.Open();
            if (isTransaction)
            {
                if (currentTransaction != null)
                    myCommand.Transaction = currentTransaction;
            }
            else
            {
                object ret = myCommand.ExecuteScalar();
                myCommand.Connection.Close();
                return ret;
            }
            return myCommand.ExecuteScalar();
        }

        public static DataSet CreateDataset(string sqlString)
        {
            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlString, (IsTransaction) ? GetConnection : GetNewConnection))
            {
                if (IsTransaction)
                    mySqlDataAdapter.SelectCommand.Transaction = currentTransaction;

                DataSet myDataSet = new DataSet();
                try
                {
                    mySqlDataAdapter.Fill(myDataSet);
                }
                catch (SqlException ex)
                {
                    throw new Exception(sqlString + ex.ToString());
                }
                return myDataSet;
            }
        }
        public static DataSet CreateDatasetWithoutTransaction(string sqlString)
        {
            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlString, GetNewConnection))
            {
                DataSet myDataSet = new DataSet();
                try
                {
                    mySqlDataAdapter.Fill(myDataSet);
                }
                catch (SqlException ex)
                {
                    throw new Exception(sqlString + ex.ToString());
                }

                return myDataSet;
            }
        }
        public static DataTable CreateDataTableWithoutTransaction(string sqlString)
        {
            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sqlString, GetNewConnection))
            {
                DataTable myDataTable = new DataTable();
                try
                {
                    mySqlDataAdapter.Fill(myDataTable);
                }
                catch (SqlException ex)
                {
                    throw new Exception(sqlString + ex.ToString());
                }

                return myDataTable;
            }
        }


        public static DataSet SecureCreateDataset(string sqlString, DbSqlParameter param)
        {
            DbSqlParameterCollection p = new DbSqlParameterCollection();
            p.Add(param);
            return SecureCreateDataset(sqlString, p);
        }

        public static DataSet SecureCreateDataset(string sqlString, DbSqlParameterCollection sqlParams)
        {
            DataSet Secure = new DataSet();
            SqlCommand cmd = (IsTransaction) ? GetConnection.CreateCommand() : GetNewConnection.CreateCommand();
            cmd.CommandText = sqlString;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(cmd);
            if (IsTransaction)
                SqlDataAdapter.SelectCommand.Transaction = currentTransaction;
            foreach (DbSqlParameter ss in sqlParams)
            {
                cmd.Parameters.Add(ss.Parameter);
            }
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                if (currentTransaction != null)
                    cmd.Transaction = currentTransaction;
                SqlDataAdapter.Fill(Secure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }
            return Secure;
        }

        public static SqlDataReader CreateReader(string sqlString)
        {
            SqlCommand myCmd = new SqlCommand(sqlString, (IsTransaction) ? GetConnection : GetNewConnection);
            SqlDataReader dr = null;
            if (myCmd.Connection.State != ConnectionState.Open)
                myCmd.Connection.Open();
            if (currentTransaction != null)
                myCmd.Transaction = currentTransaction;
            dr = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        //OverLoad of the CreateReader Function with Procedure Parameter
        public static SqlDataReader CreateReader(string sqlString, DbSqlParameterCollection sqlParams)
        {
            SqlCommand myCmd = new SqlCommand(sqlString, (IsTransaction) ? GetConnection : GetNewConnection);
            SqlDataReader dr = null;

            if (myCmd.Connection.State != ConnectionState.Open)
                myCmd.Connection.Open();
            if (currentTransaction != null)
                myCmd.Transaction = currentTransaction;

            foreach (DbSqlParameter par in sqlParams)
                myCmd.Parameters.Add(par.Parameter);
            dr = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static void AddToDataTable(ref DataTable t, string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, (IsTransaction) ? GetConnection : GetNewConnection);
            da.Fill(t);
        }

        public static bool SQLSecure(string s)
        {
            Regex Secure = new Regex("[^A-Za-z0-9_][@]");
            if (Secure.IsMatch(s))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static Regex FilterInjectionRegex;
        public static string FilterInjection(string s)
        {
            s = s.Replace("'", "''");
            if (FilterInjectionRegex == null)
                FilterInjectionRegex = new Regex(@"%3D|=|%27|%2D|--|%3B|;", RegexOptions.IgnoreCase);
            if (FilterInjectionRegex.IsMatch(s))
            {
                return "";
            }
            else
                return s;
        }
    }

    public class DbSqlParameterCollection : IEnumerable, IEnumerator
    {
        private int _index = -1;
        public ArrayList MySqlParameterArray = new ArrayList();

        public void Add(DbSqlParameter p)
        {
            MySqlParameterArray.Add(p);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this);
        }

        void IEnumerator.Reset()
        {
            this._index = -1;
        }

        object IEnumerator.Current
        {
            get { return (DbSqlParameter)MySqlParameterArray[this._index]; }
        }

        bool IEnumerator.MoveNext()
        {
            this._index++;
            try
            {
                return (this._index < MySqlParameterArray.Count);
            }
            catch
            {
                return (false);
            }
        }
    }

    public class DbSqlParameter
    {
        private SqlParameter parameter = new SqlParameter();

        public SqlParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }

        public DbSqlParameter(string parameterName, object value)
        {
            parameter.ParameterName = parameterName;
            parameter.Value = value;
        }

        public DbSqlParameter(string parameterName, SqlDbType dbType)
        {
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = dbType;
        }

        public DbSqlParameter(string parameterName, SqlDbType dbType, int size)
        {
            parameter.ParameterName = parameterName;
            parameter.Size = size;
            parameter.SqlDbType = dbType;
        }

        public DbSqlParameter(string parameterName, SqlDbType dbType, int size, object value)
        {
            parameter.ParameterName = parameterName;
            parameter.Size = size;
            parameter.Value = value;
            parameter.SqlDbType = dbType;
        }


        public object Value
        {
            get { return parameter.Value; }
            set { parameter.Value = value; }
        }
    }
}
