<%@ Page Title="ThinClientApp" Language="C#" MasterPageFile="~/ShopSite.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="ThinClientApp.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Welcome Customer</h2>
    <p>
        <asp:Login ID="CustomerLogin" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/Protected/Order.aspx" DisplayRememberMe="False" FailureText="Authentication failed" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="CustomerLogin_Authenticate" PasswordLabelText="Password" TextLayout="TextOnTop" TitleText="" UserNameLabelText="Customer ID" >
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </p>
</asp:Content>
