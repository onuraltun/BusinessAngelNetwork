<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="ViewCV.aspx.cs" Inherits="Web.ViewCV" %>

<%@ Register Src="../ASCX/CV.ascx" TagName="CV" TagPrefix="uc1" %>
<asp:Content ID="ctphTable" ContentPlaceHolderID="ctphTable" runat="server">
    <uc1:CV ID="CV1" runat="server" TaskName="ReadOnly" />
</asp:Content>
