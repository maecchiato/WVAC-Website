using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WvacWebServerProj
{
   
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string CreateUser(string firstName, string lastName, string address, string civilStatus,
                                string age, string gender, string contactNo, string emailAdd);
    }
}
