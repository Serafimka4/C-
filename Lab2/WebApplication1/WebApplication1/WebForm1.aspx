<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Имя<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Ошибка ввода имени">Обязательное поле ввода</asp:RequiredFieldValidator>
            <br />
            Пароль<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Ошибка ввода пароля" ValidationExpression="\w{8,}">Пароль должен содержать не менее 8 символов</asp:RegularExpressionValidator>
            <br />
            Подтвердите пароль<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="Ошибка подтверждения пароля">Не верно введен пароль</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Ошибка подтверждения пароля">Обязательное поле ввода</asp:RequiredFieldValidator>
            <br />
            email<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Ошибка ввода email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Не правильно введен email</asp:RegularExpressionValidator>
            <br />
            Возраст<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="Ошибка ввода возраста" MaximumValue="65" MinimumValue="18">Ваш возраст не подходит</asp:RangeValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Отправить" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="65px" />
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
