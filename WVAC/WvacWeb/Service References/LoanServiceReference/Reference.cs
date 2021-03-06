﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WvacWeb.LoanServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoanServiceReference.ILoanService")]
    public interface ILoanService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/ValidateMembership", ReplyAction="http://tempuri.org/ILoanService/ValidateMembershipResponse")]
        string ValidateMembership(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf, double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, System.DateTime releaseDate, System.DateTime dateDue, System.DateTime schedPayment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/ValidateMembership", ReplyAction="http://tempuri.org/ILoanService/ValidateMembershipResponse")]
        System.Threading.Tasks.Task<string> ValidateMembershipAsync(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf, double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, System.DateTime releaseDate, System.DateTime dateDue, System.DateTime schedPayment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getInterest", ReplyAction="http://tempuri.org/ILoanService/getInterestResponse")]
        double getInterest(double balance);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getInterest", ReplyAction="http://tempuri.org/ILoanService/getInterestResponse")]
        System.Threading.Tasks.Task<double> getInterestAsync(double balance);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getFine", ReplyAction="http://tempuri.org/ILoanService/getFineResponse")]
        double getFine(double monthlydue, System.DateTime payDate, System.DateTime schedDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getFine", ReplyAction="http://tempuri.org/ILoanService/getFineResponse")]
        System.Threading.Tasks.Task<double> getFineAsync(double monthlydue, System.DateTime payDate, System.DateTime schedDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getMonthlyDue", ReplyAction="http://tempuri.org/ILoanService/getMonthlyDueResponse")]
        double getMonthlyDue(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getMonthlyDue", ReplyAction="http://tempuri.org/ILoanService/getMonthlyDueResponse")]
        System.Threading.Tasks.Task<double> getMonthlyDueAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getBalance", ReplyAction="http://tempuri.org/ILoanService/getBalanceResponse")]
        double getBalance(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getBalance", ReplyAction="http://tempuri.org/ILoanService/getBalanceResponse")]
        System.Threading.Tasks.Task<double> getBalanceAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getSchedDate", ReplyAction="http://tempuri.org/ILoanService/getSchedDateResponse")]
        System.DateTime getSchedDate(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/getSchedDate", ReplyAction="http://tempuri.org/ILoanService/getSchedDateResponse")]
        System.Threading.Tasks.Task<System.DateTime> getSchedDateAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/processPay", ReplyAction="http://tempuri.org/ILoanService/processPayResponse")]
        string processPay(int id, double monthlyDue, double payment, double cash, double bill, double interest, double fine, System.DateTime payDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/processPay", ReplyAction="http://tempuri.org/ILoanService/processPayResponse")]
        System.Threading.Tasks.Task<string> processPayAsync(int id, double monthlyDue, double payment, double cash, double bill, double interest, double fine, System.DateTime payDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/viewProfile", ReplyAction="http://tempuri.org/ILoanService/viewProfileResponse")]
        string viewProfile(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/viewProfile", ReplyAction="http://tempuri.org/ILoanService/viewProfileResponse")]
        System.Threading.Tasks.Task<string> viewProfileAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/GetRecords", ReplyAction="http://tempuri.org/ILoanService/GetRecordsResponse")]
        string GetRecords(int loanID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/GetRecords", ReplyAction="http://tempuri.org/ILoanService/GetRecordsResponse")]
        System.Threading.Tasks.Task<string> GetRecordsAsync(int loanID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/ViewAllLoans", ReplyAction="http://tempuri.org/ILoanService/ViewAllLoansResponse")]
        string ViewAllLoans();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoanService/ViewAllLoans", ReplyAction="http://tempuri.org/ILoanService/ViewAllLoansResponse")]
        System.Threading.Tasks.Task<string> ViewAllLoansAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoanServiceChannel : WvacWeb.LoanServiceReference.ILoanService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoanServiceClient : System.ServiceModel.ClientBase<WvacWeb.LoanServiceReference.ILoanService>, WvacWeb.LoanServiceReference.ILoanService {
        
        public LoanServiceClient() {
        }
        
        public LoanServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoanServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoanServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoanServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ValidateMembership(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf, double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, System.DateTime releaseDate, System.DateTime dateDue, System.DateTime schedPayment) {
            return base.Channel.ValidateMembership(userId, typeOfLoan, months, loanAmount, ai, sf, NOTARIAL_FEE, cbu, balance, monthlyDue, releaseDate, dateDue, schedPayment);
        }
        
        public System.Threading.Tasks.Task<string> ValidateMembershipAsync(int userId, string typeOfLoan, int months, double loanAmount, double ai, double sf, double NOTARIAL_FEE, double cbu, double balance, double monthlyDue, System.DateTime releaseDate, System.DateTime dateDue, System.DateTime schedPayment) {
            return base.Channel.ValidateMembershipAsync(userId, typeOfLoan, months, loanAmount, ai, sf, NOTARIAL_FEE, cbu, balance, monthlyDue, releaseDate, dateDue, schedPayment);
        }
        
        public double getInterest(double balance) {
            return base.Channel.getInterest(balance);
        }
        
        public System.Threading.Tasks.Task<double> getInterestAsync(double balance) {
            return base.Channel.getInterestAsync(balance);
        }
        
        public double getFine(double monthlydue, System.DateTime payDate, System.DateTime schedDate) {
            return base.Channel.getFine(monthlydue, payDate, schedDate);
        }
        
        public System.Threading.Tasks.Task<double> getFineAsync(double monthlydue, System.DateTime payDate, System.DateTime schedDate) {
            return base.Channel.getFineAsync(monthlydue, payDate, schedDate);
        }
        
        public double getMonthlyDue(int id) {
            return base.Channel.getMonthlyDue(id);
        }
        
        public System.Threading.Tasks.Task<double> getMonthlyDueAsync(int id) {
            return base.Channel.getMonthlyDueAsync(id);
        }
        
        public double getBalance(int id) {
            return base.Channel.getBalance(id);
        }
        
        public System.Threading.Tasks.Task<double> getBalanceAsync(int id) {
            return base.Channel.getBalanceAsync(id);
        }
        
        public System.DateTime getSchedDate(int id) {
            return base.Channel.getSchedDate(id);
        }
        
        public System.Threading.Tasks.Task<System.DateTime> getSchedDateAsync(int id) {
            return base.Channel.getSchedDateAsync(id);
        }
        
        public string processPay(int id, double monthlyDue, double payment, double cash, double bill, double interest, double fine, System.DateTime payDate) {
            return base.Channel.processPay(id, monthlyDue, payment, cash, bill, interest, fine, payDate);
        }
        
        public System.Threading.Tasks.Task<string> processPayAsync(int id, double monthlyDue, double payment, double cash, double bill, double interest, double fine, System.DateTime payDate) {
            return base.Channel.processPayAsync(id, monthlyDue, payment, cash, bill, interest, fine, payDate);
        }
        
        public string viewProfile(int id) {
            return base.Channel.viewProfile(id);
        }
        
        public System.Threading.Tasks.Task<string> viewProfileAsync(int id) {
            return base.Channel.viewProfileAsync(id);
        }
        
        public string GetRecords(int loanID) {
            return base.Channel.GetRecords(loanID);
        }
        
        public System.Threading.Tasks.Task<string> GetRecordsAsync(int loanID) {
            return base.Channel.GetRecordsAsync(loanID);
        }
        
        public string ViewAllLoans() {
            return base.Channel.ViewAllLoans();
        }
        
        public System.Threading.Tasks.Task<string> ViewAllLoansAsync() {
            return base.Channel.ViewAllLoansAsync();
        }
    }
}
