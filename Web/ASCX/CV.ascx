<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="CV.ascx.cs" Inherits="Web.ASCX.CV" %>
<%@ Register Src="Decimal.ascx" TagName="Decimal" TagPrefix="uc1" %>
<%@ Register Src="Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<%@ Register Src="CV_Work.ascx" TagName="CV_Work" TagPrefix="uc3" %>
<%@ Register Src="CV_Education.ascx" TagName="CV_Education" TagPrefix="uc4" %>
<%@ Register Src="CV_Language.ascx" TagName="CV_Language" TagPrefix="uc5" %>
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <table class="belgeHeader">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="gvListe" runat="server" OnRowCommand="gvListe_RowCommand" AutoGenerateColumns="False"
                        DataKeyNames="RECID">
                        <Columns>
                            <asp:BoundField DataField="SurnameFirstname" HeaderText="SurnameFirstname" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table class="belgeHeader" width="100%">
                                        <tr>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibView" runat="server" CausesValidation="false" CommandName="Goster"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/ara.gif" />
                                            </td>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/update.gif" />
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
                    <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet" OnClick="btnYeniKayit_Click"
                        Visible="false" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="vKayitGir" runat="server">
        <table class="belgeHeader" width="100%">
            <tr>
                <td class="Baslik" colspan="2">
                    <asp:Literal ID="ltCVHeader" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="Baslik" colspan="2">
                    <asp:Literal ID="ltPersonelInformation" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltSurnameFirstname"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtSurnameFirstname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltAddress"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltTelephone"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltMobile"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltFax"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltEmail"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltNationality"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtNationality" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltDateofBirth"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtDateofBirth" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltGender"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltDesiredEmployment"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtDesiredEmployment" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="labels" colspan="2">
                    <uc3:CV_Work runat="server" ID="CV_Work1" />
                </td>
            </tr>
        </table>
        <table class="belgeHeader">
            <tr>
                <td class="labels">
                    <uc4:CV_Education runat="server" ID="CV_Education1" />
                </td>
            </tr>
        </table>
        <table class="belgeHeader">
            <tr>
                <td class="labels" colspan="2">
                    <asp:Literal ID="ltPersonelSkills" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltMotherTongue"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtMotherTongue" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels" colspan="2">
                    <asp:Literal ID="ltOtherLanguages" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <table class="belgeHeader">
            <tr>
                <td class="labels">
                    <uc5:CV_Language runat="server" ID="CV_Language1" />
                </td>
            </tr>
        </table>
        <table class="belgeHeader">
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltSocialSkills"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtSocialSkills" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltOrganisationalSkills"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtOrganisationalSkills" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltTechnicalSkills"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtTechnicalSkills" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltComputerSkills"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtComputerSkills" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltArtisticSkills"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtArtisticSkills" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltOtherSkills"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtOtherSkills" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltAdditionalInformation"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtAdditionalInformation" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltAnnexes"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtAnnexes" runat="server" />
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
</asp:MultiView>