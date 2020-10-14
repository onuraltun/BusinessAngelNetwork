<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="ForgottenPassword.aspx.cs" Inherits="Web.ForgottenPassword" %>

<%@ Register Src="../ASCX/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Events.ascx" TagName="Events" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/Training.ascx" TagName="Training" TagPrefix="uc3" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc1:SurveyList ID="SurveyList1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphMiddle" runat="server">
    <table class="belgeHeader">
        <tr>
            <td class="labels">
                <asp:Literal ID="ltEmail" runat="server"></asp:Literal>
            </td>
            <td class="inputs">
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labels">
                &nbsp;
            </td>
            <td class="inputs">
                <asp:Button ID="btnSend" runat="server" CssClass="btnKritik" OnClick="btnSend_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="ctphRight" ContentPlaceHolderID="ctphRight" runat="server">
    <uc2:Events ID="Events1" runat="server" />
    <br />
    <br />
    <uc3:Training ID="Training1" runat="server" />
</asp:Content>
