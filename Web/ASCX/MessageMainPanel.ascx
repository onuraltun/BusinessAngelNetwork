<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageMainPanel.ascx.cs"
    Inherits="Web.ASCX.MessageMainPanel" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltMessagePanel"></asp:Literal>
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: left">
    <tr id="trNewMail" runat="server" visible="false">
        <td>
            <asp:Literal ID="exltNewMail" runat="server"></asp:Literal>
            <img alt="" src="../images/newmsg.png" style="width: 16px; height: 16px" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lbinbox" runat="server" NavigateUrl="~/Common/inbox.aspx"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lbSendMails" runat="server" NavigateUrl="~/Common/SentMessages.aspx"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lbDrafts" runat="server" NavigateUrl="~/Common/Drafts.aspx"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="lbTrashMails" runat="server" NavigateUrl="~/Common/Trash.aspx"></asp:HyperLink>
        </td>
    </tr>
</table>
