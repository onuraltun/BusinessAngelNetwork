<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Member.aspx.cs" Inherits="Web.Admin.Member" %>

<%@ Register Src="../ASCX/Member.ascx" TagName="Member" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
<uc1:Member runat="server" ID="Member1" TaskName="Admin" />
</asp:Content>
