using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WvacWeb.Models;
using WvacWeb.Pages.Loan;
using WvacWeb.LoanServiceReference;

namespace WvacWeb.Pages.Loan
{
    public partial class LoanForm : System.Web.UI.Page
    {
        double ADVANCE_INTEREST = 0.01;
        double SERVICE_FEE = 0.02;
        double NOTARIAL_FEE = 300;
        double CBU = 0.01;

        double ai;
        double sf;
        double cbu;

        int userId;
        double loanAmount;
        string typeOfLoan;
        int months;
        double balance;
        double monthlyDue;
        DateTime releaseDate;
        DateTime dateDue;
        DateTime schedPayment;

        //outout for user
        double totalDeductions;
        double netProceeds;

        wvacEntities wvac = new wvacEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        LoanServiceReference.LoanServiceClient loanService = new LoanServiceReference.LoanServiceClient();
        protected void btnApplyLoan_Click(object sender, EventArgs e)
        {
            //initialize all variables needed for loan
            InitializeVariables();
            //only approved members can apply for loan
            txtResult.Text= loanService.ValidateMembership(userId, typeOfLoan, months, loanAmount, ai, sf,
                                NOTARIAL_FEE, cbu, balance, monthlyDue, releaseDate, dateDue, schedPayment);
        }

        //method to initialize all variables needed for loan
        public void InitializeVariables()
        {
            userId = Convert.ToInt32(txtUserID.Text);
            loanAmount = Convert.ToDouble(txtAmount.Text);
            balance = loanAmount;
            typeOfLoan = ddlType.SelectedValue;
            
            months = Convert.ToInt32(ddlMonths.SelectedValue);
            if (typeOfLoan.Equals("Long Term")==true)
            {
                months = months * 12;
            }
            
            releaseDate = Convert.ToDateTime(txtDateRelease.Text);
            dateDue = releaseDate.AddMonths(months);
            ai = (double)Math.Round((loanAmount * ADVANCE_INTEREST) * 100) / 100;
            sf = (double)Math.Round((loanAmount * SERVICE_FEE) * 100) / 100;
            cbu = (double)Math.Round((loanAmount * CBU) * 100) / 100; 
            totalDeductions = (double)Math.Round((ai + sf + cbu + NOTARIAL_FEE) * 100) / 100;
            monthlyDue = (double)Math.Round((balance / months) * 100) / 100;
            schedPayment = releaseDate.AddMonths(1);
            
        } 
        
        //generate the number of months based on the type of loan
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeOfLoan = Convert.ToString(ddlType.SelectedItem);


            if (typeOfLoan == ("Long Term"))
            {
                ddlMonths.Items.Clear();
                ddlMonths.Items.Add("1");
                ddlMonths.Items.Add("2");
                //ddlMonths.DataBind();
            }
            else if (typeOfLoan == ("Short Term"))
            {
                ddlMonths.Items.Clear();
                ddlMonths.Items.Add("1");
                ddlMonths.Items.Add("2");
                ddlMonths.Items.Add("3");
                ddlMonths.Items.Add("4");
                ddlMonths.Items.Add("5");
                ddlMonths.Items.Add("6");
            }
            
        }
    }
}