<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Drafts.aspx.cs" Inherits="Web.Common.Drafts" %>

<%@ Register Src="../ASCX/Drafts.ascx" TagName="Drafts" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Training.ascx" TagName="Training" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc3" %>
<%@ Register Src="../ASCX/MessageMainPanel.ascx" TagName="MessageMainPanel" TagPrefix="uc4" %>
<%@ Register Src="../ASCX/Events.ascx" TagName="Events" TagPrefix="uc5" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc4:MessageMainPanel ID="panel" runat="server" />
    <br />
    <br />
    <uc3:SurveyList ID="surveylist" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ctphMiddle" runat="server">
    <uc1:Drafts ID="ucDraft" runat="server" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ctphRight" runat="server">
    <uc5:Events runat="server" ID="events" />
    <br />
    <br />
    <uc2:Training runat="server" ID="training" />
</asp:Content>
