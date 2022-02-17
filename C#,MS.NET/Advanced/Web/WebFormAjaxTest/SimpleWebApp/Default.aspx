<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SimpleWebApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <p>
                    <asp:Label ID="GreetLabel" runat="server" Text="Welcome Visitor" Font-Size="X-Large" Font-Bold="True"></asp:Label>
                </p>
                <p>
                    <asp:Label Text="Person: " runat="server" />
                    <asp:TextBox ID="PersonTextBox" runat="server" />
                </p>
                <p>
                    <asp:Label Text="Period: " runat="server" />
                    <asp:DropDownList ID="PeriodDropDownList" runat="server">
                        <asp:ListItem Text="Night" />
                        <asp:ListItem Text="Morning" />
                        <asp:ListItem Text="Afternoon" />
                        <asp:ListItem Text="Evening" />
                    </asp:DropDownList>
                </p>
                <asp:Button ID="GreetButton" Text="Greet" OnClick="GreetButton_Click" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
