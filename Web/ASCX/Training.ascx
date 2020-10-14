<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Training.ascx.cs" Inherits="Web.ASCX.Training" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltTrainingsHeader"></asp:Literal>
        </td>
    </tr>
</table>
<table width="100%">
    <tr>
        <td align="right">
            <img src="/images/up.jpg" onmouseover="javascript:document.all.mqTrainings.direction='down';" onmouseout="javascript:document.all.mqTrainings.start();" />
            <table id="tblScrolling" cellspacing="1" cellpadding="1" width="100%" border="0"
                runat="server" height="150px">
                <tr id="rowScrolling" runat="server">
                </tr>
            </table>
            <img src="/images/down.jpg" onmouseover="javascript:document.all.mqTrainings.direction='up'" onmouseout="javascript:document.all.mqTrainings.start();" />
        </td>
    </tr>
</table>
