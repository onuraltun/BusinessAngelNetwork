<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="SentMessages.aspx.cs" Inherits="Web.Entrepreneur.SentMessages" %>

<%@ Register Src="../ASCX/MessageMainPanel.ascx" TagName="MessageMainPanel" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc3" %>
<%@ Register Src="../ASCX/Events.ascx" TagName="Events" TagPrefix="uc4" %>
<%@ Register Src="../ASCX/Training.ascx" TagName="Training" TagPrefix="uc5" %>
<%@ Register Src="../ASCX/SentMessages.ascx" TagName="SentMessages" TagPrefix="uc1" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc2:MessageMainPanel ID="panel" runat="server" />
    <br />
    <br />
    <uc3:SurveyList ID="surveylist" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ctphMiddle" runat="server">
    <uc1:SentMessages ID="SentMessages1" runat="server" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ctphRight" runat="server">
    <uc4:Events runat="server" ID="events" />
    <br />
    <br />
    <uc5:Training runat="server" ID="training" />
</asp:Content>
