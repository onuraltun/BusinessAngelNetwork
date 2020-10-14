<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Activation.aspx.cs" Inherits="Web.Activation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ctphMiddle" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltActiveMessage" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="ltActivationCode" runat="server"></asp:Literal>
            </td>
            <td>
                <asp:TextBox ID="txtActivationCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnActivate" CssClass="btnKaydet" runat="server" OnClick="btnActivate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
