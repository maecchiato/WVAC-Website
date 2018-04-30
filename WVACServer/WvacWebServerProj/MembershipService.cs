using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WVACWebServer.Models;

namespace WvacWebServerProj
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MembershipService" in both code and config file together.
    public class MembershipService : IMembershipService
    {
        wvacEntities wvac = new wvacEntities();
        // methods for mem form

        //method to confirm the right amount of shares
        public Boolean ConfirmShares(int shares)
        {
            Boolean confirm;
            confirm = (shares >= 40);
            return confirm;

        }

        //method to confirm sufficient payment
        public Boolean ConfirmPayment(double payment, int shares, string mode)
        {
            double total = shares * 1000;

            Boolean confirmIns = (payment >= (total * .25) + 1000);
            Boolean confirmLump = (payment >= total + 1000);

            Boolean confirmPay = false;

            if (mode.Equals("Installment") == true)
            {
                confirmPay = confirmIns;
            }


            else if (mode.Equals("Lump Sum") == true)
            {
                confirmPay = confirmLump;
            }

            return confirmPay;
        }

        //create member installment
        public membership CreateMemberIns(int uID, int shares, string mode, int months,
                          double bal, double monthlyDue, string typeIns)
        {
            membership member = new membership();
            MembershipModel mm = new MembershipModel();
            member = mm.CreateMemberInstallment(uID, shares, mode, months, bal, monthlyDue, typeIns);

            return member;
        }

        //create member lumpsum
        public membership CreateMemberLump(int userId, int shares, string modeofP)
        {
            membership member = new membership();
            MembershipModel mm = new MembershipModel();
            member = mm.CreateMemberLump(userId, shares, modeofP);
            return member;
        }

        //create member (either lumpsum or installment)
        public string CreateMember(string mode, int shares, double payment, int uID, int months,
                         double bal, double monthlyDue, string typeIns)
        {
            MembershipModel mm = new MembershipModel();
            String output = " ";

            if (ConfirmShares(shares) == true)
            {
                if (mode.Equals("Installment") == true)
                {
                    if (ConfirmPayment(payment, shares, mode) == true)
                    {
                        membership mem = CreateMemberIns(uID, shares, mode, months, bal, monthlyDue, typeIns);
                        output = mm.InsertMembership(mem);
                    }
                    else
                    {
                        output = "You must at least pay 25% of the total amount of shares";
                    }
                }
                else
                {
                    if (ConfirmPayment(payment, shares, mode) == true)
                    {
                        membership mem = CreateMemberLump(uID, shares, mode);
                        output = mm.InsertMembership(mem);
                    }
                    else
                    {
                        output = "Insufficient amount of cash";
                    }
                }
            }
            else
            {
                output = "You must at least subscribe to 40 shares";
            }

            return output;


        }


        //calculate membership balance
        public double getBalance(String mode, int shares, double dPayment)
        {
            double bal;
            if (mode.Equals("Installment") == true)
            {

                bal = shares * 1000 - (dPayment-1000);
            }
            else
            {
                dPayment = 0;
                bal = 0;
            }
            return bal;
        }

        //calculate months to pay
        public int CalculateMonth(string typeIns)
        {

            int x = 0;
            if (typeIns.Equals("Monthly") == true)
            {
                x = 36;

            }
            else if (typeIns.Equals("Quarterly") == true)
            {
                x = 9;

            }
            else if (typeIns.Equals("Yearly") == true)
            {
                x = 3;

            }
            return x;
        }

        // end of methods for mem form

        //methods for mem account

        //method to get bill
        public double getBill(int id)
        {
            double bill;
            int monthsPaid;
            int monthsToPay;
            try
            {


                membership m = wvac.memberships.Find(id);
                monthsPaid = Convert.ToInt32(m.MonthsPaid);
                monthsToPay = Convert.ToInt32(m.MonthsToPay);
                if (monthsToPay - monthsPaid == 1)
                {
                    bill = Convert.ToDouble(m.Balance);
                }
                else
                {
                    bill = m.MonthlyDue;
                }
            }
            catch
            {
                bill = 0;
            }
            return bill;
        }

        //method to get fine
        public double getFine(int id, DateTime payDate)
        {
            int days;
            double fine = 0;

            membership m = wvac.memberships.Find(id);
            DateTime s = m.SchedDate.Value;
            days = payDate.Day - s.Day;



            if (payDate.Month - s.Month > 0)
            {
                if (payDate.Month == 1 || payDate.Month == 3 || payDate.Month == 5 || payDate.Month == 7
                    || payDate.Month == 8 || payDate.Month == 10 || payDate.Month == 12)
                {
                    days = 31 - s.Day + payDate.Day;
                }

                else if (payDate.Month == 11 || payDate.Month == 4 || payDate.Month == 6 || payDate.Month == 9)
                {
                    days = 30 - s.Day + payDate.Day;
                }
                else
                {
                    days = 28 - s.Day + payDate.Day;
                }
            }

            if (days > 15)
            {
                fine = m.MonthlyDue * 0.02;
            }

            return fine;
        }

        //method to call create payment and update membership record
        public string GetPayment(int id, DateTime payDate, double fine,
            double payment, double cash, double change)
        {

            MemPayModel mp = new MemPayModel();
            mempayment mem = CreatePayment(id,  payDate,  fine,
             payment,  cash, change);
            MembershipModel mm = new MembershipModel();

            mm.UpdateMembership(id, payment);
            return( mp.InsertPayment(mem) +
                "\n\nYour change is PHP" + (cash - payment));
        }

        //method to create payment
        public mempayment CreatePayment(int id, DateTime payDate, double fine,
            double payment, double cash, double change)
        {
            MemPayModel mp = new MemPayModel();
            mempayment mem = mp.CreatePayment(id, payDate,fine,
            payment, cash ,change);
            return mem;
            
        }  

        //method to view membership profile
        public string ViewMembership(int id)
        {
            string selectedProfile;
            const String format = "{0,-20}{1,-5}";
            try
            {
                membership m = wvac.memberships.Find(id);
                
                var profile = (from c in wvac.memberships
                               where c.ID == id
                               join u in wvac.users on c.UserID equals u.UserID
                               select new
                               {
                                   u.firstName,
                                   u.lastName,
                                   c.Shares,
                                   c.TotalAmount,
                                   c.Balance,
                                   c.BeginDate,
                                   c.ModeOfPayment,
                                   c.MonthsToPay,
                                   c.MonthsPaid,
                                   c.MonthlyDue,
                                   c.SchedDate,
                                   c.status
                               });
                string mode = Convert.ToString(profile.First().ModeOfPayment);
                if (mode == "Installment")
                {
                    selectedProfile = string.Format(format, "Name: ", profile.First().firstName) + " " + profile.First().lastName + "\n";                  
                    selectedProfile = selectedProfile + string.Format(format, "Shares: ", profile.First().Shares) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Total Amount: ", profile.First().TotalAmount) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Balance: ", profile.First().Balance) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Date of Contract: ", profile.First().BeginDate) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Mode Of Payment: ", profile.First().ModeOfPayment) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Number of Payments: ", profile.First().MonthsToPay) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Months Paid:  ", profile.First().MonthsPaid) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Monthly Due: ", profile.First().MonthlyDue) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Schedule Date: ", profile.First().SchedDate) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Status: ", profile.First().status) + "\n";
                }
                else
                {
                    selectedProfile = string.Format(format, "Name: ", profile.First().firstName) + " " + profile.First().lastName + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Shares: ", profile.First().Shares) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Total Amount: ", profile.First().TotalAmount) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Date of Contract: ", profile.First().BeginDate) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Mode Of Payment: ", profile.First().ModeOfPayment) + "\n";
                    selectedProfile = selectedProfile + string.Format(format, "Status: ", profile.First().status) + "\n";
                }
            }
            catch
            {
                selectedProfile = "Profile not found.";
            }
            return selectedProfile;
        }

        //view all membership profile
        public string ViewAllMembership()
        {
            string selectedProfile = "";
            var profile = (from c in wvac.memberships
                           select c).ToList();
           
            const String format = "{0,-25}{1,-25}{2,-25}{3,-25}{4,-25}{5,-25}{6,-25}";
            selectedProfile = string.Format(format, "Membership ID: ", "Shares", "Balance", "Mode of Payment",
                                            "No of Payments", "Months Paid", "Status");
            foreach (var c in profile)
            { 
                    selectedProfile = selectedProfile + "\n" + string.Format(format,c.ID, c.Shares, c.Balance, c.ModeOfPayment, c.MonthsToPay,
                        c.MonthsPaid, c.status);
   
            }
            return selectedProfile;
        }
        public String GetRecords(int memID)
        {
            MemPayModel mp = new MemPayModel();
            return mp.GetPaymentByID(memID);
          
        }
    }
}
