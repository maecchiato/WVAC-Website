using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WVACWebServer.Models
{
    public class MembershipModel
    {
        wvacEntities wvac = new wvacEntities();
        //insert membership
        public string InsertMembership(membership mem)    
        {
            
            wvac.memberships.Add(mem);
            wvac.SaveChanges();

            return ("Your Member ID is " + mem.ID + 
                "\nYour next payment schedule is on: " + mem.SchedDate +
                "\nAmount due: PHP" + mem.MonthlyDue);
        }
        
        //update membership
        public void UpdateMembership(int id, double payment)
        {
            int months;

            membership m = wvac.memberships.Find(id);
 
            var selectMonths = (from c in wvac.memberships where c.ID == id select new { c.MonthsToPay });

            DateTime schedDate = Convert.ToDateTime(m.SchedDate);
            int monthsToPay = Convert.ToInt32(selectMonths.First().MonthsToPay);

            months = Convert.ToInt32(m.MonthsToPay);

            if (months == 36)
            {
                m.SchedDate = schedDate.AddMonths(1);
            }
            else if (months == 9)
            {
                m.SchedDate = schedDate.AddMonths(4);
            }
            else if (months == 3)
            {
                m.SchedDate = schedDate.AddYears(1);
            }

            double balance = Convert.ToDouble(m.Balance);
            int monthspaid = Convert.ToInt32(m.MonthsPaid);
            m.Balance = (double)(Math.Round(balance - payment));
            m.MonthsPaid = monthspaid + 1;

            if (m.Balance == 0)
            {
                m.status = "APPROVED";
                m.SchedDate = null;
            }
            wvac.SaveChanges();
        }

        //create member installment
        public membership CreateMemberInstallment(int uID, int shares, string mode, int months,
                          double bal, double monthlyDue, string typeIns)
        {
            membership member = new membership();
            
            member.UserID = uID;
            member.Shares = shares;
            member.ModeOfPayment = mode;
            member.MonthsToPay = months;
            member.TotalAmount = shares * 1000;
            member.Balance = bal;
            member.BeginDate = DateTime.Today;
            member.MonthlyDue = (double)Math.Round((monthlyDue) * 100) / 100;

            DateTime b = Convert.ToDateTime(member.BeginDate);
            DateTime s = b.AddMonths(setSched(typeIns));
            member.SchedDate = s;
            member.status = "Pending";

            return member;
        }

        //calculate no of months for next schedule
        public int setSched(string typeIns)
        {

            int x = 0;
            if (typeIns.Equals("Monthly") == true)
            {
                x = 1;

            }
            else if (typeIns.Equals("Quarterly") == true)
            {
                x = 4;

            }
            else if (typeIns.Equals("Yearly") == true)
            {
                x = 12;

            }
            return x;
        }

        //create member lumpsum
        public membership CreateMemberLump(int userId, int shares, string modeofP)
        {
            membership member = new membership();

            member.UserID = userId;
            member.Shares = shares;
            member.ModeOfPayment = modeofP;
            member.TotalAmount = shares* 1000;
            member.Balance = 0;
            member.status = "APPROVED";
            member.BeginDate = DateTime.Today;

            return member;
        }
}
    
}