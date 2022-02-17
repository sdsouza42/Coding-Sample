<%@ Page Title="ThinClientApp" Language="C#" MasterPageFile="~/ShopSite.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ThinClientApp.Protected.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        div.form {
            background-color: #E3EAEB;
            padding: 0.5em;
            width: 10em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customer <asp:Label ID="CustomerIdLabel" runat="server" /> Place Order</h2>
    <div class="form">
        <div>Product No</div>
        <div>
            <asp:DropDownList ID="ProductNoDropDownList" Width="10em" runat="server" DataSourceID="ProductDataSource" DataTextField="ProductNo" DataValueField="ProductNo" />
            <asp:ObjectDataSource ID="ProductDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="ThinClientApp.Models.ShopDataSetTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
        </div>
    </div>
    <div class="form">
        <div>Quantity</div>
        <div>
            <asp:TextBox ID="QuantityTextBox" Width="10em" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="QuantityTextBox" ErrorMessage="*" runat="server" />
        </div>
    </div>
    <div class="form">
        <asp:Button ID="OrderButton" Text="Order" OnClick="OrderButton_Click" runat="server" />
    </div>
    <p>
        <asp:HyperLink Text="View Invoice" NavigateUrl="~/Protected/Invoice.aspx" runat="server" />
    </p>
</asp:Content>
