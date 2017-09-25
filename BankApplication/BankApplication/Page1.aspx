<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="BankApplication.Page1" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
   
   

         <table style="width:100%;">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>

  
   
   

         <table style="width: 31%; height: 128px;">
            <td class="style7" style="width: 256px">
                <asp:Label ID="Label3" runat="server" Text="User Name:" BackColor="#FFCC00"></asp:Label>
            </td>
            <td class="style4" colspan="2">
                <asp:TextBox ID="txtUName" runat="server" Width="130px" BackColor="#CCCCFF"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtUName" ErrorMessage="*" ForeColor="#FF6600" 
                                                        ToolTip="User Name Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style9" style="width: 256px">
                <asp:Label ID="Label4" runat="server" Text="Password:" BackColor="#FFFFCC"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="130px" 
                    BackColor="#CCFFFF"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtPwd" ErrorMessage="*" ForeColor="#FF6600" 
                                                        ToolTip="Password Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style9" style="width: 256px">
                &nbsp;</td>
            <td class="style10" style="width: 197px">
                &nbsp;</td>
            <td style="width: 112px">
                <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                                                        style="margin-left: 0px" Text="LOGIN" 
                    Width="57px" BackColor="#CCCC00" />
            </td>
        </tr>
    </table>
  

        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15" style="height: 396px">
        </td>
        <td class="style15" style="height: 396px">
        </td>
        <td class="style15" style="height: 396px">
        </td>
    </tr>
</table>
  

</asp:Content>