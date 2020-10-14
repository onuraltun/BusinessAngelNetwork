<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="CV_Language.ascx.cs"
    Inherits="Web.ASCX.CV_Language" %>
<%@ Register Src="Decimal.ascx" TagName="Decimal" TagPrefix="uc1" %>
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <asp:Literal runat="server" ID="exltValidate"></asp:Literal>
        <table class="belgeHeader">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                        OnRowCommand="gvListe_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <%= DilCevir("ltSelfAssessment")%>
                                    </th>
                                    <th colspan="2">
                                        <%= DilCevir("ltUnderstanding")%>
                                    </th>
                                    <th colspan="2">
                                        <%= DilCevir("ltSpeaking")%>
                                    </th>
                                    <th>
                                        <%= DilCevir("ltWriting")%>
                                    </th>
                                    <th>
                                        <%= DilCevir("ltDelete")%>
                                    </th>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <th>
                                            <%= DilCevir("ltListening")%>
                                        </th>
                                        <th>
                                            <%= DilCevir("ltReading")%>
                                        </th>
                                        <th>
                                            <%= DilCevir("ltSpoken Interaction")%>
                                        </th>
                                        <th>
                                            <%= DilCevir("ltSpoken Production")%>
                                        </th>
                                        <th>
                                        </th>
                                        <th>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"LANGUAGE") %>' ID="exltLANGUAGE"
                                        runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"Listening") %>' ID="exltListening"
                                            runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"Reading") %>' ID="exltReading"
                                            runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"SpokenInteraction") %>'
                                            ID="exltSpokenInteraction" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"SpokenProduction") %>'
                                            ID="exltSpokenProduction" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"Writing") %>' ID="exltWriting"
                                            runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Sil" CausesValidation="false"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="inputs">
                    <asp:LinkButton ID="lbNewLanguage" runat="server"></asp:LinkButton>
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
                                                    <asp:Literal runat="server" ID="ltAddCVLanguage"></asp:Literal></b>
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
                                            <table class="belgeHeader" width="100%">
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltLANGUAGE"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtLANGUAGE" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltListening"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtListening" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltReading"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtReading" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltSpokenInteraction"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtSpokenInteraction" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltSpokenProduction"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtSpokenProduction" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltWriting"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtWriting" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                </td>
                            </tr>
                        </table>
                        <table class="belgeHeader" width="100%">
                            <tr>
                                <td class="labels">
                                </td>
                                <td class="inputs">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btnListele" Text="Gönder" OnClick="btnUploadFile_Click" />
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
            runat="server" TargetControlID="lbNewLanguage" PopupControlID="pnlFile">
        </AjaxControlToolkit:ModalPopupExtender>
    </asp:View>
</asp:MultiView>