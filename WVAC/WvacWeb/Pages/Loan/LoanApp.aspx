<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoanApp.aspx.cs" Inherits="WvacWeb.Pages.Loan.LoanApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br/>
    <div style="text-align:center">
    <asp:Label ID="Label1" runat="server" Text="LOAN GUIDELINES" CssClass="heading"></asp:Label>
        </div>
    <br />
    <br />
    <br />
    <div style="margin-left:75px">
    <div>
    &gt;&nbsp; Only approved members of WVAC can apply for loan.<br />
    &gt;&nbsp; 1% interest will be charged per diminishing balance per month starting the release date.<br />
    &gt;&nbsp; If a loan client fails to pay its due after fifteen(15) days, a 2% surcharge shall be imposed per month.
    <br />
    &gt;&nbsp; The following rate will be deducted to the total amount of loan<br />
    </div>
    <div style="margin-left: 45px">
    a.)&nbsp; Advance Interest (1%)<br />
    b.)&nbsp; Service Fee (2%)<br />
    c.)&nbsp; Notarial Fee
    <br />
    d.) CBU (1%)<br />
    </div>
    &gt; Net proceeds will be received after the rates above have been deducted&nbsp;
    <br />
    <br />
    </div>
    <br/>
    <div style="text-align:center">
    <asp:Button ID="Button1" runat="server" CssClass="button" PostBackUrl="~/Pages/Loan/LoanForm.aspx" Text="Apply Loan" OnClick="Button1_Click" />
    </div>
    <br />
    <br />
</asp:Content>
