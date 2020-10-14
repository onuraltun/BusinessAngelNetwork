<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article.ascx.cs" Inherits="Web.ASCX.Article" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltArticleHeader"></asp:Literal>
        </td>
    </tr>
</table>
<table id="tblScrolling" cellspacing="1" cellpadding="1" width="100%" border="0"
    runat="server" height="150px">
    <tr align="left" id="rowScrolling" runat="server" valign="top">
    </tr>
</table>
