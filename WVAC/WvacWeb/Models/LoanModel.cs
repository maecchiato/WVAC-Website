using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WvacWeb.Models;

namespace WvacWeb.Pages.Loan
{
    public class LoanModel
    {
        wvacEntities wvac = new wvacEntities();

        public string InsertLoan(loan loan)
        {
            try
            {


                wvac.loans.Add(loan);
                wvac.SaveChanges();

                return ("Your Loan ID is: " + loan.id +
                        "\nLoan Amount: " + loan.LoanAmount +
                        "\nTotal Deductions: " + (loan.AdvanceIntrest
                        + loan.CBU + loan.ServiceFee + loan.NotarialFee) +
                        "\nNet Proceeds: " + (loan.LoanAmount - (loan.AdvanceIntrest
                        + loan.CBU + loan.ServiceFee + loan.NotarialFee)) +
                        "\nSchedule for Next Payment: " + loan.SchedDate);
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

        }

        public void updateLoan(int id, double payment)
        {
            loan l = wvac.loans.Find(id);
            DateTime s;

            l.Balance = l.Balance - payment;
            s = l.SchedDate.Value;
            l.SchedDate = s.AddMonths(1);

            if (l.Balance == 0)
            {
                l.Status = "FULLY PAID";
                l.SchedDate = null;
            }
            wvac.SaveChanges();
        }
        
    }
}