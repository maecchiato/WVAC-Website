<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WvacWeb.Pages.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-top: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="text-align:center">
    <asp:Label ID="Label1" runat="server" CssClass="heading" Text="MEMBERSHIP MANAGEMENT"></asp:Label>
    </div>
    <asp:TextBox ID="txtMemAccs" runat="server" CssClass="auto-style2" Height="293px" TextMode="MultiLine" Width="1059px" Wrap="False" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <br />

    <br />

    <br />
    <br />
        <div style="text-align:center">
    <asp:Label ID="txtLoanAccs" runat="server" CssClass="heading" Text="LOAN MANAGEMENT"></asp:Label>
            </div>
    <br />
    <br />
    <br />
    <asp:TextBox ID="txtLoamProfile" runat="server" CssClass="auto-style2" Height="293px" TextMode="MultiLine" Width="1059px" Wrap="False" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
</asp:Content>
