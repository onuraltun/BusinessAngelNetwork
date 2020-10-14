<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="ViewMember.aspx.cs" Inherits="Web.Admin.ViewMember" %>

<%@ Register Src="../ASCX/ViewMember.ascx" TagName="Member" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
<uc1:Member runat="server" ID="Member1" TaskName="ViewMember"  />
</asp:Content>
