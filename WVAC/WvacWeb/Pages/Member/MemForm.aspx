<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MemForm.aspx.cs" Inherits="WvacWeb.UserForms.MemForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            background-color: rgba(222, 168, 127, 0.80);
            color: black;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<br />
<div style="text-align:center">
<asp:Label ID="Label1" runat="server" Text="APPLICATION FOR MEMBERSHIP" CssClass="heading"></asp:Label>
</div>
<br />
<br />
<asp:Panel ID="Panel1" runat="server" BorderStyle="Double" CssClass="panelAcc" Width="997px" style="padding-left: 50px">
    <br />
    Personal Information<br />
    <br />
    <asp:Label runat="server" Text="First Name: "></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Age:&nbsp;
    <asp:TextBox ID="txtAge" runat="server" Width="30px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Address: "></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server" Width="449px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Civil Status:
    <asp:DropDownList ID="ddCStat" runat="server">
        <asp:ListItem>Married</asp:ListItem>
        <asp:ListItem>Single</asp:ListItem>
    </asp:DropDownList>
    .&nbsp;&nbsp;&nbsp;<br />
    <br />
    &nbsp;<asp:Label ID="Label6" runat="server" Text="Gender:"></asp:Label>
    <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" OnCheckedChanged="rbMale_CheckedChanged" Text="Male" />
    <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" OnCheckedChanged="rbFemale_CheckedChanged" Text="Female" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Contact Number:
    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Text="E-Mail Address"></asp:Label>
    <asp:TextBox ID="txtEmailAdd" runat="server" TextMode="Email"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Submit" CssClass="button" Width="143px"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="txtResult" runat="server"></asp:Label>
    <br />
    <br />
</asp:Panel>
    <br />
<asp:Panel ID="Panel2" runat="server" BorderStyle="Double" Height="576px" CssClass="row">
    <br />
    <asp:Label ID="Label12" runat="server" Text="Please enter your user ID: "></asp:Label>
    <asp:TextBox ID="txtUID" runat="server" Width="31px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server" Text="Number of Shares:   "></asp:Label>
&nbsp;
    <asp:TextBox ID="txtShares" runat="server" Width="40px"></asp:TextBox>
    &nbsp; (Note: Each share is valued PHP1,000; must not be less than 40 share)<br />
    <br />
    Mode of Payment:&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddModeOfP" runat="server">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem Value="Lump Sum">Lump Sum</asp:ListItem>
        <asp:ListItem>Installment</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type of Installment:&nbsp;
    <asp:DropDownList ID="ddlInstallment" runat="server" OnSelectedIndexChanged="ddlInstallment_SelectedIndexChanged" ForeColor="Black">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Monthly</asp:ListItem>
        <asp:ListItem>Quarterly</asp:ListItem>
        <asp:ListItem>Yearly</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label11" runat="server" Text="Reminder:"></asp:Label>
    &nbsp;Pay the balance within 3 years, not less than PHP10,000 a year<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Official membership will be granted after full payment)<br />
    <br />
    <br />
    Note: In order to proceed, you are required to pay a downpayment not less than PHP10,000<br />
    <br />
    Payment:
    <asp:TextBox ID="txtdPayment" runat="server" Width="114px"></asp:TextBox>
    &nbsp;&nbsp; (Note: Kindly include PHP1000 for membership fee.)<br />
    <br />
    <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" Height="41px" CssClass="button" Width="90px"/>
    <br />
    <br />
    <asp:TextBox ID="txtRezult" runat="server" TextMode="MultiLine" Height="142px" ReadOnly="True" Width="473px"></asp:TextBox>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Panel>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
</asp:Content>
