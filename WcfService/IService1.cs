using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InsertUser(UserDetails user);

        [OperationContract]
        string UpdateUser(UserDetails user);

        [OperationContract]
        string DeleteUser(UserDetails user);

        [OperationContract]
        List<UserDetails> GetListData(UserDetails user);
    }

    [DataContract]
    public class UserDetails
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
