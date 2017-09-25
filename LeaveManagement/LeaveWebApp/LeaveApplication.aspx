<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LeaveApplication.aspx.cs" Inherits="LeaveWebApp.LeaveApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style6
    {
        width: 288px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    <tr>
        <td class="style6">
            <asp:Label ID="Label2" runat="server" Text="EmployeeId"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="Label3" runat="server" Text="StartDate(mm/dd/yyyy)"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtStartDate" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtStartDate" ControlToValidate="txtEndDate" 
                ErrorMessage="CompareValidator" Type="Date">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="Label4" runat="server" Text="EndDate(mm/dd/yyyy)"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtEndDate" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="Label5" runat="server" Text="Reason"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlReason" runat="server" DataSourceID="SqlDataSource1" 
                DataTextField="Reason" DataValueField="Reason">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Leave %>" 
                SelectCommand="SELECT [Reason] FROM [tblReason]"></asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="ddlReason" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="Label6" runat="server" Text="Comments"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Submit leave" 
                onclick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="51px" />
        </td>
    </tr>
</table>
</asp:Content>
