<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewBusinessIdeas.ascx.cs" Inherits="Web.ASCX.NewBusinessIdeas" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:LinkButton runat="server" ID="ltNewBusinessIdeasHeader" 
                onclick="ltNewBusinessIdeasHeader_Click"></asp:LinkButton>
        </td>
    </tr>
</table>
<table width="100%">
    <tr>
        <td align="right">
            <img src="/images/up.jpg" onmouseover="javascript:document.all.mqBusinessIdeas.direction='down';" onmouseout="javascript:document.all.mqBusinessIdeas.start();" />
            <table id="tblScrolling" cellspacing="1" cellpadding="1" width="100%" border="0"
                runat="server" height="150px">
                <tr id="rowScrolling" runat="server">
                </tr>
            </table>
            <img src="/images/down.jpg" onmouseover="javascript:document.all.mqBusinessIdeas.direction='up'" onmouseout="javascript:document.all.mqBusinessIdeas.start();" />
        </td>
    </tr>
</table>
