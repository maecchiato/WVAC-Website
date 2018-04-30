using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WvacWeb.UserForms;
using WvacWeb.Models;
using WvacWeb.MemServiceReference;

namespace WvacWeb.UserPages
{
    public partial class MemAccount : System.Web.UI.Page
    {
        MemServiceReference.MembershipServiceClient memService = new MemServiceReference.MembershipServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        wvacEntities wvac = new wvacEntities();
        MemForm mem = new MemForm();
        int id;
        DateTime payDate;
        double bill;
        double fine;
        double cash;
        double payment;
        double change;
        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(txtId.Text);
                payDate = Convert.ToDateTime(txtpayDate.Text);
                GenerateBill();
                txtBill.Text = "Your total bill is: PHP" + (bill + fine) + " your have a fine of: PHP" + fine;
               
            }
            catch
            {
                txtBill.Text = "Your bill is 0, please check if either you have not\napplied for membership yet or your membership has already been\napproved";
            }      
        }
        
        //get the bill and the fine
        public void GenerateBill()
        {
            
            bill = memService.getBill(id);
            fine = memService.getFine(id, payDate);
        }
        //call methods for payment
        protected void btnPay_Click(object sender, EventArgs e)
        {

            id = Convert.ToInt32(txtId.Text);
            payDate = Convert.ToDateTime(txtpayDate.Text);
            GenerateBill();

            cash = Convert.ToDouble(txtPayment.Text);
            payment = bill + fine;   
            change = cash - payment;

            if (cash >= payment)
            {
               txtReceipt.Text=  memService.GetPayment(id, payDate,fine, payment,cash, change);
                
            }
            else
            {
                txtReceipt.Text= "Payment insufficient";
            }
            
        }
        //view profile
        protected void btnView_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtMemId.Text);
            txtAreaProfile.Text = memService.ViewMembership(id);
        } 
        //get user's records records
        protected void Button1_Click(object sender, EventArgs e)
        {
            int memID = Convert.ToInt32(txtMemIdRec.Text);
            txtRecords.Text = memService.GetRecords(memID);
        } 

  
    }
}