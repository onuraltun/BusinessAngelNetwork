<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyList.ascx.cs"
    Inherits="Web.ASCX.SurveyList" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltSurveyList"></asp:Literal>
        </td>
    </tr>
</table>
<table width="100%">
    <tr>
        <td align="right">
            <img src="/images/up.jpg" onmouseover="javascript:document.all.mqSurveys.direction='down';" onmouseout="javascript:document.all.mqSurveys.start();" />
            <table id="tblScrolling" style="text-align: left" cellspacing="1" cellpadding="1"
                width="100%" border="0" runat="server" height="100px">
                <tr id="rowScrolling" runat="server">
                </tr>
            </table>
            <img src="/images/down.jpg" onmouseover="javascript:document.all.mqSurveys.direction='up'" onmouseout="javascript:document.all.mqSurveys.start();" />
        </td>
    </tr>
</table>
