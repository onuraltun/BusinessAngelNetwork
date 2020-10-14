<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="CV_Education.ascx.cs"
    Inherits="Web.ASCX.CV_Education" %>
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <table class="belgeHeader">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                        OnRowCommand="gvListe_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <%= DilCevir("ltEducation")%>
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
                                                <asp:Literal runat="server" ID="ltLevelInNational"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"LevelInNational") %>' ID="exltLevelInNational"
                                                    runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
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
                                                <asp:Literal runat="server" ID="ltNameAndTypeOfOrganisation"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"NameAndTypeOfOrganisation") %>'
                                                    ID="exltNameAndTypeOfOrganisation" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltPrincipalSubjects"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"PrincipalSubjects") %>'
                                                    ID="exltPrincipalSubjects" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltTitleOfQualification"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:Literal Text='<%#DataBinder.Eval(Container.DataItem,"TitleOfQualification") %>'
                                                    ID="exltTitleOfQualification" runat="server"></asp:Literal>
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
                    <asp:LinkButton ID="lbNewEducation" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlEducation" runat="server" Style="display: none;" Width="650px"
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
                                                    <asp:Literal runat="server" ID="ltAddCVEducation"></asp:Literal></b>
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
                                                <asp:Literal runat="server" ID="ltLevelInNational"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:TextBox ID="txtLevelInNational" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltMainActivities"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:TextBox ID="txtMainActivities" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltNameAndTypeOfOrganisation"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:TextBox ID="txtNameAndTypeOfOrganisation" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltPrincipalSubjects"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:TextBox ID="txtPrincipalSubjects" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="labels">
                                                <asp:Literal runat="server" ID="ltTitleOfQualification"></asp:Literal>
                                            </td>
                                            <td class="inputs">
                                                <asp:TextBox ID="txtTitleOfQualification" runat="server"></asp:TextBox>
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
            runat="server" TargetControlID="lbNewEducation" PopupControlID="pnlEducation">
        </AjaxControlToolkit:ModalPopupExtender>
    </asp:View>
</asp:MultiView>