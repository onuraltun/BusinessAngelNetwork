<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Maillist.ascx.cs" Inherits="Web.ASCX.Maillist" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:ImageButton runat="server" ID="ibMaillist" ImageUrl="/images/template/newsletter-tr.png"
            Width="246" Height="119" alt="" CommandName="Maillist" OnClick="ibMaillist_Click" />
        <asp:Panel runat="server" ID="pnlMaillist" Visible="false">
            <asp:Literal ID="lblNameSurname" runat="server"></asp:Literal><br />
            <asp:TextBox runat="server" ID="txtNameSurname" Font-Size="Smaller"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reftxtNameSurname" runat="server" ControlToValidate="txtNameSurname"
                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="maillist"></asp:RequiredFieldValidator>
            <br />
            <asp:Literal ID="lblEmail" runat="server"></asp:Literal><br />
            <asp:TextBox runat="server" ID="txtEmail" Font-Size="Smaller"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reftxtEmail2" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="maillist"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="reftxtEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="maillist" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:Button runat="server" ID="btnMaillist" ValidationGroup="maillist" Text="Ekle" CssClass="btnKaydet" OnClick="btnMaillist_Click" />
        </asp:Panel>
        <asp:Literal ID="lblMaillistInfo" runat="server" Visible="false" Text="Haber listesine eklendiniz"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
