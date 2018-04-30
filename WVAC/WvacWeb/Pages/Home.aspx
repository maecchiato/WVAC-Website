<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WvacWeb.Pages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="Who We Are" CssClass ="wwa"></asp:Label>
        <br />
        </div>
    <hr style="width:850px" />
    
    <br />
    <div style="text-align:center">
    <asp:Label ID="Label2" runat="server" Text="We position the affiliate in the community by establishing" CssClass="sub"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="a sustainable relationship with various sectors" CssClass="sub"></asp:Label>
    </div>
    <br />
    <br />
    <div class="table">
    <table style="height:120px">
        <tr>
            <td rowspan="4" class="row" style="text-align: center">
                VISION<br />
                Always work in expanding the<br />
                capacities and service of
                <br />
                the alliances</td>
        </tr>
        <tr>
            <td rowspan="4" class="row" style="text-align: center">
                MISSION<br />
                To assist the affliates develop themselves
                <br />
                through entreprenuership and<br />
                capacity building</td>
        </tr>
        <tr>
            <td rowspan="4" class="row" style="text-align: center">
                CORE VALUES<br />
                W - Wellness<br />
                V- Voluntariness<br />
                A - Autonomy<br />
                C- Consensus</td>
         </tr>   
    </table>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
