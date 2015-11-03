using CrystalDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMTDataContract;


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

        private void AddProcPram_NewLabour(Labour labour)
        {
            objParamCollection = new DbSqlParameterCollection();

            DbSqlParameter _opModePara = new DbSqlParameter("@OpMode", SqlDbType.VarChar);
            _opModePara.Value = _opmode;
            objParamCollection.Add(_opModePara);

            DbSqlParameter Reg_IDPara = new DbSqlParameter("@Reg_ID", SqlDbType.Int);
            Reg_IDPara.Value = labour.LabourID;
            objParamCollection.Add(Reg_IDPara);

            DbSqlParameter LabourCodePara = new DbSqlParameter("@Labour_Code", SqlDbType.VarChar);
            LabourCodePara.Value = labour.LabourCode; ;
            objParamCollection.Add(LabourCodePara);

            DbSqlParameter FullNamePara = new DbSqlParameter("@FullName", SqlDbType.VarChar);
            FullNamePara.Value = labour.FullName;
            objParamCollection.Add(FullNamePara);

            DbSqlParameter FatherNamePara = new DbSqlParameter("@FatherName", SqlDbType.VarChar);
            FatherNamePara.Value = labour.FatherName;
            objParamCollection.Add(FatherNamePara);
            DbSqlParameter C_AddressPara = new DbSqlParameter("@C_Address", SqlDbType.VarChar);
            C_AddressPara.Value = labour.CurrentAddress;
            objParamCollection.Add(C_AddressPara);
            DbSqlParameter C_StatePara = new DbSqlParameter("@C_State", SqlDbType.Int);
            C_StatePara.Value = labour.CurrentStateID;
            objParamCollection.Add(C_StatePara);
            DbSqlParameter C_CityPara = new DbSqlParameter("@C_City", SqlDbType.Int);
            C_CityPara.Value = labour.CurrentCityID;
            objParamCollection.Add(C_CityPara);
            DbSqlParameter C_PincodePara = new DbSqlParameter("@C_Pincode", SqlDbType.Decimal);
            C_PincodePara.Value = labour.CurrentPincode;
            objParamCollection.Add(C_PincodePara);
            DbSqlParameter P_AddressPara = new DbSqlParameter("@P_Address", SqlDbType.VarChar);
            P_AddressPara.Value = labour.PermanentAddress;
            objParamCollection.Add(P_AddressPara);
            DbSqlParameter P_StatePara = new DbSqlParameter("@P_State", SqlDbType.Int);
            P_StatePara.Value = labour.PermanentStateID;
            objParamCollection.Add(P_StatePara);
            DbSqlParameter P_CityPara = new DbSqlParameter("@P_City", SqlDbType.Int);
            P_CityPara.Value = labour.PermanentCityID;
            objParamCollection.Add(P_CityPara);
            DbSqlParameter P_PincodePara = new DbSqlParameter("@P_Pincode", SqlDbType.Decimal);
            P_PincodePara.Value = labour.PermanentPincode;
            objParamCollection.Add(P_PincodePara);
            DbSqlParameter Ph_NoPara = new DbSqlParameter("@Ph_No", SqlDbType.Decimal);
            Ph_NoPara.Value = labour.PhoneNo;
            objParamCollection.Add(Ph_NoPara);
            DbSqlParameter SectorTypePara = new DbSqlParameter("@SectorType", SqlDbType.Decimal);
            SectorTypePara.Value = labour.SectorType;
            objParamCollection.Add(SectorTypePara);
            DbSqlParameter Work_SpecializationPara = new DbSqlParameter("@Work_Specialization", SqlDbType.VarChar);
            Work_SpecializationPara.Value = labour.Specialization;
            objParamCollection.Add(Work_SpecializationPara);
            DbSqlParameter ExperiencePara = new DbSqlParameter("@Experience", SqlDbType.VarChar);
            ExperiencePara.Value = labour.Experience;
            objParamCollection.Add(ExperiencePara);
            DbSqlParameter LabourTypePara = new DbSqlParameter("@LabourType", SqlDbType.Int);
            LabourTypePara.Value = labour.LabourType;
            objParamCollection.Add(LabourTypePara);
            DbSqlParameter Ph_Belonging1Para = new DbSqlParameter("@Ph_belonging1", SqlDbType.Decimal);
            Ph_Belonging1Para.Value = labour.Belonging1;
            objParamCollection.Add(Ph_Belonging1Para);
            DbSqlParameter Ph_Belonging2Para = new DbSqlParameter("@Ph_belonging2", SqlDbType.Decimal);
            Ph_Belonging2Para.Value = labour.Belonging2;
            objParamCollection.Add(Ph_Belonging2Para);
            DbSqlParameter Ph_Belonging3Para = new DbSqlParameter("@Ph_belonging3", SqlDbType.Decimal);
            Ph_Belonging3Para.Value = labour.Belonging3;
            objParamCollection.Add(Ph_Belonging3Para);
            DbSqlParameter Ph_Belonging4Para = new DbSqlParameter("@Ph_belonging4", SqlDbType.Decimal);
            Ph_Belonging4Para.Value = labour.Belonging4;
            objParamCollection.Add(Ph_Belonging4Para);
            DbSqlParameter Experience_TypePara = new DbSqlParameter("@Experience_Type", SqlDbType.Int);
            Experience_TypePara.Value = "1";//Passing the default value as per the last value in the Database.
            objParamCollection.Add(Experience_TypePara);
            DbSqlParameter VarificationPara = new DbSqlParameter("@Verification", SqlDbType.Char);
            VarificationPara.Value = labour.Verification == true ? "1" : "0";//as per the demand of the time I can't change the database col type from char to bool as it has depandency in web portal also.
            objParamCollection.Add(VarificationPara);
            DbSqlParameter ImageUrlPara = new DbSqlParameter("@Image_Url", SqlDbType.VarChar);
            ImageUrlPara.Value = labour.Image_URL;
            objParamCollection.Add(ImageUrlPara);
            DbSqlParameter DocUrl1Para = new DbSqlParameter("@Doc1_Url", SqlDbType.VarChar);
            DocUrl1Para.Value = labour.Doc1_URL;
            objParamCollection.Add(DocUrl1Para);
            DbSqlParameter DocUrl2Para = new DbSqlParameter("@Doc2_Url", SqlDbType.VarChar);
            DocUrl2Para.Value = labour.Doc2_URL;
            objParamCollection.Add(DocUrl2Para);
            DbSqlParameter DocUrl3Para = new DbSqlParameter("@Doc3_Url", SqlDbType.VarChar);
            DocUrl3Para.Value = labour.Doc3_URL;
            objParamCollection.Add(DocUrl3Para);
            DbSqlParameter DocUrl4Para = new DbSqlParameter("@Doc4_Url", SqlDbType.VarChar);
            DocUrl4Para.Value = labour.Doc4_URL;
            objParamCollection.Add(DocUrl4Para);
            DbSqlParameter SupplierIDPara = new DbSqlParameter("@SupplierID", SqlDbType.Int);
            SupplierIDPara.Value = labour.SupplierID;
            objParamCollection.Add(SupplierIDPara);
            DbSqlParameter WagesPara = new DbSqlParameter("@Wages", SqlDbType.VarChar);
            WagesPara.Value = labour.Wages;
            objParamCollection.Add(WagesPara);
            DbSqlParameter Lbr_SkillPara = new DbSqlParameter("@Lbr_Skill", SqlDbType.Int);
            Lbr_SkillPara.Value = labour.Lbr_Skill;
            objParamCollection.Add(Lbr_SkillPara);

        }

        public void InsertNewLabourData(string OpMode, Labour labour)
        {
            _opmode = OpMode;// OpMode stands for opration Mode
            AddProcPram_NewLabour(labour);
            CrystalConnection.DoStored("usp_LabourRegProc", objParamCollection);
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
