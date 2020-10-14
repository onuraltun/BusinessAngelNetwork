<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Default.aspx.cs" Inherits="Web.Investor_Default" %>

<%@ Register Src="../ASCX/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/MessageMainPanel.ascx" TagName="Inbox" TagPrefix="uc3" %>
<%@ Register Src="../ASCX/Events.ascx" TagName="Events" TagPrefix="uc4" %>
<%@ Register Src="../ASCX/Training.ascx" TagName="Training" TagPrefix="uc5" %>
<%@ Register Src="../ASCX/Article.ascx" TagName="Article" TagPrefix="uc11" %>
<%@ Register Src="../ASCX/ViewMember.ascx" TagName="ViewMember" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/NewBusinessIdeas.ascx" TagName="NewBusinessIdeas" TagPrefix="uc12" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphLeft" runat="server">
    <asp:Panel runat="server" ID="pnlGuestLeft">
        <uc11:Article ID="Article1" runat="server" width="216px" height="261px" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlMemberLeft">
        <uc3:Inbox ID="Inbox1" runat="server" />
        <uc12:NewBusinessIdeas runat="server" ID="NewBusinessIdeas1" />
    </asp:Panel>
    <uc2:SurveyList ID="SurveyList1" runat="server" />
</asp:Content>
<asp:Content ID="ctphMiddle" ContentPlaceHolderID="ctphMiddle" runat="server">
    <asp:Panel runat="server" ID="pnlMemberMiddle">
        <uc1:ViewMember ID="ViewMember1" runat="server" TaskName="My" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlGuestMiddle">
        <asp:Literal runat="server" ID="exltPage"></asp:Literal>
    </asp:Panel>
</asp:Content>
<asp:Content ID="ctphRight" ContentPlaceHolderID="ctphRight" runat="server">
    <uc4:Events runat="server" ID="events" />
    <br />
    <br />
    <uc5:Training runat="server" ID="training" />
</asp:Content>
