using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LMTDataContract
{
    [DataContract]
    public class FileUpload
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public bool Status { get; set; }

        [DataMember]
        public string FileUrl { get; set; }

        [DataMember]
        public string FileExtension { get; set; }

        [DataMember]
        public string ApplicationUrl { get; set; }


    }
    public class FileUploadFields
    {
        public string emailAddress { get; set; }
        public string fileName { get; set; }
        public string bucketName { get; set; }
        public string userFolderName { get; set; }
        public string libraryName { get; set; }
        public string fileSize { get; set; }
        public string fileExtension { get; set; }
        public string clientId { get; set; }
        public string caseId { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string contactId { get; set; }
        public string createdBy { get; set; }
        public string fileTypeId { get; set; }
        public string customerId { get; set; }
        public string networkId { get; set; }
        public Stream fileStream { get; set; }
    }
}
