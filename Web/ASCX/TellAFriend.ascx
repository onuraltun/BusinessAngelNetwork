<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TellAFriend.ascx.cs"
    Inherits="Web.ASCX.TellAFriend" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:ImageButton runat="server" ID="ibTellAFriend" ImageUrl="/images/template/3t.png"
            Width="221" Height="119" alt="" CommandName="Maillist" OnClick="ibTellAFriend_Click" />
        <asp:Panel runat="server" ID="pnlTellAFriend" Visible="false">
            <asp:Literal ID="lblNameSurnameTell" runat="server"></asp:Literal><br />
            <asp:TextBox runat="server" ID="txtNameSurnameTell" Font-Size="Smaller"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNameSurnameTell"
                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="tellafriend"></asp:RequiredFieldValidator>
            <br />
            <asp:Literal ID="lblEmailTell" runat="server"></asp:Literal><br />
            <asp:TextBox runat="server" ID="txtEmailTell" Font-Size="Smaller"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailTell"
                ErrorMessage="*" SetFocusOnError="True"  ValidationGroup="tellafriend"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailTell"
                ErrorMessage="*" SetFocusOnError="True"  ValidationGroup="tellafriend" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Button runat="server" ID="btnTellAFriend"  ValidationGroup="tellafriend" Text="Ekle" CssClass="btnKaydet" OnClick="btnTellAFriend_Click" />
        </asp:Panel>
        <asp:Literal ID="lblTellAFriendInfo" runat="server" Visible="false" Text="Arkadaşınıza site tanıtım dökümanı gönderildi."></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
