<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="BankApplication.page2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%;">
        <tr>
            <td style="width: 323px">
                <asp:Label ID="Label5" runat="server" Text="Welcome To SBI BANK" 
                    BackColor="White"></asp:Label>
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </td>
            <td style="width: 833px">
                &nbsp;</td>
            <td style="width: 93px">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page1.aspx">Log Out</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 323px">
                <br />
                <br />
            </td>
            <td style="width: 833px">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 93px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 323px">
                &nbsp;</td>
            <td style="width: 833px">
                <asp:Button ID="Button1" runat="server" 
                    Text="Account Summary" BackColor="#CC9900" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="width: 93px">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
