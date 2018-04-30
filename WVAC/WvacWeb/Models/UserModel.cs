using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WvacWeb.Models
{
    public class UserModel
    {
        wvacEntities wvac = new wvacEntities();

        public String InsertUser(user user)
        {
            try
            {
                wvac.users.Add(user);
                wvac.SaveChanges();
                return ("Your User ID is " + user.UserID);
            }
            catch (Exception ex)
            {
                return (ex.ToString());

            }
        }
      
    }
}