using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WvacWeb.Models;
using WvacWeb.Pages.Loan;


namespace WvacWeb.Pages.Loan
{
    public partial class LoanAccount : System.Web.UI.Page
    {
        
        int id;
        double balance;
        double monthlyDue;
        double bill;
        double fine;
        double interest;
        double payment;
        double cash;
        double change;
        DateTime payDate;
        DateTime schedDate;

        wvacEntities wvac = new wvacEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        LoanServiceReference.LoanServiceClient loanService = new LoanServiceReference.LoanServiceClient();
  

        //retrives loan client data and prompt bill
        protected void btnFind_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtLid.Text);
            payDate = Convert.ToDateTime(txtpayDate.Text);      
            GenerateBill();          
        }
        
        //method to generate bill
        public void GenerateBill()
        {    
               schedDate = loanService.getSchedDate(id);
               balance = loanService.getBalance(id);
               monthlyDue = loanService.getMonthlyDue(id);
               fine = loanService.getFine(monthlyDue, payDate, schedDate);
               interest = loanService.getInterest(balance);
               bill = monthlyDue + fine + interest;
               txtbill.Text = "Amount Due: " + monthlyDue
                    + "\nInterest Amount: " + interest
                    + "\nFine: " + fine +
                    "\n------------------------------------" +
                    "\nTotal Bill: " + bill;
            //if there is no record in database
            if (monthlyDue == 0)
            {
                txtbill.Text = txtbill.Text + "\nYou have no record of loan.\nKindly check if either you've already settled your payment or \n" +
                    "you haven't applied for loan yet.";
            }
            
            
        }

        //method to generate payment needed for data
        public void GeneratePaymentData()
        {
            balance = loanService.getBalance(id);
            schedDate = loanService.getSchedDate(id);
            monthlyDue = loanService.getMonthlyDue(id);
            fine = loanService.getFine(monthlyDue, payDate, schedDate);
            interest = loanService.getInterest(balance);
            payment = monthlyDue + fine + interest;
            bill = monthlyDue + fine + interest;
        }

        //sends payment
        protected void btnPay_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32( txtLid.Text);
            cash = Convert.ToDouble(txtPayment.Text);
            payDate = Convert.ToDateTime(txtpayDate.Text);
            GeneratePaymentData();
            change = Math.Round(cash - payment);
            txtReceipt.Text = loanService.processPay(id, monthlyDue, payment, cash, bill, interest, fine, payDate);
            if (change >= 0)
            txtReceipt.Text = txtReceipt.Text + "\nYour change is Php:" + change;

        }

        
       


    

        protected void btnView_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtLoanId.Text);
            txtAreaProfile.Text = loanService.viewProfile(id);
        }

        protected void btnViewRecords_Click(object sender, EventArgs e)
        {
            
            int loanID = Convert.ToInt32(txtLoanIdRec.Text);
            txtRecords.Text = loanService.GetRecords(loanID);
        }

       
    }
}