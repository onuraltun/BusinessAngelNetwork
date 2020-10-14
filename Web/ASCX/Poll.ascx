<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Poll.ascx.cs" Inherits="Web.ASCX.Poll" %>

<script language="javascript" type="text/javascript">
    function AnketSonuclari() {
        var popwin;
        var wtop = (screen.height - 150) / 2;
        var wleft = (screen.width - 450) / 2;
        popwin = window.open('/Common/PollResults.aspx', "AnketSonuclari", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,left=" + wleft + ",top=" + wtop + ",width=450,height=150,directories=no,menubar=no,resizable=yes,copyhistory=no,fullscreen=no,scrollbars=yes");
        popwin.focus();
        return false;
    }
</script>

<table class="belgeHeader" width="100%">
    <tr valign="top">
        <td style="text-align: left">
            <span style="font-size: 6pt"><span style="font-family: Tahoma">&gt;&gt;<span style="color: white"><strong></strong></span></span></span><asp:Literal
                ID="ltPoll" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr valign="top">
        <td style="text-align: left;">
            <asp:Label ID="exlblAnketKonusu" runat="server" Font-Bold="False" Font-Size="9px"></asp:Label>
        </td>
    </tr>
    <tr valign="top">
        <td style="text-align: left">
            <asp:RadioButtonList ID="exrblAnket" runat="server">
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr valign="top" class="inputs">
        <td style="text-align: left">
            <asp:Button ID="btnVote" runat="server" CssClass="btnKritik" OnClick="btnVote_Click" />
            &nbsp;<asp:Button ID="lbSonuclar" runat="server" CssClass="btn" OnClientClick="javascript:return AnketSonuclari();" />
        </td>
    </tr>
</table>
