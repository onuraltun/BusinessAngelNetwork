<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Project.aspx.cs" Inherits="Web.Entrepreneur.Project" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/WriteMessage.ascx" TagName="WriteMessage" TagPrefix="uc3" %>
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
                                <asp:CheckBoxField DataField="APPROVED" HeaderText="Project APPROVED" />
                                <asp:CheckBoxField DataField="LOGOAPPROVED" HeaderText="LOGO APPROVED" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbLogo" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                            CausesValidation="false" CssClass="tip" OnClientClick="#" Text="Logo"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibDanismanlar" runat="server" CausesValidation="false" CommandName="ProList"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/professional.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibPPT" runat="server" CausesValidation="false" CommandName="pptDownload"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/ppt.JPG" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibPlan" runat="server" CausesValidation="false" CommandName="businessPlan"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/bplan.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet" OnClick="btnYeniKayit_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayitGir" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltProjeKayitSayfasi" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="ltValidate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectName" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtProjectName" runat="server" ControlToValidate="txtName"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectAcronym" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtAcronym" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtAcronym" runat="server" ControlToValidate="txtAcronym"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectOneLinePitch" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtProjectOneLinePitch" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblSector" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:DropDownList ID="drpSektorler" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:CompareValidator ID="cvdrpSektorler" runat="server" ControlToValidate="drpSektorler"
                            ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                            ValueToCompare="0"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBusinessSummary" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtBusinessSummary" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblManagement" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtManagement" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCustomErProblem" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtCustomerProblem" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProductorServices" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtProductorServices" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblTargetMarket" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtTargetMarket" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCustomers" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtCustomers" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblStrategy" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtStrategy" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBusinessModelType" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:DropDownList ID="drpBussinesType" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:CompareValidator ID="cvdrpBussinesType" runat="server" ControlToValidate="drpBussinesType"
                            ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                            ValueToCompare="0"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCompetitors" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtComptetitors" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblComptetitiveAdvange" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <uc2:Aciklama ID="txtComptetitiveAdvange" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblInvestmentAmount" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtInvestmentAmount" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtInvestmentAmount" runat="server" ControlToValidate="txtInvestmentAmount"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvtxtinvestmentAmount" runat="server" ControlToValidate="txtInvestmentAmount"
                            ErrorMessage="youHaveToEnterNumber" Operator="DataTypeCheck" SetFocusOnError="True"
                            Type="Integer"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblLogoSelection" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:FileUpload ID="fuLogo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltProjectPresentationFile" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:FileUpload ID="fuPresentationFile" runat="server" />
                        &nbsp;<asp:HyperLink ID="hpPresentationFileLink" runat="server">[hpPresentationFileLink]</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnKaydet" runat="server" CssClass="btnKritik" OnClick="btnKaydet_Click" />
                        &nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" CausesValidation="False"
                            OnClick="btnVazgec_Click" />
                    </td>
                </tr>
            </table>
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
                            Width="100%" OnRowCommand="gvProfessionals_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="AdiSoyadi" HeaderText="AdiSoyadi" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSendMessage" runat="server" CommandName="Mail" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/mail.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibCV" runat="server" CausesValidation="false" CommandName="CV"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/professional.png" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
            <br />
            <asp:Panel ID="pnlBaslik" runat="server">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="white">
                    <tr>
                        <td valign="top" class="PencereBaslik">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <b>
                                            <asp:Literal runat="server" ID="ltProfessionalList"></asp:Literal></b>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ibAcKapa" runat="server" ImageUrl="~/images/expand.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlDetail" runat="server">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="white">
                    <tr>
                        <td class="PencereDetay">
                            <asp:GridView ID="gvProfessionalsList" DataKeyNames="RECID,SECTORID" runat="server"
                                AutoGenerateColumns="false" Width="100%" OnRowCommand="gvProfessionalsList_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="NameSurname" HeaderText="NameSurname" />
                                    <asp:BoundField DataField="COMPANYNAME" HeaderText="COMPANYNAME" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table class="belgeHeader">
                                                <tr>
                                                    <td class="inputs">
                                                        <asp:ImageButton ID="ibDanismanlar" runat="server" CausesValidation="false" CommandName="AddPro"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/add.png" />
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:ImageButton ID="ibCV" runat="server" CausesValidation="false" CommandName="CV"
                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/professional.png" />
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
                <table class="belgeHeader">
                    <tr>
                        <td class="labels">
                            <asp:Literal ID="ltSectorSec" runat="server"></asp:Literal>
                        </td>
                        <td class="inputs">
                            <asp:DropDownList ID="drpSectorSec" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="labels">
                            <asp:Literal ID="ltDoesYourBusinessideainclude" runat="server"></asp:Literal>
                        </td>
                        <td class="inputs">
                            <asp:CheckBox ID="cbRD" runat="server" />
                            &nbsp;<asp:CheckBox ID="cbTeknolojiTransfer" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="labels">
                            &nbsp;
                        </td>
                        <td class="inputs">
                            <asp:Button ID="btnListele" CssClass="btnListele" runat="server" 
                                onclick="btnListele_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <AjaxControlToolkit:CollapsiblePanelExtender ID="idAcKapa" runat="server" TargetControlID="pnlDetail"
                ExpandControlID="pnlBaslik" CollapseControlID="pnlBaslik" Collapsed="false" ExpandedImage="../images/collapse.jpg"
                CollapsedImage="../images/expand.jpg" SuppressPostBack="true">
            </AjaxControlToolkit:CollapsiblePanelExtender>
            <asp:Button ID="exbtnTMP" runat="server" Style="display: none;" />
            <asp:Panel ID="pnlSendMessage" runat="server" Style="display: none;" Width="650px"
                HorizontalAlign="Left">
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
                                                    <b>
                                                        <asp:Literal runat="server" ID="ltSendMessageForm"></asp:Literal></b>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnVazgecFiltre2" runat="server" Text="X" CssClass="PencereKapat" />
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
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="labels">
                                                    <uc3:WriteMessage ID="ucSendMessage" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
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
            <AjaxControlToolkit:ModalPopupExtender ID="mpSendMessage" CancelControlID="btnVazgecFiltre2"
                runat="server" TargetControlID="exbtnTMP" PopupControlID="pnlSendMessage">
            </AjaxControlToolkit:ModalPopupExtender>
        </asp:View>
    </asp:MultiView>
</asp:Content>
