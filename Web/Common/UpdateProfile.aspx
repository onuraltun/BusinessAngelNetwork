<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="UpdateProfile.aspx.cs" Inherits="Web.UpdateProfile" %>

<%@ Register Src="../ASCX/Member.ascx" TagName="Member" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphLeft" runat="server">
</asp:Content>
<asp:Content ID="ctphMiddle" ContentPlaceHolderID="ctphMiddle" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal ID="ltUpdateProfileHeader" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    <uc1:Member ID="Member1" runat="server" TaskName="Update" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphRight" runat="server">
</asp:Content>
