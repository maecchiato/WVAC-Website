using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WvacWeb.Models
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


    }
}