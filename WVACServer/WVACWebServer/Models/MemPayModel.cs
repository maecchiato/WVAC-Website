using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WVACWebServer.Models
{
    public class MemPayModel
    {
        wvacEntities wvac = new wvacEntities();

        public string InsertPayment( mempayment payment)
        {
            try
            {
                wvac.mempayments.Add(payment);
                wvac.SaveChanges();

                return "Payment successful.";
            }

            catch (Exception ex)
            {
                return "Error: " + ex;
            }
        }

        public List<mempayment> GetAllPayments()
        {
            try
            {
                List<mempayment> payment = (from c in wvac.mempayments
                                          select c).ToList();

                return payment;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string GetPaymentByID(int memID)
        {
            var rec = (from c in wvac.mempayments
                                    where c.memID == memID
                                    select c).ToList();
            string record ="";
            const String format = "{0,-25}{1,-25}{2,-25}{3,-25}";

            record = record + String.Format(format, "Amount Paid", "Fine", "Cash", "Payment Date") + "\n";
            foreach (var c in rec)
            {
                record = record + String.Format(format, c.amountPaid, c.fine, c.cash, c.payDate) + "\n";
            }
            return record;
        }

        public mempayment CreatePayment(int id, DateTime payDate, double fine,
            double payment, double cash, double change)
        {
            mempayment mem = new mempayment();
            mem.memID = id;
            mem.payDate = payDate;
            mem.fine = (double)Math.Round(fine);
            mem.amountPaid = (double)Math.Round(payment);
            mem.cash = (double)Math.Round(cash);
            mem.change = (double)Math.Round(change);

            return mem;
        }

    }
}