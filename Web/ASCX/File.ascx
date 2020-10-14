<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="File.ascx.cs" Inherits="Web.ASCX.File" %>
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal runat="server" ID="exltHeader"></asp:Literal>
                </td>
            </tr>
        </table>
        <asp:Literal runat="server" ID="exltValidate"></asp:Literal>
        <table class="belgeHeader">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                        OnRowCommand="gvListe_RowCommand" OnRowDataBound="gvListe_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="FILENAME" HeaderText="FILENAME" />
                            <asp:BoundField DataField="SIZE" HeaderText="SIZE" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table class="belgeHeader" width="100%">
                                        <tr>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/download.jpg" />
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
                    <asp:LinkButton ID="lbUploadFile" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlFile" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
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
                                                    <asp:Literal runat="server" ID="ltFileTitle"></asp:Literal></b>
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
                                                        <asp:Literal runat="server" ID="ltShowFileSource"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:FileUpload runat="server" ID="fuFile" />
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
                                    <asp:Button ID="btnUploadFile" runat="server" CssClass="btnListele" Text="Gönder"
                                        OnClick="btnUploadFile_Click" />
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
            runat="server" TargetControlID="lbUploadFile" PopupControlID="pnlFile">
        </AjaxControlToolkit:ModalPopupExtender>
    </asp:View>
</asp:MultiView>