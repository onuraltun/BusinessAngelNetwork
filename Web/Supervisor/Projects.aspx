<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Projects.aspx.cs" Inherits="Web.Supervisor.Projects" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../ASCX/WriteMessage.ascx" TagName="WriteMessage" TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvProjeler" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltProjectList" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                            OnRowCommand="gvListe_RowCommand" OnRowDataBound="gvListe_RowDataBound" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="NAME" HeaderText="Project NAME" />
                                <asp:BoundField DataField="ACRONYM" HeaderText="ACRONYM" />
                                <asp:BoundField DataField="SECTOR" HeaderText="SECTOR" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibDanismanlar" runat="server" CausesValidation="false" CommandName="ProList"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/professional.png" />
                                                </td>
                                                <td id="tdPPT" runat="server" class="inputs">
                                                    <asp:ImageButton ID="ibPPT" runat="server" CausesValidation="false" CommandName="pptDownload"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/ppt.JPG" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibPlan" runat="server" CausesValidation="false" CommandName="businessPlan"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/bplan.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="accept"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/accept.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayitGir" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltProjeOnizlemeSayfasi" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels">
                        Logo:
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="exltLogo" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectName" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectAcronym" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtAcronym" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectOneLinePitch" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtProjectOneLinePitch" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblSector" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        &nbsp;<asp:Literal ID="exltSektor" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBusinessSummary" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtBusinessSummary" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblManagement" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtManagement" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCustomErProblem" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtCustomerProblem" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProductorServices" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtProductorServices" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblTargetMarket" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtTargetMarket" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCustomers" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtCustomers" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblStrategy" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtStrategy" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBusinessModelType" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        &nbsp;<asp:Literal ID="exltBusinessModelType" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCompetitors" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtComptetitors" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblComptetitiveAdvange" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtComptetitiveAdvange" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblInvestmentAmount" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        &nbsp;<asp:Literal ID="exltInvestmenAmount" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnProjeKabul" runat="server" CssClass="btnKritik" OnClick="btnProjeKabul_Click" />
                        &nbsp;<asp:Button ID="btnSendMessage" runat="server" CssClass="btnListele" />
                        &nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" CausesValidation="False"
                            OnClick="btnVazgec_Click" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlMail" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
                <table id="tbFiltrele" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="PencereSolUstKose">
                        </td>
                        <td class="PencereTransparan">
                        </td>
                        <td class="PencereSagUstKose">
                        </td>
                    </tr>
                    <tr>
                        <td class="PencereTransparan">
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="white">
                                <tr>
                                    <td valign="top" class="PencereBaslik">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left">
                                                    <b><span>&nbsp;<asp:Literal ID="ltMessageFromProjectAcceptionPage" runat="server"></asp:Literal>
                                                    </span></b>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnVazgecFiltre" runat="server" Text="X" CssClass="PencereKapat"
                                                        ToolTip="Pencereyi kapatmak için týklayýnýz..." />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="PencereDetay">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="PencereDetay">
                                        <uc1:WriteMessage ID="ucMail" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="PencereTransparan">
                        </td>
                    </tr>
                    <tr>
                        <td class="PencereSolAltKose">
                        </td>
                        <td class="PencereTransparan">
                        </td>
                        <td class="PencereSagAltKose">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpFiltre" CancelControlID="btnVazgecFiltre" runat="server"
                TargetControlID="btnSendMessage" PopupControlID="pnlMail">
            </cc1:ModalPopupExtender>
        </asp:View>
        <asp:View ID="vProfessionals" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltProjeDanismanlari" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvProfessionals" runat="server" DataKeyNames="RECID" AutoGenerateColumns="false"
                            Width="100%">
                            <Columns>
                                <asp:BoundField DataField="AdiSoyadi" HeaderText="AdiSoyadi" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnReturnProjectList" runat="server" CausesValidation="False" CssClass="btn"
                            OnClick="btnVazgec_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vBusinessPlan" runat="server">
            <%--  <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        A.<asp:Literal ID="ltBusinessPlanA" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; 1.<asp:Literal ID="ltBusinessPlanA1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.<asp:Literal ID="ltBusinessPlanA1a" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA1a" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.<asp:Literal ID="ltBusinessPlanA1b" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA1b" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.<asp:Literal ID="ltBusinessPlanA1c" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA1c" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; d.<asp:Literal ID="ltBusinessPlanA1d" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA1d" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanA2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.<asp:Literal ID="ltBusinessPlanA2a" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA2a" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.<asp:Literal ID="ltBusinessPlanA2b" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA2b" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.<asp:Literal ID="ltBusinessPlanA2c" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtA2c" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        B.<asp:Literal ID="ltBusinessPlanB" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanB1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanB2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanB3" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB3" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; 4.<asp:Literal ID="ltBusinessPlanB4" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.<asp:Literal ID="ltBusinessPlanB4a" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB4a" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.<asp:Literal ID="ltBusinessPlanB4b" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB4b" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.<asp:Literal ID="ltBusinessPlanB4c" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB4c" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5.<asp:Literal ID="ltBusinessPlanB5" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB5" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6.<asp:Literal ID="ltBusinessPlanB6" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtB6" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        C.<asp:Literal ID="ltBusinessPlanC" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanC1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtC1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanC2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtC2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanC3" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtC3" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        D.<asp:Literal ID="ltBusinessPlanD" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanD1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtD1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanD2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtD2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        E.<asp:Literal ID="ltBusinessPlanE" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanE1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtE1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanE2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtE2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanE3" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtE3" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 4.<asp:Literal ID="ltBusinessPlanE4" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtE4" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 5.<asp:Literal ID="ltBusinessPlanE5" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtE5" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        F.<asp:Literal ID="ltBusinessPlanF" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanF1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtF1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanF2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtF2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        G.<asp:Literal ID="ltBusinessPlanG" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanG1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtG1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        H.<asp:Literal ID="ltBusinessPlanH" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanH1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtH1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanH2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtH2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        I.<asp:Literal ID="ltBusinessPlanI" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanI1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtI1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlan2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtI2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanI3" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtI3" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 4.<asp:Literal ID="ltBusinessPlanI4" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtI4" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 5.<asp:Literal ID="ltBusinessPlanI5" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtI5" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        J.<asp:Literal ID="ltBusinessPlanJ" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanJ1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtJ1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanJ2" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtJ2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        K.<asp:Literal ID="ltBusinessPlanK" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanK1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtK1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        L.<asp:Literal ID="ltBusinessPlanL" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanL1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtL1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        M.<asp:Literal ID="ltBusinessPlanM" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanM1" runat="server"></asp:Literal>
                    </td>
                    <td class="labels">
                        <asp:Literal ID="extxtM1" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnReturnProjectList2" runat="server" CssClass="btn" OnClick="btnVazgec_Click" />--%>
            <rsweb:ReportViewer ID="rtpRaporum" runat="server">
            </rsweb:ReportViewer>
        </asp:View>
    </asp:MultiView>
</asp:Content>
