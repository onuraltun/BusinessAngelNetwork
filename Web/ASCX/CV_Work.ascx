<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="CV_Work.ascx.cs" Inherits="Web.ASCX.CV_Work" %>
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
                                    <%= DilCevir("ltWorkExperience")%>
                                    </th>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table class="belgeHeader" width="100%">
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltDates"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"Dates") %>' ID="exltDates"
                                                    runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltOccupation"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"Occupation") %>' ID="exltOccupation"
                                                    runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltMainActivities"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"MainActivities") %>' ID="exltMainActivities"
                                                    runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltNameAndAddress"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"NameAndAddress") %>' ID="exltNameAndAddress"
                                                    runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltTypeOfBusiness"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"TypeOfBusiness") %>' ID="exltTypeOfBusiness"
                                                    runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table class="belgeHeader" width="100%">
                                        <tr>
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
                    <asp:LinkButton ID="lbNewWork" runat="server"></asp:LinkButton>
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
                                                    <asp:Literal runat="server" ID="ltAddCVWork"></asp:Literal></b>
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
                                                        <asp:Literal runat="server" ID="ltDates"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtDates" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltOccupation"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltMainActivities"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtMainActivities" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltNameAndAddress"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtNameAndAddress" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="labels">
                                                        <asp:Literal runat="server" ID="ltTypeOfBusiness"></asp:Literal>
                                                    </td>
                                                    <td class="inputs">
                                                        <asp:TextBox ID="txtTypeOfBusiness" runat="server"></asp:TextBox>
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
            runat="server" TargetControlID="lbNewWork" PopupControlID="pnlFile">
        </AjaxControlToolkit:ModalPopupExtender>
    </asp:View>
</asp:MultiView>