<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProfessionalFeedback.ascx.cs"
    Inherits="Web.ASCX.AddProfessionalFeedback" %>
<asp:LinkButton runat="server" ID="lbAddFeedback"></asp:LinkButton>
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
                                            <asp:Literal runat="server" ID="ltAddFeedback"></asp:Literal></b>
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
                                        <asp:Literal ID="lblFeedback" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtFeedback" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="ltPoint" runat="server"></asp:Literal>
                                    </td>
                                    <td class="labels">
                                        <AjaxControlToolkit:Rating ID="Rating1" CurrentRating="5" MaxRating="10" runat="server" StarCssClass="ratingStar"
                                            WaitingStarCssClass="savedRatingStar" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar">
                                        </AjaxControlToolkit:Rating>
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
                            <asp:Button ID="btnAddFeedback" runat="server" CssClass="btnListele" Text="Gönder"
                                OnClick="btnAddFeedback_Click" />
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
    runat="server" TargetControlID="lbAddFeedback" PopupControlID="pnlFile">
</AjaxControlToolkit:ModalPopupExtender>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltProffesionalFeedbackHeader"></asp:Literal>
        </td>
    </tr>
</table>
<asp:GridView ID="gvFeedback" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID">
    <Columns>
        <asp:BoundField DataField="NAMESURNAME" HeaderText="NAMESURNAME" />
        <asp:BoundField DataField="CREATIONDATE" HeaderText="DATE" />
        <asp:BoundField DataField="FEEDBACK" HeaderText="FEEDBACK" />
        <asp:TemplateField HeaderText="POINT">
            <ItemTemplate>
                <table class="belgeHeader" width="100%">
                    <tr>
                        <td class="inputs">
                            <AjaxControlToolkit:Rating ID="Rating1" CurrentRating='<%#DataBinder.Eval(Container.DataItem,"POINT") %>'
                                Enabled="false" runat="server" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar">
                            </AjaxControlToolkit:Rating>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
