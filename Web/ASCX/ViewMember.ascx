<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ViewMember.ascx.cs"
    Inherits="Web.ASCX.ViewMember" %>
<%@ Register Src="File.ascx" TagName="File" TagPrefix="uc10" %>
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0" Visible="false">
    <asp:View ID="vKayitGoster" runat="server">
        <table width="100%">
            <tr valign="top">
                <td class="labels">
                    <asp:Image runat="server" ID="imgMember" /><br />
                    <asp:Literal runat="server" ID="exltValidate"></asp:Literal>
                    <asp:LinkButton ID="lbChangePicture" runat="server" Text="Change Picture"></asp:LinkButton>
                </td>
                <td class="inputs">
                    <table>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltTitle" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltName" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltNAME" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltSurname" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltSURNAME" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal ID="ltEmail" runat="server"></asp:Literal>
                            </td>
                            <td class="inputs">
                                <asp:Literal ID="exltEMAIL" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal runat="server" ID="ltCompanyInfo"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:Image runat="server" ID="imgLogo" /><br />
        <asp:Literal runat="server" ID="exltLogoValidate"></asp:Literal>
        <asp:LinkButton ID="lbChangeLogo" runat="server" Text="Change Picture"></asp:LinkButton>
        <table width="100%">
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltCompanyName" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltCOMPANYNAME" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltPosition" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltPOSITION" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels" valign="top">
                    <asp:Literal ID="ltAddress" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltADDRESS" runat="server"></asp:Literal><br />
                    <asp:Literal ID="ltCITY" runat="server"></asp:Literal>:
                    <asp:Literal ID="exltCITY" runat="server"></asp:Literal><br />
                    <asp:Literal ID="ltPROVINCE" runat="server"></asp:Literal>:
                    <asp:Literal ID="exltPROVINCE" runat="server"></asp:Literal><br />
                    <asp:Literal ID="ltCOUNTRY" runat="server"></asp:Literal>:
                    <asp:Literal ID="exltCOUNTRY" runat="server"></asp:Literal><br />
                    <asp:Literal ID="ltPOSTALCODE" runat="server"></asp:Literal>:
                    <asp:Literal ID="exltPOSTALCODE" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltTelephone" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltTELEPHONE" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltFax" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltFAX" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltMobileNumber" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltMOBILENUMBER" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr id="trAmount" runat="server">
                <td class="labels">
                    <asp:Literal ID="ltAmountsPerInvestments" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltAMOUNTSPERINVESTMENT" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr id="trInvestorType" runat="server">
                <td class="labels">
                    <asp:Literal ID="ltInvestorType" runat="server"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:Literal ID="exltInvestorType" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlPicture" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
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
                                                <b>
                                                    <asp:Literal runat="server" ID="ltShowImageDestination"></asp:Literal></b>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnVazgecFiltre" runat="server" Text="X" CssClass="PencereKapat"
                                                    ToolTip="Pencereyi kapatmak için tıklayınız..." />
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
                                    <asp:UpdatePanel ID="upMuhabirAra" runat="server">
                                        <ContentTemplate>
                                            <table class="belgeHeader" width="100%">
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltBrowse"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:FileUpload runat="server" ID="fuImage" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table class="belgeHeader" width="100%">
                            <tr>
                                <td class="labels">
                                </td>
                                <td class="inputs">
                                    <asp:Button ID="btnUpload" runat="server" CssClass="btnListele" Text="Gönder" OnClick="btnUpload_Click" />
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
        <AjaxControlToolkit:ModalPopupExtender ID="mpFiltre" CancelControlID="btnVazgecFiltre"
            runat="server" TargetControlID="lbChangePicture" PopupControlID="pnlPicture">
        </AjaxControlToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlLogo" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
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
                                                    <asp:Literal runat="server" ID="ltShowImageSource"></asp:Literal></b>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnVazgecFiltre2" runat="server" Text="X" CssClass="PencereKapat"
                                                    ToolTip="Pencereyi kapatmak için tıklayınız..." />
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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="belgeHeader" width="100%">
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltBrowse2"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:FileUpload runat="server" ID="fuLogo" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <table class="belgeHeader" width="100%">
                            <tr>
                                <td class="labels">
                                </td>
                                <td class="inputs">
                                    <asp:Button ID="btnUploadLogo" runat="server" CssClass="btnListele" Text="Gönder"
                                        OnClick="btnUploadLogo_Click" />
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
        <AjaxControlToolkit:ModalPopupExtender ID="mpFiltre2" CancelControlID="btnVazgecFiltre2"
            runat="server" TargetControlID="lbChangeLogo" PopupControlID="pnlLogo">
        </AjaxControlToolkit:ModalPopupExtender>
        <br />
        <asp:LinkButton runat="server" ID="lbUpdateProfile" OnClick="lbUpdate_Click"></asp:LinkButton><br />
        <br />
        <uc10:File ID="File1" runat="server" TableName="MEMBER" FileType="CV"></uc10:File>
        <br />
        <asp:LinkButton runat="server" ID="lbUpdateCV" OnClick="lbUpdateCV_Click"></asp:LinkButton>
        -
        <asp:LinkButton runat="server" ID="lbExportCV" OnClick="lbExportCV_Click"></asp:LinkButton>
        <br />
        <br />
        <uc10:File ID="File2" runat="server" TableName="MEMBER" FileType="CERTIFICATE"></uc10:File>
        <br />
        <br />
        <uc10:File ID="File3" runat="server" TableName="MEMBER" FileType="LEGAL_DOCUMENT">
        </uc10:File>
    </asp:View>
</asp:MultiView>