<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
                <asp:ListItem>Париж</asp:ListItem>
                <asp:ListItem>Стокгольм</asp:ListItem>
                <asp:ListItem>Рим</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Один</asp:ListItem>
                <asp:ListItem>С друзьями</asp:ListItem>
                <asp:ListItem>С родителями</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Мущчина</asp:ListItem>
                <asp:ListItem>Женщина</asp:ListItem>
                <asp:ListItem>X</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Подтвердить" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
