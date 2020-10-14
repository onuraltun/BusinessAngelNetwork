<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WriteMessage.ascx.cs"
    Inherits="Web.ASCX.WriteMessage" %>
<table class="belgeHeader" width="100%">
    <tr>
        <td class="labels">
            <asp:Literal ID="ltKime" runat="server"></asp:Literal>
        </td>
        <td class="inpust">
            <asp:Label ID="exlblTo" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="labels">
            <asp:Literal ID="ltKonu" runat="server"></asp:Literal>
        </td>
        <td class="inpust">
            <asp:TextBox ID="txtKonu" runat="server" MaxLength="50" Width="420px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="exreftxtKonu" runat="server" ControlToValidate="txtKonu"
                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="sendmessage"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="labels">
            <asp:Literal ID="ltMesaj" runat="server"></asp:Literal>
        </td>
        <td class="inpust">
            <asp:TextBox ID="txtMesaj" runat="server" Width="420px" Height="213px" TextMode="MultiLine"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="exreftxtMesaj" runat="server" ControlToValidate="txtMesaj"
                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="sendmessage"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="labels">
            &nbsp;
        </td>
        <td class="inpust">
            <asp:Button ID="btnMesajGonder" runat="server" CssClass="button-mailsend" OnClick="btnMesajGonder_Click"
                ValidationGroup="sendmessage" />
            &nbsp;<asp:Button ID="btnMesajKaydet" runat="server" OnClick="btnMesajKaydet_Click"
                ValidationGroup="sendmessage" CssClass="button-draftmail" />
        </td>
    </tr>
</table>
