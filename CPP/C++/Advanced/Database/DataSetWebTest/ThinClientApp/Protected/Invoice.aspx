<%@ Page Title="" Language="C#" MasterPageFile="~/ShopSite.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ThinClientApp.Protected.Invoice" %>
<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customer <asp:Label ID="CustomerIdLabel" runat="server" /> Invoice</h2>
    <p>
        <asp:GridView ID="InvoiceGridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="InvoiceDataSource" ForeColor="Black" >
            <Columns>
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                <asp:BoundField DataField="ProductNo" HeaderText="ProductNo" SortExpression="ProductNo" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="InvoiceDataSource" runat="server" OldValuesParameterFormatString="original_{0}" OnSelected="InvoiceDataSource_Selected" SelectMethod="GetData" TypeName="ThinClientApp.Models.ShopDataSetTableAdapters.InvoiceTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="CustomerIdLabel" Name="customerId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <asp:Label ID="PaymentLabel" runat="server" />
    <p>
        <asp:LinkButton ID="LogoutLinkButton" Text="Log Out" OnClick="LogoutLinkButton_Click" runat="server" />
    </p>
</asp:Content>
