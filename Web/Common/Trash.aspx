<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Trash.aspx.cs" Inherits="Web.Common.Trash" %>
<%@ Register src="../ASCX/TrashMail.ascx" tagname="TrashMail" tagprefix="uc1" %>
<%@ Register src="../ASCX/MessageMainPanel.ascx" tagname="MessageMainPanel" tagprefix="uc2" %>
<%@ Register src="../ASCX/SurveyList.ascx" tagname="SurveyList" tagprefix="uc3" %>
<%@ Register src="../ASCX/Events.ascx" tagname="Events" tagprefix="uc4" %>
<%@ Register src="../ASCX/Training.ascx" tagname="Training" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc2:MessageMainPanel ID="panel" runat="server" />
    <br />
    <br />
    <uc3:SurveyList ID="surveylist" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ctphMiddle" runat="server">
    <uc1:TrashMail ID="trashhh" runat="server" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ctphRight" runat="server">
    <uc4:events runat="server" id="events" />
    <br />
    <br />
    <uc5:training runat="server" id="training" />
</asp:Content>
