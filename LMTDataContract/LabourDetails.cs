using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LMTDataContract
{
    [DataContract]
    public class LabourDetails
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }

        [DataMember(Order = 0)]
        public bool Status { get; set; }

        [DataMember(Order = 2)]
        public int Count { get; set; }

        [DataMember(Order = 3)]
        public string ApplicationUrl { get; set; }

        [DataMember(Order = 4)]
        public List<Labour> Data;

        public LabourDetails()
        {
            Data = new List<Labour>();
        }

    }
    public class Labour
    {
        public int LabourID { get; set; }
        public string FullName { get; set; }
        public string LabourCode { get; set; }
        public int CurrentPincode { get; set; }
        public string SectorType { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string LabourType { get; set; }
        public bool Verification { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int Wages { get; set; }
        public string Lbr_Skill { get; set; }
        public string Image_URL { get; set; }
        public string Doc1_URL { get; set; }
        public string Doc2_URL { get; set; }
        public string Doc3_URL { get; set; }
        public string Doc4_URL { get; set; }
    }
}
