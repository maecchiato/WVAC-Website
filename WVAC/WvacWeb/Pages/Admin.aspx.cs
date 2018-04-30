using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WvacWeb.LoanServiceReference;
using WvacWeb.MemServiceReference;

namespace WvacWeb.Pages
{
    public partial class Admin : System.Web.UI.Page
    {
        MemServiceReference.MembershipServiceClient memservice = new MemServiceReference.MembershipServiceClient();
        LoanServiceReference.LoanServiceClient loanservice = new LoanServiceReference.LoanServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMemAccs.Text = memservice.ViewAllMembership();
            txtLoamProfile.Text = loanservice.ViewAllLoans();
        }
    }
}