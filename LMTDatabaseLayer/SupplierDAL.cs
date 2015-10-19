using CrystalDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMTDatabaseLayer
{
    public class SupplierDAL
    {
        DbSqlParameterCollection objParamCollection;
        //define variables..

        private string _opmode { get; set; }
        private int _supplierid { get; set; }
        private string _suppliercode { get; set; }
        private string _fullname { get; set; }
        private string _address { get; set; }
        private int _supcity { get; set; }
        private int _supstate { get; set; }
        private decimal _suppincode { get; set; }
        private decimal _supmobile { get; set; }
        private string _emailid { get; set; }
        private string _companyname { get; set; }
        private string _bankname { get; set; }
        private string _bankacno { get; set; }
        private string _acifsccode { get; set; }
        private string _dock1url { get; set; }
        private string _dock2url { get; set; }
        private string _imageurl { get; set; }
        private string _membership { get; set; }

        private void AddProcParam()
        {
            objParamCollection = new DbSqlParameterCollection();

            DbSqlParameter OpModePara = new DbSqlParameter("@OpMode", SqlDbType.VarChar);
            OpModePara.Value = _opmode;
            objParamCollection.Add(OpModePara);

            DbSqlParameter Supplier_IDPara = new DbSqlParameter("@Supplier_ID", SqlDbType.Int);
            Supplier_IDPara.Value = _supplierid;
            objParamCollection.Add(Supplier_IDPara);

            DbSqlParameter SupplierCodePara = new DbSqlParameter("@Supplier_Code", SqlDbType.VarChar);
            SupplierCodePara.Value = _suppliercode;
            objParamCollection.Add(SupplierCodePara);

            DbSqlParameter FullNamePara = new DbSqlParameter("@FullName", SqlDbType.VarChar);
            FullNamePara.Value = _fullname;
            objParamCollection.Add(FullNamePara);

            DbSqlParameter AddressPara = new DbSqlParameter("@Address", SqlDbType.VarChar);
            AddressPara.Value = _address;
            objParamCollection.Add(AddressPara);

            DbSqlParameter Sup_StatePara = new DbSqlParameter("@Sup_State", SqlDbType.Int);
            Sup_StatePara.Value = _supstate;
            objParamCollection.Add(Sup_StatePara);
            DbSqlParameter Sup_CityPara = new DbSqlParameter("@Sup_City", SqlDbType.Int);
            Sup_CityPara.Value = _supcity;
            objParamCollection.Add(Sup_CityPara);
            DbSqlParameter Sup_PincodePara = new DbSqlParameter("@Sup_Pincode", SqlDbType.Decimal);
            Sup_PincodePara.Value = _suppincode;
            objParamCollection.Add(Sup_PincodePara);
            DbSqlParameter Mobile_NoPara = new DbSqlParameter("@Sup_Mobile", SqlDbType.Decimal);
            Mobile_NoPara.Value = _supmobile;
            objParamCollection.Add(Mobile_NoPara);
            DbSqlParameter EmailIDPara = new DbSqlParameter("@EmailID", SqlDbType.VarChar);
            EmailIDPara.Value = _emailid;
            objParamCollection.Add(EmailIDPara);
            DbSqlParameter CompanyNamePara = new DbSqlParameter("@CompanyName", SqlDbType.VarChar);
            CompanyNamePara.Value = _companyname;
            objParamCollection.Add(CompanyNamePara);
            DbSqlParameter BankNamePara = new DbSqlParameter("@BankName", SqlDbType.VarChar);
            BankNamePara.Value = _bankname;
            objParamCollection.Add(BankNamePara);
            DbSqlParameter BankAcNoPara = new DbSqlParameter("@Bank_AC_No", SqlDbType.VarChar);
            BankAcNoPara.Value = _bankacno;
            objParamCollection.Add(BankAcNoPara);
            DbSqlParameter Ac_IFSC_CodePara = new DbSqlParameter("@AC_IFCS_Code", SqlDbType.VarChar);
            Ac_IFSC_CodePara.Value = _acifsccode;
            objParamCollection.Add(Ac_IFSC_CodePara);
            DbSqlParameter DocUrl1Para = new DbSqlParameter("@Doc1_Url", SqlDbType.VarChar);
            DocUrl1Para.Value = _dock1url;
            objParamCollection.Add(DocUrl1Para);
            DbSqlParameter DocUrl2Para = new DbSqlParameter("@Doc2_Url", SqlDbType.VarChar);
            DocUrl2Para.Value = _dock2url;
            objParamCollection.Add(DocUrl2Para);
            DbSqlParameter ImageUrlPara = new DbSqlParameter("@Image_Url", SqlDbType.VarChar);
            ImageUrlPara.Value = _imageurl;
            objParamCollection.Add(ImageUrlPara);
            DbSqlParameter MembershipPara = new DbSqlParameter("@Membership", SqlDbType.Char);
            MembershipPara.Value = _membership;
            objParamCollection.Add(MembershipPara);

        }

        public void SaveData(string OpMode)
        {
            _opmode = OpMode;
            AddProcParam();
            CrystalConnection.DoStored("usp_SupplierDtlProc", objParamCollection);
        }

        public void DeleteLabInfo(string opmode, int SupID)
        {
            _opmode = opmode;
            _supplierid = SupID;
            AddProcParam();
            CrystalConnection.DoStoredScalar("usp_SupplierDtlProc", objParamCollection, true);
        }

        public static DataTable FillDataTable(string query)
        {
            DataTable dtFillData;
            dtFillData = CrystalConnection.CreateDataTableWithoutTransaction(query);
            return dtFillData;
        }

        //Added by khushbu to fill dataset
        public DataTable GetLaboursList()
        {
             objParamCollection = new DbSqlParameterCollection();

            return (CrystalConnection.DoStoredTable("usp_Get_All_Labours_List", objParamCollection));
        }
    }
}
