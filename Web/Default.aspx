<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<%@ Register Src="ASCX/Maillist.ascx" TagName="Maillist" TagPrefix="uc1" %>
<%@ Register Src="ASCX/TellAFriend.ascx" TagName="TellAFriend" TagPrefix="uc2" %>
<%@ Register Src="ASCX/Events.ascx" TagName="Events" TagPrefix="uc3" %>
<%@ Register Src="ASCX/Poll.ascx" TagName="Poll" TagPrefix="uc4" %>
<%@ Register Src="ASCX/News.ascx" TagName="News" TagPrefix="uc5" %>
<%@ Register Src="ASCX/Article.ascx" TagName="Article" TagPrefix="uc6" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <center>
        <table id="Table_01" width="960" border="0" cellpadding="0" cellspacing="0">
            <tr valign="top">
                <td width="20" height="240">
                    <img src="./images/template/spacer.gif" width="20" height="240" alt="">
                </td>
                <td colspan="2" width="310">
                    <uc6:Article ID="Article1" runat="server" width="310px" height="240px" />
                </td>
                <td width="20" height="240">
                    <img src="./images/template/spacer.gif" width="20" height="240" alt="">
                </td>
                <td colspan="2" width="350">
                    <uc5:News runat="server" ID="news" />
                </td>
                <td width="20" height="240">
                    <img src="./images/template/spacer.gif" width="20" height="240" alt="">
                </td>
                <td colspan="2" width="200">
                    <uc3:Events ID="Events1" runat="server" />
                </td>
                <td width="20" height="240">
                    <img src="./images/template/spacer.gif" width="20" height="240" alt="">
                </td>
            </tr>
        </table>
        <table align="left" id="Table1" width="960" border="0" cellpadding="0"
            cellspacing="0">
            <tr>
                <td colspan="4" width="960" height="15">
                    <img width="940" src="./images/template/home-sliced-tr_10.gif" alt="">
                </td>
            </tr>
            <tr>
                <td width="246">
                    <uc1:Maillist ID="Maillist1" runat="server" width="246" />
                </td>
                <td width="221">
                    <a href="/Common/Contact.aspx">
                        <img style="border: 0" runat="server" id="imgContact" src="/images/template/2t.png"
                            alt="" width="221">
                    </a>
                </td>
                <td width="182">
                    <uc2:TellAFriend ID="TellAFriend1" runat="server" />
                </td>
                <td width="222">
                    <a href="/Common/Survey.aspx">
                        <img width="222" style="border: 0" runat="server" id="imgSurvey" src="/images/template/4t.png"
                            alt="">
                    </a>
                </td>
            </tr>
        </table>
        
    </center>
</asp:Content>
