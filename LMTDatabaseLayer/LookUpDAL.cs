using CrystalDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMTDatabaseLayer
{
    public class LookUpDAL
    {
        DbSqlParameterCollection objParamCollection;

        public DataTable GetStateList()
        {
            objParamCollection = new DbSqlParameterCollection();

            DbSqlParameter LookupCodePara = new DbSqlParameter("@LookupCode", SqlDbType.VarChar);
            LookupCodePara.Value = "STATE";
            objParamCollection.Add(LookupCodePara);

            return (CrystalConnection.DoStoredTable("usp_GetLookup", objParamCollection));
        }

        public DataTable GetCityListbyStateID(int StateId)
        {
            objParamCollection = new DbSqlParameterCollection();

            DbSqlParameter StateIDPara = new DbSqlParameter("@StateID", SqlDbType.Int);
            StateIDPara.Value = StateId;
            objParamCollection.Add(StateIDPara);

            return (CrystalConnection.DoStoredTable("GetCity_by_StateID", objParamCollection));
        }

        public DataTable GetSectorType()
        {
            objParamCollection = new DbSqlParameterCollection();

            return (CrystalConnection.DoStoredTable("GetSectorType", objParamCollection));
        }

        public DataTable GetLabourTypebyID(int SectorID)
        {
            objParamCollection = new DbSqlParameterCollection();

            DbSqlParameter SectorIDPara = new DbSqlParameter("@SectorId", SqlDbType.Int);
            SectorIDPara.Value = SectorID;
            objParamCollection.Add(SectorIDPara);

            return (CrystalConnection.DoStoredTable("GetLabourTypebySectorId", objParamCollection));
        }
    }
}
