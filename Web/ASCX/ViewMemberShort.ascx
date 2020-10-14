<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ViewMemberShort.ascx.cs"
    Inherits="Web.ASCX.ViewMemberShort" %>
<link rel="stylesheet" type="text/css" href="~/App_Themes/MersinBAN/ui.all.css" media="screen" />
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0" Visible="false">
    <asp:View ID="vKayitGoster" runat="server">
        <table width="100%">
            <tr>
                <td>
                    <asp:Image runat="server" ID="imgMember" />
                </td>
                <td>
                    <table>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltTitle" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltName" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltNAME" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltSurname" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltSURNAME" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:Literal ID="ltCompanyName" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="exltCOMPANYNAME" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="ltPosition" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="exltPOSITION" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr id="trAmount" runat="server">
                <td>
                    <asp:Literal ID="ltAmountsPerInvestments" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="exltAMOUNTSPERINVESTMENT" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr id="trInvestorType" runat="server">
                <td>
                    <asp:Literal ID="ltInvestorType" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="exltInvestorType" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>