<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="ViewMember.aspx.cs" Inherits="Web.ViewMember" %>

<%@ Register Src="../ASCX/ViewMember.ascx" TagName="ViewMember" TagPrefix="uc1" %>
<asp:Content ID="ctphMiddle" ContentPlaceHolderID="ctphTable" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal ID="ltViewProfileHeader" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    <uc1:ViewMember ID="ViewMember1" runat="server" TaskName="ReadOnly" />
</asp:Content>
