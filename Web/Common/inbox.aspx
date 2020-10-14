<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="inbox.aspx.cs" Inherits="Web.Common.inbox" %>

<%@ Register Src="../ASCX/Inbox.ascx" TagName="Inbox" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/MessageMainPanel.ascx" TagName="MessageMainPanel" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc3" %>
<%@ Register src="../ASCX/Events.ascx" tagname="Events" tagprefix="uc4" %>
<%@ Register src="../ASCX/Training.ascx" tagname="Training" tagprefix="uc5" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc2:MessageMainPanel ID="panel" runat="server" />
    <br />
    <br />
    <uc3:SurveyList ID="surveylist" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ctphMiddle" runat="server">
    <uc1:Inbox ID="inboxx" runat="server" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ctphRight" runat="server">
    <uc4:events runat="server" id="events" />
    <br />
    <br />
    <uc5:training runat="server" id="training" />
</asp:Content>
