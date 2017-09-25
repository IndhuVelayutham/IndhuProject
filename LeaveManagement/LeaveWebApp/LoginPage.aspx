<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LeaveWebApp.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style6
    {
        width: 126px;
    }
    .style7
    {
        width: 175px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    <tr>
        <td class="style6">
            <asp:Label ID="Label2" runat="server" Text="UserId"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtUserId" ErrorMessage="UserId is Must">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="Invalid UserId" ControlToValidate="txtUserId" 
                Display="Dynamic" ValidationExpression="\d{6}">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPassword" ErrorMessage="Password is must">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                style="height: 26px" Text="Login" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
