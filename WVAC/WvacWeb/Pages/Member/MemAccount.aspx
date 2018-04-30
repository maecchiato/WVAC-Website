<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MemAccount.aspx.cs" Inherits="WvacWeb.UserPages.MemAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            height: 246px;
            margin-left: 145px;
        }
        .auto-style7 {
            width: 361px;
        }
        .auto-style8 {
            margin-top: 0px;
        }
        .auto-style9 {
            width: 270px;
        }
        .auto-style10 {
            margin-left: 244px;
        }
        .auto-style12 {
            width: 50px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <br />
        <div style="text-align:center">
        <asp:Label ID="Label4" runat="server" Text="MEMBERSHIP ACCOUNT MANAGEMENT" CssClass="heading"></asp:Label>
        </div>
        <br />
        <br />
        <br />
    
<div style="text-align:center" class="auto-style10" >
<table>
    <tr>
        <td class="auto-style9">
            Membership ID:
            <asp:TextBox ID="txtMemId" runat="server" Width="27px"></asp:TextBox>
            &nbsp;<br />
            <asp:Button ID="btnView" runat="server" Text="View Profile" Width="227px" CssClass="button" Height="40px" OnClick="btnView_Click" />
        </td>

         <td class="auto-style7" style="text-align:center">
            <asp:TextBox ID="txtAreaProfile" runat="server" Height="267px" ReadOnly="True" TextMode="MultiLine" Width="350px" Wrap="False"></asp:TextBox>
            <br />
            <br />
        </td> 
    </tr>
</table>
</div>

        <br />
<div style="text-align:center" > 
<table class="auto-style5">
    <tr>
       
        <td class="panelAcc">
        <br/>
        <asp:Label ID="Label5" runat="server" Text="Membership ID:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtId" runat="server" Width="33px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;
            <br/>
            <asp:Label ID="Label1" runat="server" Text="Date Today: "></asp:Label>
            &nbsp;&nbsp;
        <asp:TextBox ID="txtpayDate" runat="server" ForeColor="Gray" TextMode="Date">yyyy-mm-dd</asp:TextBox>

        <asp:Button ID="btnFind" runat="server" CssClass="button" Height="40px" OnClick="btnFind_Click" Text="Get Bill" Width="250px" />
            <br />
        <br/>
            <asp:TextBox ID="txtBill" runat="server" Height="130px" TextMode="MultiLine" Width="240px"></asp:TextBox>
            <br />
        <br/>
        <br/>
        </td>
        <td class="auto-style12">
            </td>
        <td class="panelAcc">
            <br />
        <asp:Label ID="Label2" runat="server" Text="Enter Amount of Payment:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPayment" runat="server" Width="82px"></asp:TextBox>
        &nbsp;&nbsp;
        <br />
         <asp:Button ID="btnPay" runat="server" CssClass="button" Height="40px" OnClick="btnPay_Click" Text="Pay" Width="250px" />
         <br />
        <br />
            <asp:TextBox ID="txtReceipt" runat="server" Height="159px" TextMode="MultiLine"></asp:TextBox>
            <br />
         <br />
        </td>
    </tr>
</table>
</div>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" Height="415px" Width="1054px" BorderStyle="Double" BorderWidth="3px">
            <br />
            <br />
            <div style ="text-align:center">
            <asp:Label ID="Label6" runat="server" CssClass="heading" Text="ACCOUNT RECORDS" ></asp:Label>
            </div>
            <br />
            <br />
            <div style="text-align:center">
            <asp:Label ID="Label7" runat="server" Text="Membership ID:"></asp:Label>
                &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtMemIdRec" runat="server" Width="33px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" Height="40px" OnClick="Button1_Click" Text="View Records" Width="185px" />
                &nbsp;<br /> 
            </div>
            <br />
            <asp:TextBox ID="txtRecords" runat="server" CssClass="auto-style8" Height="171px" TextMode="MultiLine" Width="1045px" Wrap="False"></asp:TextBox>
        </asp:Panel>
<br/>
</asp:Panel>
</asp:Content>
