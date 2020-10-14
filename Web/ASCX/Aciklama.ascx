<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Aciklama.ascx.cs" Inherits="Web.ASCX.Aciklama" %>
<asp:TextBox ID="txtAciklama" runat="server" Height="104px" TextMode="MultiLine"
    Width="90%"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="reftxtAciklama" runat="server" 
    ControlToValidate="txtAciklama" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>

