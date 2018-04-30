using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WvacWeb.Models;
using WvacWeb.UserPages;
using WvacWeb.UserServiceReference;
using WvacWeb.MemServiceReference;

namespace WvacWeb.UserForms
{
    public partial class MemForm : System.Web.UI.Page
    {
        
        //membership variables
        string modeofP;
        double dPayment;
        string typeIns = " ";
        int months;
        double bal;
        double monthlyDue;

        int shares;
        int userId;

        Boolean confirmShares;
        Boolean confirmPayIns;
        Boolean confirmPayLump;

        //User variables
       string firstName;
       string lastName;
       string address;
       string civilStatus;
       string age;
       string contactNo;
       string emailAdd;
       string gender;

        UserServiceReference.UserServiceClient userService = new UserServiceReference.UserServiceClient();
        MemServiceReference.MembershipServiceClient memService = new MemServiceReference.MembershipServiceClient();


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        //private user CreateUser()
        //{
        //    user user = new user();
        //    user.firstName = firstName;
        //    user.lastName = lastName;
        //    user.address = address;
        //    user.civilStatus = civilStatus;
        //    user.age = age;
        //    user.gender = gender;
        //    user.contactNo = contactNo;
        //    user.emailAdd = emailAdd;


        //    return user;
        //}//create user

        public void getUserInput()
        {
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            address = txtAddress.Text;
            civilStatus = ddCStat.Text;
            age = txtAge.Text;
            contactNo = txtContactNo.Text;
            emailAdd = txtEmailAdd.Text;
        }//get user input

        protected void btnOk_Click(object sender, EventArgs e)
        {
            getUserInput();
            UserModel um = new UserModel();
            txtResult.Text = userService.CreateUser(firstName, lastName, address, civilStatus, age, gender,
                contactNo, emailAdd);
        } //insert user to database

        protected void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = rbMale.Text;
        }
        protected void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = rbFemale.Text;
        }

     

        protected void btnApply_Click(object sender, EventArgs e)
        {
            txtRezult.Text = "";
            //get input
            GetMemInput();
            //service ref method for insert mem
            txtRezult.Text = memService.CreateMember(modeofP, shares, dPayment, userId,months, bal,monthlyDue, typeIns);



        } 


        

        public void GetMemInput()
        {
            userId= Convert.ToInt32(txtUID.Text);
            shares = Convert.ToInt32(txtShares.Text);
            modeofP = ddModeOfP.SelectedValue;
            typeIns = ddlInstallment.Text;
            months = memService.CalculateMonth(typeIns);
            dPayment = Convert.ToDouble(txtdPayment.Text);
            bal = memService.getBalance(modeofP, shares, dPayment);

            monthlyDue = bal / months;

        }


        protected void ddlInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeIns = ddlInstallment.SelectedValue;
        }

    }
}