<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web.Supervisor.Default" %>

<%@ Register Src="../ASCX/ViewMember.ascx" TagName="ViewMember" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Poll.ascx" TagName="Poll" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/MessageMainPanel.ascx" TagName="Inbox" TagPrefix="uc3" %>
<%@ Register Src="../ASCX/Events.ascx" TagName="Events" TagPrefix="uc4" %>
<%@ Register Src="../ASCX/Training.ascx" TagName="Training" TagPrefix="uc5" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc3:Inbox ID="mail" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ctphRight" runat="server">
    <a href="/Common/ChangePassword.aspx">
        <asp:Literal runat="server" ID="ltSettings"></asp:Literal></a><br />
    <br />
    <a href="Event.aspx?t=1">
        <asp:Literal runat="server" ID="ltEventPanel"></asp:Literal></a><br />
    <br />
    <a href="Event.aspx?t=2">
        <asp:Literal runat="server" ID="ltTrainingPanel"></asp:Literal></a><br />
    <br />
    <a href="/Supervisor/Projects.aspx">
        <asp:Literal runat="server" ID="ltProjectPanel"></asp:Literal></a><br />
    <br />
    <a href="ProjectAcception.aspx">
        <asp:Literal runat="server" ID="ltProjectsAwatingAcception"></asp:Literal></a><br />
    <br />
    <a href="Maillist.aspx">
        <asp:Literal runat="server" ID="ltMaillistPanel"></asp:Literal></a><br />
    <br />
    <a href="Upload.aspx">
        <asp:Literal runat="server" ID="ltUploadPanel"></asp:Literal></a><br />
    <br />
    <a href="Page.aspx?t=1">
        <asp:Literal runat="server" ID="ltPagePanel"></asp:Literal></a><br />
    <br />
    <a href="Page.aspx?t=2">
        <asp:Literal runat="server" ID="ltNewsPanel"></asp:Literal></a><br />
    <br />
    <a href="Page.aspx?t=3">
        <asp:Literal runat="server" ID="ltArticlePanel"></asp:Literal></a><br />
    <br />
    <a href="Page.aspx?t=4">
        <asp:Literal runat="server" ID="ltPressPanel"></asp:Literal></a><br />
    <br />
    <a href="Member.aspx">
        <asp:Literal runat="server" ID="ltMemberPanel"></asp:Literal></a><br />
    <br />
    <a href="Menu.aspx">
        <asp:Literal runat="server" ID="ltMenuPanel"></asp:Literal></a><br />
    <br />
    <a href="Dictionary.aspx">
        <asp:Literal runat="server" ID="ltDictionaryPanel"></asp:Literal></a><br />
    <br />
    <a href="Log.aspx">
        <asp:Literal runat="server" ID="ltLogPanel"></asp:Literal></a><br />
    <br />
    <a href="/Supervisor/Survey.aspx">
        <asp:Literal runat="server" ID="ltSurveyPanel"></asp:Literal></a><br />
    <br />
    <a href="/Common/Logout.aspx">
        <asp:Literal runat="server" ID="ltLogout"></asp:Literal></a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ctphMiddle" runat="server">
    <uc1:ViewMember ID="ViewMember1" runat="server" TaskName="My" />
</asp:Content>
