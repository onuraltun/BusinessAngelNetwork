<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<%@ Register Src="../ASCX/Member.ascx" TagName="Member" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphLeft" runat="server">
</asp:Content>
<asp:Content ID="ctphMiddle" ContentPlaceHolderID="ctphMiddle" runat="server">
    <asp:Panel runat="server" ID="pnlMemberShipTR">
        <table height="350" width="100%">
            <tr align="center">
                <td valign="middle">
                    <table id="Table_01" width="386" height="213" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="/images/banner/kayit_01.png" width="386" height="35" alt="">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton runat="server" ID="img1" OnClick="Click" ImageUrl="/images/banner/kayit_02.png" Width="386"
                                    Height="49" CommandArgument="5" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton runat="server" ID="img2" OnClick="Click" ImageUrl="/images/banner/kayit_03.png" Width="386"
                                    Height="49" CommandArgument="1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton runat="server" ID="img3" OnClick="Click" ImageUrl="/images/banner/kayit_04.png" Width="386"
                                    Height="48" CommandArgument="6" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/banner/kayit_05.png" width="386" height="32" alt="">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Literal runat="server" ID="exlblPage" Visible="false"></asp:Literal>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMemberShipEng">
        <table height="350" width="100%">
            <tr align="center">
                <td valign="middle">
                    <table id="Table1" width="386" height="212" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="/images/banner/register_01.png" width="386" height="35" alt="">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton runat="server" ID="img4" OnClick="Click" ImageUrl="/images/banner/register_02.png" Width="386"
                                    Height="49" CommandArgument="5" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton runat="server" ID="img5" OnClick="Click" ImageUrl="/images/banner/register_03.png" Width="386"
                                    Height="49" CommandArgument="1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton runat="server" ID="img6" OnClick="Click" ImageUrl="/images/banner/register_04.png" Width="386"
                                    Height="49" CommandArgument="6" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/banner/register_05.png" width="386" height="30" alt="">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <uc1:Member Visible="false" ID="Member1" runat="server" TaskName="Register" MemberShipTypeProperty="Entrepreneur" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphRight" runat="server">
</asp:Content>
