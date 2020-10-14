<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Events.ascx.cs" Inherits="Web.ASCX.Events" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltEventsHeader"></asp:Literal>
        </td>
    </tr>
</table>
<asp:Calendar ID="clAktiviteler" runat="server" NextMonthText="&gt;"
    OnDayRender="clAktiviteler_DayRender" PrevMonthText="&lt;" SelectMonthText=""
    SelectWeekText="" UseAccessibleHeader="False" BorderStyle="Dotted" OnSelectionChanged="clAktiviteler_SelectionChanged">
    <DayStyle BorderWidth="0px" Height="23px" Width="23px" HorizontalAlign="Right" VerticalAlign="Bottom"
        Font-Size="Smaller" ForeColor="#666666" />
    <DayHeaderStyle BorderColor="#003399" BorderStyle="None" BorderWidth="1px" Font-Size="Smaller" />
    <TitleStyle BackColor="White" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
        ForeColor="#3366ff" Font-Size="Smaller" Font-Bold="true" />
</asp:Calendar>
