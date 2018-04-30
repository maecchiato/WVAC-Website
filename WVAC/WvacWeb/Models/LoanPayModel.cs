using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WvacWeb.Models;

namespace WvacWeb.Models
{
    public class LoanPayModel
    {
        wvacEntities wvac = new wvacEntities();

        public String insertLoanPayment(loanpayment lp)
        {
            DateTime sched;

            var s = (from c in wvac.loans where c.id == lp.LoanId select new {c.SchedDate });

            sched = Convert.ToDateTime(s.First().SchedDate);

            wvac.loanpayments.Add(lp);
            wvac.SaveChanges();

            return ("Payment successful. \nSchedule for your next payment: " + sched);
        }
    }
}