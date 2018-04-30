using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WVACWebServer.Models;

namespace WvacWebServerProj
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        wvacEntities wvac = new wvacEntities();

        //create user
        public string CreateUser(string firstName, string lastName, string address, string civilStatus,
                                string age, string gender, string contactNo, string emailAdd)
        {
            user user = new user();
            user.firstName = firstName;
            user.lastName = lastName;
            user.address = address;
            user.civilStatus = civilStatus;
            user.age = age;
            user.gender = gender;
            user.contactNo = contactNo;
            user.emailAdd = emailAdd;

            UserModel um = new UserModel();
            return um.InsertUser(user);
        }
    }
}
