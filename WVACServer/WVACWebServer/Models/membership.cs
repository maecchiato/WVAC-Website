//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WVACWebServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class membership
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long Shares { get; set; }
        public double TotalAmount { get; set; }
        public Nullable<double> Balance { get; set; }
        public System.DateTime BeginDate { get; set; }
        public string ModeOfPayment { get; set; }
        public long MonthsToPay { get; set; }
        public Nullable<long> MonthsPaid { get; set; }
        public double MonthlyDue { get; set; }
        public Nullable<System.DateTime> SchedDate { get; set; }
        public string status { get; set; }
    }
}
