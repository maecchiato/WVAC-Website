using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WVACWebServer.Models;

namespace WVACWebServer.Models
{
    public class LoanModel
    {
        wvacEntities wvac = new wvacEntities();

        //insert loan to database
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

        //create loan 
        public loan CreateLoan(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf,
                               double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, DateTime releaseDate,
                               DateTime dateDue, DateTime schedPayment)
        {
            loan loan = new loan();

            loan.UserID = userId;
            loan.TypeOfLoan = typeOfLoan;
            loan.NoOfMonths = months;
            loan.LoanAmount = loanAmount;
            loan.AdvanceIntrest = ai;
            loan.ServiceFee = sf;
            loan.NotarialFee = NOTARIAL_FEE;
            loan.CBU = cbu;
            loan.Balance = balance;
            loan.MonthlyDue = monthlyDue;
            loan.DateRelease = releaseDate;
            loan.DateDue = dateDue;
            loan.SchedDate = schedPayment;
            loan.Status = "Pending";

            return loan;

        }
        //update loan
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

        //get loan profile
        public string ViewLoanProfile(int id)
        {
            string prof;
            try
            {
                var profile = (from c in wvac.loans
                               where c.id == id
                               join u in wvac.users on c.UserID equals u.UserID

                               select new
                               {
                                   u.firstName,
                                   u.lastName,
                                   c.TypeOfLoan,
                                   c.NoOfMonths,
                                   c.LoanAmount,
                                   c.AdvanceIntrest,
                                   c.ServiceFee,
                                   c.CBU,
                                   c.Balance,
                                   c.MonthlyDue,
                                   c.DateRelease,
                                   c.DateDue,
                                   c.SchedDate,
                                   c.Status
                               }).ToList();

                const String format = "{0,-23}{1, -10}";
                prof = String.Format(format, "First Name: ", profile.First().firstName) + "\n";
                prof = prof + String.Format(format, "Last Name: ", profile.First().lastName) + "\n";
                prof = prof + String.Format(format, "Type of Loan: ", profile.First().TypeOfLoan) + "\n";
                prof = prof + String.Format(format, "No. of Months: ", profile.First().NoOfMonths) + "\n";
                prof = prof + String.Format(format, "Loan Amount: ", profile.First().LoanAmount) + "\n";
                prof = prof + String.Format(format, "Advance Interest: ", profile.First().AdvanceIntrest) + "\n";
                prof = prof + String.Format(format, "Service Fee: ", profile.First().ServiceFee) + "\n";
                prof = prof + String.Format(format, "CBU: ", profile.First().CBU) + "\n";
                prof = prof + String.Format(format, "Balance: ", profile.First().Balance) + "\n";
                prof = prof + String.Format(format, "Monthly Due: ", profile.First().MonthlyDue) + "\n";
                prof = prof + String.Format(format, "Date Release: ", profile.First().DateRelease) + "\n";
                prof = prof + String.Format(format, "Next Scheduled Date:", profile.First().SchedDate) + "\n";
                prof = prof + String.Format(format, "Status :", profile.First().Status) + "\n";
            }
            catch 
            {
                prof = "Record Not Found!\nYou must pay atleast once.";
            }
            return prof;

        }
    }
}