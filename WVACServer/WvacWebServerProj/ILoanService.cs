using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WVACWebServer.Models;

namespace WvacWebServerProj
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoanService" in both code and config file together.
    [ServiceContract]
    public interface ILoanService
    {
        [OperationContract]
        string ValidateMembership(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf,
                               double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, DateTime releaseDate,
                               DateTime dateDue, DateTime schedPayment);

        [OperationContract]
        double getInterest(double balance);

        [OperationContract]
        double getFine(double monthlydue, DateTime payDate, DateTime schedDate);

        [OperationContract]
        double getMonthlyDue(int id);

        [OperationContract]
        double getBalance(int id);

        [OperationContract]
        DateTime getSchedDate(int id);

        [OperationContract]
        string processPay(int id, double monthlyDue, double payment, double cash, double bill, double interest, double fine, DateTime payDate);

        [OperationContract]
        string viewProfile(int id);

        [OperationContract]
        String GetRecords(int loanID);

        [OperationContract]
        string ViewAllLoans();
        //[OperationContract]
        //[OperationContract]
    }
}
