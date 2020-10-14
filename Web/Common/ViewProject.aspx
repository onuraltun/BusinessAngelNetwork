<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="ViewProject.aspx.cs" Inherits="Web.ViewProject" %>

<%@ Register Src="../ASCX/ViewProject.ascx" TagName="ViewProject" TagPrefix="uc1" %>
<asp:Content ID="ctphMiddle" ContentPlaceHolderID="ctphTable" runat="server">
    <uc1:ViewProject ID="ViewProject1" runat="server" />
</asp:Content>
