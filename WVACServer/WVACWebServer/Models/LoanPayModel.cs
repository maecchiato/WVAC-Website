using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WVACWebServer.Models
{
    public class LoanPayModel
    {
        wvacEntities wvac = new wvacEntities();

        // insert payment to db
        public String insertLoanPayment(loanpayment lp)
        {
            DateTime sched;

            var s = (from c in wvac.loans where c.id == lp.LoanId select new {c.SchedDate });

            sched = Convert.ToDateTime(s.First().SchedDate);

            wvac.loanpayments.Add(lp);
            wvac.SaveChanges();

            return ("Payment successful.\nSchedule for your next payment: " + sched);
        }

        //create loanpayment
        public loanpayment createLoanPayment(int id, double payment, double interest, double fine, DateTime payDate)
        {
            loanpayment lp = new loanpayment();
            lp.LoanId = id;
            lp.AmountPaid = payment;
            lp.Interest = interest;
            lp.Fine = fine;
            lp.PayDate = payDate;

            return lp;
        }

        //get payment record
        public String GetRecords(int loanID)
        {
            var rec = (from c in wvac.loanpayments
                       where c.LoanId == loanID
                       select new { c.AmountPaid, c.Interest, c.Fine, c.PayDate }).ToList();

            String record;

            const String format = "{0,-25}{1,-25}{2,-25}{3,-25}";
            record =string.Format(format, "Amount Paid", "Interest", "Fine", "Payment Date") + "\n";
            foreach (var c in rec)
            {
                record = record + (String.Format(format, c.AmountPaid, c.Interest, c.Fine, c.PayDate));
                record = record + "\n";

                
            }
            return record;

        }
    }
}