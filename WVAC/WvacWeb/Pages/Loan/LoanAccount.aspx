<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoanAccount.aspx.cs" Inherits="WvacWeb.Pages.Loan.LoanAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            margin-left: 155px;
        }
        .auto-style6 {
            background-color: rgba(222, 168, 127, 0.80);
            color: black;
            width: 403px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
        }
        .auto-style7 {
            margin-right: 0px;
        }
        .auto-style8 {
            background-color: rgba(222, 168, 127, 0.80);
            color: black;
            width: 402px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
        }
        .auto-style12 {
            width: 375px;
        }
        .auto-style13 {
            margin-left: 51px;
        }
        .auto-style14 {
            width: 50px;
        }
        .auto-style15 {
            margin-left: 108px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style ="text-align:center">
    <asp:Label ID="Label1" runat="server" Text="LOAN ACCOUNT MANAGEMENT" CssClass="heading"></asp:Label>
    </div>
    <br />
    <br />
    <br />
    <div style="text-align:center" >
<table class="auto-style3">
    <tr>
        <td class="auto-style12">
            Loan ID:
            <asp:TextBox ID="txtLoanId" runat="server" Width="27px"></asp:TextBox>
            &nbsp;<br />
            <asp:Button ID="btnView" runat="server" Text="View Profile" Width="227px" CssClass="button" Height="40px" OnClick="btnView_Click" />
        </td>

        
        <td class="auto-style12" style="text-align:center">
            <asp:TextBox ID="txtAreaProfile" runat="server" Height="264px" ReadOnly="True" TextMode="MultiLine" Width="350px" Wrap="False"></asp:TextBox>
        </td>


        
    </tr>
</table>
</div>

        <br />

        <br />
<div style="text-align:center" > 
<table class="auto-style15">
    <tr>
        
        <td class="auto-style6">
        <br/>
            Loan ID:&nbsp;&nbsp;
        <asp:TextBox ID="txtLid" runat="server" Width="33px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Date Today: "></asp:Label>
            &nbsp;&nbsp;
        <asp:TextBox ID="txtpayDate" runat="server" ForeColor="Gray" TextMode="Date">yyyy-mm-dd</asp:TextBox>

        <asp:Button ID="btnFind" runat="server" CssClass="button" Height="40px" Text="Get Bill" Width="250px" OnClick="btnFind_Click" />
        <br/>
            <br />
            <asp:TextBox ID="txtbill" runat="server" Height="168px" TextMode="MultiLine" Width="293px"></asp:TextBox>
        <br/>
        <br/>
        </td>
        <td class="auto-style14">
        </td>

        <td class="auto-style8">
            <br />
        <asp:Label ID="Label3" runat="server" Text="Enter Amount of Payment:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPayment" runat="server" Width="82px"></asp:TextBox>
        &nbsp;&nbsp;
        <br />
         <asp:Button ID="btnPay" runat="server" CssClass="button" Height="40px" Text="Pay" Width="250px" OnClick="btnPay_Click" />
         <br />
        <br />
            <asp:TextBox ID="txtReceipt" runat="server" CssClass="auto-style7" Height="174px" TextMode="MultiLine" Width="288px"></asp:TextBox>
            <br />
         <br />
        </td>
    </tr>
</table>
</div>
    <br />
    <br />
<asp:Panel ID="Panel2" runat="server" Height="555px" Width="1054px" BorderStyle="Double" BorderWidth="3px">
            <br />
            <div style ="text-align:center">
            <asp:Label ID="Label6" runat="server" CssClass="heading" Text="ACCOUNT RECORDS" ></asp:Label>
            </div>
            <br />
            <br />
            <div style="text-align:center">
            <asp:Label ID="Label7" runat="server" Text="Loan ID:"></asp:Label>
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtLoanIdRec" runat="server" Width="33px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;<asp:Button ID="btnViewRecords" runat="server" CssClass="button" Height="40px"  Text="View Records" Width="185px" OnClick="btnViewRecords_Click" />
                &nbsp;<br /> 
            </div>
            <br />
            <asp:TextBox ID="txtRecords" runat="server" CssClass="auto-style13" Height="296px" ReadOnly="True" TextMode="MultiLine" Width="941px" Wrap="False"></asp:TextBox>
        </asp:Panel>
</asp:Content>
