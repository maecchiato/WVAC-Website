<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoanForm.aspx.cs" Inherits="WvacWeb.Pages.Loan.LoanForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div style="text-align:center">
    <asp:Label ID="Label1" runat="server" Text="LOAN APPLICATION" CssClass="heading"></asp:Label>
    </div>
    <br />
    <br />
    <div style="text-align: center">     
    <asp:Panel ID="Panel1" runat="server" CssClass="row">
        <br />
        User ID:&nbsp;
        <asp:TextBox ID="txtUserID" runat="server" Width="38px"></asp:TextBox>
        <br />
        <br />
        Amount of Loan:&nbsp;
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
        <br />
        <br />
        Type of Loan:&nbsp;
        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Short Term</asp:ListItem>
            <asp:ListItem>Long Term</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        No of Months/Years :&nbsp;
        <asp:DropDownList ID="ddlMonths" runat="server" Width="50px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Date Today:&nbsp;
        <asp:TextBox ID="txtDateRelease" runat="server" TextMode="Date" Width="152px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnApplyLoan" runat="server" CssClass="button" Text="Apply" Width="233px" OnClick="btnApplyLoan_Click" />
        <br />
        <br />
        <asp:TextBox ID="txtResult" runat="server" Height="143px" TextMode="MultiLine" Width="342px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
        </div>
    <br />
    <br />
</asp:Content>
