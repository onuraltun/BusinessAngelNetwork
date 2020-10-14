<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="TemplateHeader.ascx.cs"
    Inherits="Web.ASCX.TemplateHeader" %>
<panel runat="server" id="imgGuest"></panel>
<asp:Panel runat="server" ID="pnlMember" Visible="false">
    <table runat="server" visible="false" id="ent_eng_lo" width="960" height="144" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="11">
                <img src="/images/banner/eng-7_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td class="Welcome" style="background-image: url('/images/banner/eng-7_02.png');" width="296" height="30">
                <asp:Literal runat="server" ID="exltEnt_eng_lo"></asp:Literal>
            </td>
            <td>
                <a href="/Entrepreneur/">
                    <img src="/images/banner/eng-7_03.png" width="69" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/UpdateProfile.aspx">
                    <img src="/images/banner/eng-7_04.png" width="50" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Entrepreneur/Project.aspx">
                    <img src="/images/banner/eng-7_05.png" width="58" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Entrepreneur/MyAdvisor.aspx">
                    <img src="/images/banner/eng-7_06.png" width="78" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Entrepreneur/MyInvestor.aspx">
                    <img src="/images/banner/eng-7_07.png" width="85" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/AttendedEvent.aspx">
                    <img src="/images/banner/eng-7_08.png" width="52" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Survey.aspx">
                    <img src="/images/banner/eng-7_09.png" width="53" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/MySupervisor.aspx">
                    <img src="/images/banner/eng-7_10.png" width="84" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/ChangePassword.aspx">
                    <img src="/images/banner/eng-7_11.png" width="68" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Logout.aspx">
                    <img src="/images/banner/eng-7_12.png" width="67" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="ent_eng_guest" width="960" height="144"
        border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="/images/banner/eng-6_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/banner/eng-6_02.png" width="854" height="30" alt="">
            </td>
            <td>
                <a href="/Common/Login.aspx">
                    <img src="/images/banner/eng-6_03.png" width="106" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="inv_eng_lo" width="960" height="144" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="10">
                <img src="/images/banner/eng-5_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td class="Welcome" style="background-image: url('/images/banner/eng-5_02.png')" width="343" height="30">
                <asp:Literal runat="server" ID="exltInv_eng_lo"></asp:Literal>
            </td>
            <td>
                <a href="/Professional/">
                    <img src="/images/banner/eng-5_03.png" width="59" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/UpdateProfile.aspx">
                    <img src="/images/banner/eng-5_04.png" width="50" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Investor/MyInvestments.aspx">
                    <img src="/images/banner/eng-5_05.png" width="75" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Investor/SearchBusinessIdeas.aspx">
                    <img src="/images/banner/eng-5_06.png" width="118" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Survey.aspx">
                    <img src="/images/banner/eng-5_07.png" width="52" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/AttendedEvent.aspx">
                    <img src="/images/banner/eng-5_08.png" width="51" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/MySupervisor.aspx">
                    <img src="/images/banner/eng-5_09.png" width="80" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/ChangePassword.aspx">
                    <img src="/images/banner/eng-5_10.png" width="67" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Logout.aspx">
                    <img src="/images/banner/eng-5_11.png" width="65" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="inv_eng_guest" width="960" height="144"
        border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="/images/banner/eng-4_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/banner/eng-4_02.png" width="840" height="30" alt="">
            </td>
            <td>
                <a href="/Common/Login.aspx">
                    <img src="/images/banner/eng-4_03.png" width="120" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="pro_eng_lo" width="960" height="144" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="10">
                <img src="/images/banner/eng-3_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td class="Welcome" style="background-image: url('/images/banner/eng-3_02.png')" width="358" height="30">
                <asp:Literal runat="server" ID="exltPro_eng_lo"></asp:Literal>
            </td>
            <td>
                <a href="/Professional/">
                    <img src="/images/banner/eng-3_03.png" width="60" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/UpdateProfile.aspx">
                    <img src="/images/banner/eng-3_04.png" width="52" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Professional/SearchBusinessIdeas.aspx">
                    <img src="/images/banner/eng-3_05.png" width="91" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Professional/MyEntrepreneur.aspx">
                    <img src="/images/banner/eng-3_06.png" width="85" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/AttendedEvent.aspx">
                    <img src="/images/banner/eng-3_07.png" width="49" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Survey.aspx">
                    <img src="/images/banner/eng-3_08.png" width="51" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/MySupervisor.aspx">
                    <img src="/images/banner/eng-3_09.png" width="81" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/ChangePassword.aspx">
                    <img src="/images/banner/eng-3_10.png" width="67" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Logout.aspx">
                    <img src="/images/banner/eng-3_11.png" width="66" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="pro_eng_guest" width="960" height="144"
        border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="/images/banner/eng-2_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/banner/eng-2_02.png" width="844" height="30" alt="">
            </td>
            <td>
                <a href="/Common/Login.aspx">
                    <img src="/images/banner/eng-2_03.png" width="116" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="ent_tr_lo" width="960" height="144" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="11">
                <img src="/images/banner/tr-7_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td class="Welcome" style="background-image: url('/images/banner/tr-7_02.png')" width="289" height="30">
                <asp:Literal runat="server" ID="exltEnt_tr_lo"></asp:Literal>
            </td>
            <td>
                <a href="/Entrepreneur/">
                    <img src="/images/banner/tr-7_03.png" width="76" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/UpdateProfile.aspx">
                    <img src="/images/banner/tr-7_04.png" width="58" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Entrepreneur/Project.aspx">
                    <img src="/images/banner/tr-7_05.png" width="70" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Entrepreneur/MyAdvisor.aspx">
                    <img src="/images/banner/tr-7_06.png" width="69" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Entrepreneur/MyInvestor.aspx">
                    <img src="/images/banner/tr-7_07.png" width="64" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/AttendedEvent.aspx">
                    <img src="/images/banner/tr-7_08.png" width="70" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Survey.aspx">
                    <img src="/images/banner/tr-7_09.png" width="48" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/MySupervisor.aspx">
                    <img src="/images/banner/tr-7_10.png" width="84" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/ChangePassword.aspx">
                    <img src="/images/banner/tr-7_11.png" width="67" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Logout.aspx">
                    <img src="/images/banner/tr-7_12.png" width="65" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="ent_tr_guest" width="960" height="144"
        border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="/images/banner/tr-6_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/banner/tr-6_02.png" width="849" height="30" alt="">
            </td>
            <td>
                <a href="/Common/Login.aspx">
                    <img src="/images/banner/tr-6_03.png" width="111" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="inv_tr_lo" width="960" height="144" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="10">
                <img src="/images/banner/tr-5_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td class="Welcome" style="background-image: url('/images/banner/tr-5_02.png')" width="364" height="30">
                <asp:Literal runat="server" ID="exltInv_tr_lo"></asp:Literal>
            </td>
            <td>
                <a href="/Investor/">
                    <img src="/images/banner/tr-5_03.png" width="80" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/UpdateProfile.aspx">
                    <img src="/images/banner/tr-5_04.png" width="59" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Investor/MyInvestments.aspx">
                    <img src="/images/banner/tr-5_05.png" width="52" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Investor/SearchBusinessIdeas.aspx">
                    <img src="/images/banner/tr-5_06.png" width="69" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Survey.aspx">
                    <img src="/images/banner/tr-5_07.png" width="48" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/AttendedEvent.aspx">
                    <img src="/images/banner/tr-5_08.png" width="69" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/MySupervisor.aspx">
                    <img src="/images/banner/tr-5_09.png" width="86" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/ChangePassword.aspx">
                    <img src="/images/banner/tr-5_10.png" width="68" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Logout.aspx">
                    <img src="/images/banner/tr-5_11.png" width="65" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="inv_tr_guest" width="960" height="144"
        border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="/images/banner/tr-4_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/banner/tr-4_02.png" width="849" height="30" alt="">
            </td>
            <td>
                <a href="/Common/Login.aspx">
                    <img src="/images/banner/tr-4_03.png" width="111" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="pro_tr_lo" width="960" height="144" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="10">
                <img src="/images/banner/tr-3_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td class="Welcome" style="background-image: url('/images/banner/tr-3_02.png')" width="370" height="30">
                <asp:Literal runat="server" ID="exltPro_tr_lo"></asp:Literal>
            </td>
            <td>
                <a href="/Professional/">
                    <img src="/images/banner/tr-3_03.png" width="74" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/UpdateProfile.aspx">
                    <img src="/images/banner/tr-3_04.png" width="59" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Professional/SearchBusinessIdeas.aspx">
                    <img src="/images/banner/tr-3_05.png" width="66" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Professional/MyEntrepreneur.aspx">
                    <img src="/images/banner/tr-3_06.png" width="61" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/AttendedEvent.aspx">
                    <img src="/images/banner/tr-3_07.png" width="69" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Survey.aspx">
                    <img src="/images/banner/tr-3_08.png" width="45" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/MySupervisor.aspx">
                    <img src="/images/banner/tr-3_09.png" width="83" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/ChangePassword.aspx">
                    <img src="/images/banner/tr-3_10.png" width="67" height="30" border="0" alt=""></a>
            </td>
            <td>
                <a href="/Common/Logout.aspx">
                    <img src="/images/banner/tr-3_11.png" width="66" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
    <table runat="server" visible="false" id="pro_tr_guest" width="960" height="144"
        border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                <img src="/images/banner/tr-2_01.png" width="960" height="114" alt="">
            </td>
        </tr>
        <tr>
            <td>
                <img src="/images/banner/tr-2_02.png" width="848" height="30" alt="">
            </td>
            <td>
                <a href="/Common/Login.aspx">
                    <img src="/images/banner/tr-2_03.png" width="112" height="30" border="0" alt=""></a>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:LinkButton runat="server" ID="lbAdminPanel" CausesValidation="false" Visible="false"
    OnClick="lbAdminPanel_Click"></asp:LinkButton>