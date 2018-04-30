using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WVACWebServer.Models;

namespace WvacWebServerProj
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoanService" in both code and config file together.
    public class LoanService : ILoanService
    {
        wvacEntities wvac = new wvacEntities();

        //checks if loan client is a member
        public string ValidateMembership(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf,
                               double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, DateTime releaseDate,
                               DateTime dateDue, DateTime schedPayment)
        {

            LoanModel l = new LoanModel();
            String output;
            var val = (from c in wvac.memberships where c.UserID == userId select new { c.status });
            string status = Convert.ToString(val.First().status);
            if (status != null)
            {
                output = l.InsertLoan(l.CreateLoan(userId, typeOfLoan, months, loanAmount, ai, sf,
                                NOTARIAL_FEE, cbu, balance, monthlyDue, releaseDate, dateDue, schedPayment));
            }
            else
            {
                output = "You are not an approved member. \nOnly approved members can apply for loan.";
            }
            return output;

        }

        //get balance
        public double getBalance(int id)
        {
            try
            {
                loan l = wvac.loans.Find(id);
                return Convert.ToDouble(l.Balance);

            }
            catch
            {
                return 0;
            }

        }

        //get monthly due
        public double getMonthlyDue(int id)
        {
            try
            {
                loan l = wvac.loans.Find(id);
                double balance = Convert.ToDouble(l.Balance);
                double monthlyDue = Convert.ToDouble(l.MonthlyDue);
                double due;


                //pay the remaining balance in the last payment
                if ((balance - monthlyDue) < monthlyDue)
                {

                    due = Convert.ToDouble(l.Balance);

                }
                else
                {
                    due = Convert.ToDouble(l.MonthlyDue);
                }


                return due;
            }
            catch
            {
                return 0;
            }


        }

        //computes monthly interest
        public double getInterest(double balance)
        {
            return (double)Math.Round((balance * .01) * 100) / 100;
        }

        //generates fine for late payments
        public double getFine(double monthlydue, DateTime payDate, DateTime schedDate)
        {
            try
            {
                int days;
                double fine = 0;
                days = payDate.Day - schedDate.Day;



                if (payDate.Month - schedDate.Month > 0)
                {
                    if (payDate.Month == 1 || payDate.Month == 3 || payDate.Month == 5 || payDate.Month == 7
                        || payDate.Month == 8 || payDate.Month == 10 || payDate.Month == 12)
                    {
                        days = 31 - schedDate.Day + payDate.Day;
                    }

                    else if (payDate.Month == 11 || payDate.Month == 4 || payDate.Month == 6 || payDate.Month == 9)
                    {
                        days = 30 - schedDate.Day + payDate.Day;
                    }
                    else
                    {
                        days = 28 - schedDate.Day + payDate.Day;
                    }
                }

                if (days > 15)
                {
                    fine = monthlydue * 0.02;
                }

                return (double)Math.Round(fine * 100) / 100;
            }
            catch
            {
                return 0;
            }

        }

        //get schedDate
        public DateTime getSchedDate(int id)
        {
            try
            {
                loan l = wvac.loans.Find(id);
                return Convert.ToDateTime(l.SchedDate);
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }

        //process payment
        public string processPay(int id, double monthlyDue, double payment, double cash, double bill, double interest, double fine, DateTime payDate)
        {
            if (cash >= bill)
            {
                LoanPayModel lp = new LoanPayModel();
                LoanModel lm = new LoanModel();
                lm.updateLoan(id, monthlyDue);
                return lp.insertLoanPayment(lp.createLoanPayment(id, payment, interest, fine, payDate));
            }
            else
            {
                return "Insufficient amount of cash.";
            }

        }

        //retrieves loan profile from database
        public string viewProfile(int id)
        {
            LoanModel lm = new LoanModel();
            return lm.ViewLoanProfile(id);

        }

        //gets records
        public String GetRecords(int loanID)
        {
            LoanPayModel lp = new LoanPayModel();
            return lp.GetRecords(loanID);
        }

        //all loans
        public string ViewAllLoans()
        {
            string selectedProfile = "";
            var profile = (from c in wvac.loans
                           select c).ToList();

            const String format = "{0,-25}{1,-25}{2,-25}{3,-25}{4,-25}{5,-25}{6,-25}";
            selectedProfile = string.Format(format, "Loan ID: ", "Type of Loan", "No of Months", "Loan Amount", 
                                    "Date Release", "Date Due", "Status");
            foreach (var c in profile)
            {
                selectedProfile = selectedProfile + "\n" + string.Format(format, c.id , c.TypeOfLoan, c.NoOfMonths,
                                    c.LoanAmount, c.DateRelease, c.DateDue, c.Status);

            }
            return selectedProfile;
        }
    }
}
