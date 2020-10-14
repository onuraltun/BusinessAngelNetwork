<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="ProjectAcception.aspx.cs" Inherits="Web.Supervisor.ProjectAcception" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../ASCX/WriteMessage.ascx" TagName="WriteMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
        function CVGoster(memberid) {
            window.open('../Common/ViewMember.aspx?m=' + memberid, 'CVGoster', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=' + screen.width + ',height=' + screen.height + ',left = 0,top = 0');
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvProjects" runat="server" ActiveViewIndex="0">
        <asp:View ID="vList" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltOnayBekleyenDanismanliklar" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="ProjectID,MemberID"
                            OnRowCommand="gvListe_RowCommand" OnRowDataBound="gvListe_RowDataBound" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="ProjectName" HeaderText="Project NAME" />
                                <asp:BoundField DataField="ACRONYM" HeaderText="ACRONYM" />
                                <asp:BoundField DataField="SECTOR" HeaderText="SECTOR" />
                                <asp:BoundField DataField="MemberNameSurname" HeaderText="Danışman" />
                                <asp:BoundField DataField="MODIFICATIONDATE" HeaderText="MODiFiCATiONDATE" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td id="tdPPT" runat="server" class="inputs">
                                                    <asp:ImageButton ID="ibPPT" runat="server" CausesValidation="false" CommandName="pptDownload"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ProjectID") %>' ImageUrl="~/images/ppt.JPG" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibPlan" runat="server" CausesValidation="false" CommandName="businessPlan"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ProjectID") %>' ImageUrl="~/images/bplan.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="accept"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MasterID") %>' ImageUrl="~/images/ara.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibDanisman" runat="server" CausesValidation="false" ImageUrl="~/images/professional.png" />
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
            <rsweb:ReportViewer ID="rtpRaporum" runat="server" Visible="false">
            </rsweb:ReportViewer>
        </asp:View>
        <asp:View ID="vProjectDetail" runat="server">
            <h3>
                <asp:Literal ID="ltProjeOnizlemeSayfasi" runat="server"></asp:Literal>
            </h3>
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
                        <asp:Literal ID="lblSector2" runat="server"></asp:Literal>
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
                        <asp:Literal ID="ltinvestmentAmount3" runat="server"></asp:Literal>
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
                        <asp:Button ID="btnAccept" runat="server" CssClass="btnKritik" OnClick="btnProjeyeDanismanOl_Click" />
                        &nbsp;<asp:Button ID="btnSendMessage" runat="server" CssClass="btnListele" />
                        &nbsp;<asp:Button ID="btnReturnProjectList" runat="server" CssClass="btn" CausesValidation="False"
                            OnClick="btnVazgec_Click" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlMail" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
                <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
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
                                                    <asp:Button ID="exbtnVazgec2" runat="server" Text="X" CssClass="PencereKapat" ToolTip="Pencereyi kapatmak için tıklayınız..." />
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
            <cc1:ModalPopupExtender ID="mpMessage" CancelControlID="exbtnVazgec2" runat="server"
                TargetControlID="btnSendMessage" PopupControlID="pnlMail">
            </cc1:ModalPopupExtender>
        </asp:View>
    </asp:MultiView>
</asp:Content>
