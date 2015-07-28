using ServiceDataContract;
using System.Data;


namespace DataAccessLayer
{
    public class DALUserInfo
    {
        DbSqlParameterCollection objParamCollection;
        public void AddProcParam_Getuserinfo(userinfo userinfo)
        {
            objParamCollection = new DbSqlParameterCollection();
            DbSqlParameter _opModepara = new DbSqlParameter("@opMode", SqlDbType.VarChar, 25);
            _opModepara.Value = userinfo.fname;
            objParamCollection.Add(_opModepara);

            DbSqlParameter _visiteridp = new DbSqlParameter("@VisitorID", SqlDbType.Decimal);
            _visiteridp.Value = userinfo.age;
            objParamCollection.Add(_visiteridp);
        }
    }
}
