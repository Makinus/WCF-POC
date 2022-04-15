using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DeparmentCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDepartmentService
    {
        [OperationContract]
        string InsertORUpdateDepartmentDetails(DeparmentDetails deparmentDetails);

        [OperationContract]
        List<DeparmentDetails> GetDepartments();

        [OperationContract]
        DeparmentDetails GetDepartmentByID(string departmentCode);

        [OperationContract]
        List<DeparmentDetails> GetDepartmentBySearch(string searchValue);
    }

    [DataContract]
    public class DeparmentDetails
    {
        int documentId;
        string documentCode = string.Empty;
        string documentName = string.Empty;
        int isActive;

        [DataMember]
        public int DepartmentId
        {
            get { return documentId; }
            set { documentId = value; }
        }
        [DataMember]
        public string DepartmentCode
        {
            get { return documentCode; }
            set { documentCode = value; }
        }
        [DataMember]
        public string DepartmentName
        {
            get { return documentName; }
            set { documentName = value; }
        }
        [DataMember]
        public int IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
