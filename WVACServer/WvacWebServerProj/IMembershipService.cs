using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WVACWebServer.Models;

namespace WvacWebServerProj
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMembershipService" in both code and config file together.
    [ServiceContract]
    public interface IMembershipService
    {
        [OperationContract]
        Boolean ConfirmShares(int shares);

        [OperationContract]
        Boolean ConfirmPayment(double payment, int shares, string mode);

        [OperationContract]
        membership CreateMemberIns(int uID, int shares, string mode, int months, double bal, double monthlyDue, string typeIns);

        [OperationContract]
        membership CreateMemberLump(int userId, int shares, string modeofP);

        [OperationContract]
        string CreateMember(string mode, int shares, double payment, int uID, int months,
                         double bal, double monthlyDue, string typeIns);

        [OperationContract]
        double getBalance(String mode, int shares, double dPayment);

        [OperationContract]
        int CalculateMonth(string typeIns);

        [OperationContract]
        double getBill(int id);

        [OperationContract]
        double getFine(int id, DateTime payDate);

        [OperationContract]
        string GetPayment(int id, DateTime payDate, double fine,
            double payment, double cash, double change);

        [OperationContract]
        mempayment CreatePayment(int id, DateTime payDate, double fine,
            double payment, double cash, double change);

        [OperationContract]
        string ViewMembership(int id);

        [OperationContract]
        String GetRecords(int memID);

        [OperationContract]
        string ViewAllMembership();

    }
}
