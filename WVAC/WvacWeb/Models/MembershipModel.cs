using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WvacWeb.Models;

namespace WvacWeb.Models
{
    public class MembershipModel
    {
        wvacEntities wvac = new wvacEntities();

        public string InsertMembership(membership mem)    
        {
            
            wvac.memberships.Add(mem);
            wvac.SaveChanges();

            return ("Your Member ID is " + mem.ID + 
                "\nYour next payment schedule is on: " + mem.SchedDate +
                "\nAmount due: PHP" + mem.MonthlyDue);
        }

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

    }
}