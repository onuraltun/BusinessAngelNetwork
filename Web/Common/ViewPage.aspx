<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="ViewPage.aspx.cs" Inherits="Web.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <table width="100%" cellpadding="10" cellspacing="10">
        <tr>
            <td style="text-align: left;">
                <asp:Literal runat="server" ID="exlblTitle"></asp:Literal>
                <asp:Literal runat="server" ID="exlblPage"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
