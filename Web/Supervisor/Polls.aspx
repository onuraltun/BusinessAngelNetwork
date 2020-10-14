<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Polls.aspx.cs" Inherits="Web.Supervisor.Polls" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="exgvPoll" runat="server" Width="100%" DataKeyNames="RECID" AutoGenerateColumns="false"
                            OnRowDataBound="exgvPoll_RowDataBound" OnRowCommand="exgvPoll_RowCommand" EmptyDataText="Kay�tl� anket bulunamad�!">
                            <Columns>
                                <asp:BoundField DataField="NAME_TR" HeaderText="Konusu" />
                                <asp:BoundField DataField="NAME_EN" HeaderText="Konusu(�ngilizce)" />
                                <asp:BoundField DataField="STARTDATE" HeaderText="Ba�lang�� Tarihi" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="ENDDATE" HeaderText="Biti� Tarihi" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:CheckBoxField DataField="ISFORE" HeaderText="Giri�imci" />
                                <asp:CheckBoxField DataField="ISFORINVESTOR" HeaderText="Yat�r�mc�" />
                                <asp:CheckBoxField DataField="ISFORPROFESSIONAL" HeaderText="Uzman" />
                                <asp:CheckBoxField DataField="ISFORGUEST" HeaderText="Ziyaret�i" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                        OnClientClick="javascript:return confirm('Bu anketi silmek istedi�inizden emin misiniz?')"
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
                        <asp:Button ID="exbtnYeniKayit" runat="server" CssClass="btnKaydet" OnClick="exbtnYeniKayit_Click"
                            Text="+ Yeni Kay�t" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayit" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="labels">
                        Anketin Konusu TR:
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtAnketKonuTR" runat="server" Width="371px" MaxLength="50"></asp:TextBox>
                        &nbsp;T�rk�e
                        <asp:RequiredFieldValidator ID="exreftxtAnketKonuTR" runat="server" ErrorMessage="L�tfen anketin konusunu giriniz!"
                            ControlToValidate="txtAnketKonuTR" SetFocusOnError="True" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        Anketin Konusu EN:
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtAnketKonuEN" runat="server" Width="371px" MaxLength="50"></asp:TextBox>
                        &nbsp;�ngilizce
                        <asp:RequiredFieldValidator ID="exreftxtAnketKonuEN" runat="server" ErrorMessage="L�tfen anketin konusunu giriniz!"
                            ControlToValidate="txtAnketKonuEN" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        Tarihler:
                    </td>
                    <td class="inputs">
                        <uc1:Takvim ID="tvBas" runat="server" />
                        &nbsp;-
                        <uc1:Takvim ID="tvBit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        �zinler:
                    </td>
                    <td class="inputs">
                        <asp:CheckBox ID="cbGirisimciGorsun" runat="server" Text="Giri�imci G�rs�n M�?" />
                        &nbsp;<asp:CheckBox ID="cbYatirimciGorsunMu" runat="server" Text="Yat�r�mc� G�rs�n M�?" />
                        &nbsp;<asp:CheckBox ID="cbUzmanGorsunMu" runat="server" Text="Uzman G�rs�n M�?" />
                        &nbsp;<asp:CheckBox ID="cbZiyaretciGorsunMu" runat="server" Text="Ziyaret�i G�rs�n M�?" />
                    </td>
                </tr>
                <tr>
                    <td class="labels" rowspan="2">
                        Se�enekler:
                    </td>
                    <td class="inputs">
                        <asp:GridView ID="exgvSecenekGir" runat="server" Width="100%" AutoGenerateColumns="false"
                            EmptyDataText="L�tfen anket i�in se�enek giriniz!" OnRowCommand="exgvSecenekGir_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="OPTIONTEXT_TR" HeaderText="Se�enek" />
                                <asp:BoundField DataField="OPTIONTEXT_EN" HeaderText="Se�enek (�ngilizce)" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <table class="belgeHeader">
                            <tr>
                                <td class="labels">
                                    Se�enek TR:
                                </td>
                                <td class="inputs">
                                    <asp:TextBox ID="txtSecenekTR" runat="server" MaxLength="50"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="exreftxtSecenekTR" runat="server" ErrorMessage="L�tfen se�enek giriniz!"
                                        ControlToValidate="txtSecenekTR" SetFocusOnError="True" ValidationGroup="secenek"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="labels">
                                    Se�enek EN:
                                </td>
                                <td class="inputs">
                                    <asp:TextBox ID="txtSecenekEN" runat="server" MaxLength="50"></asp:TextBox>
                                    &nbsp;<asp:RequiredFieldValidator ID="exreftxtSecenekEN" runat="server" ErrorMessage="L�tfen se�enek giriniz!"
                                        ControlToValidate="txtSecenekEN" SetFocusOnError="True" ValidationGroup="secenek"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="labels">
                                    &nbsp;
                                </td>
                                <td class="inputs">
                                    <asp:Button ID="exbtnSecenekEkle" runat="server" CssClass="btnListele" Text="+ Ekle"
                                        ValidationGroup="secenek" OnClick="exbtnSecenekEkle_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="exbtnKaydet" runat="server" CssClass="btnKritik" Text="Kaydet" ValidationGroup="kayit"
                            OnClick="exbtnKaydet_Click" />
                        &nbsp;<asp:Button ID="exbtnVazgec" runat="server" CssClass="btn" Text="Vazge�" CausesValidation="False"
                            OnClick="exbtnVazgec_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ctphMiddle" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ctphRight" runat="server">
</asp:Content>
