<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Survey.aspx.cs" Inherits="Web.Supervisor.Survey" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/ShowSurvey.ascx" TagName="ShowSurvey" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="exgvSurvey" runat="server" Width="100%" DataKeyNames="SurveyID"
                            AutoGenerateColumns="false" OnRowCommand="exgvSurvey_RowCommand" EmptyDataText="Kayýt bulunamadý!">
                            <Columns>
                                <asp:BoundField DataField="Subject_TR" HeaderText="Konusu" />
                                <asp:BoundField DataField="Subject_EN" HeaderText="Konusu(Ýngilizce)" />
                                <asp:BoundField DataField="DateStart" HeaderText="Baþlangýç Tarihi" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="DateEnd" HeaderText="Bitiþ Tarihi" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                        OnClientClick="javascript:return confirm('Bu testi silmek istediðinizden emin misiniz?')"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyID") %>' ImageUrl="~/images/delete.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSonuclar" runat="server" CommandName="Oylayanlar" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyID") %>' ImageUrl="~/images/ara.gif" />
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
                            Text="+ Yeni Kayýt" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayit" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="labels">
                        Konusu TR:
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtKonuTR" runat="server" Width="371px" MaxLength="50"></asp:TextBox>
                        &nbsp;Türkçe
                        <asp:RequiredFieldValidator ID="exreftxtKonuTR" runat="server" ErrorMessage="Lütfen konusunu giriniz!"
                            ControlToValidate="txtKonuTR" SetFocusOnError="True" ValidationGroup="kayit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        Konusu EN:
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtKonuEN" runat="server" Width="371px" MaxLength="50"></asp:TextBox>
                        &nbsp;Ýngilizce
                        <asp:RequiredFieldValidator ID="exreftxtKonuEN" runat="server" ErrorMessage="Lütfen konusunu giriniz!"
                            ControlToValidate="txtKonuEN" ValidationGroup="kayit"></asp:RequiredFieldValidator>
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
                        Ýzinler:
                    </td>
                    <td class="inputs">
                        <asp:CheckBoxList ID="cbMemberShiptType" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="labels" rowspan="2">
                        Seçenekler:
                    </td>
                    <td class="inputs">
                        <asp:GridView ID="exgvSoruGir" runat="server" Width="100%" AutoGenerateColumns="false"
                            EmptyDataText="Lütfen soru giriniz!" OnRowCommand="exgvSoruGir_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Question_TR" HeaderText="Soru" />
                                <asp:BoundField DataField="Question_EN" HeaderText="Soru (Ýngilizce)" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyQuestionID") %>'
                                            ImageUrl="~/images/delete.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <asp:Button ID="exbtnSoruEkle" runat="server" CssClass="btnListele" Text="+ Soru Ekle"
                            ValidationGroup="secenek" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="exbtnKaydet" runat="server" CssClass="btnKritik" Text="Kaydet" ValidationGroup="kayit"
                            OnClick="exbtnKaydet_Click" />
                        &nbsp;<asp:Button ID="exbtnVazgec" runat="server" CssClass="btn" Text="Vazgeç" CausesValidation="False"
                            OnClick="exbtnVazgec_Click" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlAra" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
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
                                                    <b><span>&nbsp;Lütfen filtreleme kriterlerini giriniz!</span></b>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnVazgecFiltre" runat="server" Text="X" CssClass="PencereKapat"
                                                        ToolTip="Pencereyi kapatmak için týklayýnýz..." />
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
                                        <asp:UpdatePanel ID="upSoruKayit" runat="server">
                                            <ContentTemplate>
                                                <table class="belgeHeader">
                                                    <tr>
                                                        <td class="labels">
                                                            Soru TR:
                                                        </td>
                                                        <td class="inputs">
                                                            <asp:TextBox ID="txtSoruTR" runat="server" MaxLength="50"></asp:TextBox>
                                                            &nbsp;<asp:RequiredFieldValidator ID="exreftxtSoruTR" runat="server" ErrorMessage="Lütfen soru giriniz!"
                                                                ControlToValidate="txtSoruTR" SetFocusOnError="True" ValidationGroup="soru"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="labels">
                                                            Soru EN:
                                                        </td>
                                                        <td class="inputs">
                                                            <asp:TextBox ID="txtSoruEN" runat="server" MaxLength="50"></asp:TextBox>
                                                            &nbsp;<asp:RequiredFieldValidator ID="exreftxtSoruEN" runat="server" ErrorMessage="Lütfen soru giriniz!"
                                                                ControlToValidate="txtSoruEN" SetFocusOnError="True" ValidationGroup="soru"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="labels">
                                                            Þýklar
                                                        </td>
                                                        <td class="inputs">
                                                            <table class="belgeHeader">
                                                                <tr>
                                                                    <td class="inputs" colspan="2">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labels">
                                                                        &nbsp;Soru Tipi:
                                                                    </td>
                                                                    <td class="inputs">
                                                                        <asp:DropDownList ID="drpInputType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpInputType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labels">
                                                                        Þýk TR
                                                                    </td>
                                                                    <td class="inputs">
                                                                        <asp:TextBox ID="txtOptionTR" runat="server" ValidationGroup="optionekle"></asp:TextBox>
                                                                        &nbsp;<asp:RequiredFieldValidator ID="exreftxtOption" runat="server" ControlToValidate="txtOptionTR"
                                                                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="optionekle"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="labels">
                                                                        Þýk EN
                                                                    </td>
                                                                    <td class="inputs">
                                                                        <asp:TextBox ID="txtOptionEn" runat="server" ValidationGroup="optionekle"></asp:TextBox>
                                                                        &nbsp;<asp:RequiredFieldValidator ID="exreftxtOption0" runat="server" ControlToValidate="txtOptionEn"
                                                                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="optionekle"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="inputs">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="inputs">
                                                                        <asp:Button ID="exbtnOptionEkle" runat="server" CssClass="btnKaydet" OnClick="exbtnOptionEkle_Click"
                                                                            Text="+ Ekle" ValidationGroup="optionekle" />
                                                                        <asp:Literal ID="exltOptionUyari" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                        <asp:Button ID="exbtnSoruKayit" runat="server" CssClass="btnKritik" Text="Soruyu Kaydet"
                                            OnClick="exbtnSoruKayit_Click" ValidationGroup="soru" />
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
            <cc1:ModalPopupExtender ID="mpOption" CancelControlID="btnVazgecFiltre" runat="server"
                TargetControlID="exbtnSoruEkle" PopupControlID="pnlAra">
            </cc1:ModalPopupExtender>
        </asp:View>
        <asp:View ID="vOylayanlar" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        Testi Cevaplayan Kullanýcýlar
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="exgvMembers" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                            OnPageIndexChanging="exgvMembers_PageIndexChanging" OnRowDataBound="exgvMembers_RowDataBound"
                            Width="100%" EmptyDataText="Testi cevaplayan kullanýcý bulunamadý!" OnRowCommand="exgvMembers_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="NAME" HeaderText="Adý" />
                                <asp:BoundField DataField="SURNAME" HeaderText="Soyadý" />
                                <asp:BoundField DataField="MEMBERSHIPTYPE" HeaderText="Kullanýcý Tipi" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSonuclar" runat="server" CommandName="Sonuclar" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/ara.gif" />
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
                        <asp:Button ID="exbtnTestler" runat="server" CssClass="btn" OnClick="exbtnTestler_Click"
                            Text="<< Testlere Dön" />
                        <asp:ImageButton ID="ibHepsiniYazdir" runat="server" ImageUrl="~/images/word.jpg"
                            OnClick="ibHepsiniYazdir_Click" />
                        &nbsp;<asp:ImageButton ID="ibExcelHepsi" runat="server" ImageUrl="~/images/excel.jpg"
                            OnClick="ibExcelHepsi_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vSonuclar" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td>
                        <asp:GridView ID="exgvSIKLAR" runat="server" AutoGenerateColumns="false" EmptyDataText="Lütfen soru giriniz!"
                            OnRowCommand="exgvSIKLAR_RowCommand" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="SurveyOption_TR" HeaderText="Þýk" />
                                <asp:BoundField DataField="SurveyOption_EN" HeaderText="Þýk (Ýngilizce)" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibSil" runat="server" CausesValidation="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyOptionID") %>'
                                            CommandName="Sil" ImageUrl="~/images/delete.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <uc2:ShowSurvey ID="ucShowSurvey" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="inputs">
                        <asp:Button ID="exbtnOylayanlar" runat="server" CssClass="btn" Text="<< Oylayan Kullanýcýlara Dön"
                            OnClick="exbtnOylayanlar_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vHepsiniYazdir" runat="server">
            <asp:GridView ID="exgvHepsi" AutoGenerateColumns="false" runat="server" OnRowDataBound="exgvHepsi_RowDataBound"
                Width="100%" DataKeyNames="RECID" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Literal ID="exltMember" runat="server"></asp:Literal>
                            <asp:GridView ID="exgvSorular" ShowHeader="false" runat="server" AutoGenerateColumns="false"
                                Width="100%" OnRowDataBound="exgvSorular_RowDataBound" DataKeyNames="SurveyQuestionID">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:GridView ID="exgvSiklar" AutoGenerateColumns="false" runat="server" Width="100%"
                                                DataKeyNames="inputtypeid,SurveyQuestionID,SurveyOptionID" OnRowDataBound="exgvSiklar_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Literal ID="exltGorunum" runat="server" Visible="false"></asp:Literal>
                                                            <asp:RadioButtonList ID="exrblOptions" runat="server" RepeatDirection="Horizontal"
                                                                Visible="false" Style="border: 10px; margin-left: 10px;">
                                                            </asp:RadioButtonList>
                                                            <asp:TextBox ID="txtOption" runat="server" Visible="false" ReadOnly="true"></asp:TextBox>
                                                            <asp:CheckBoxList ID="excbOptions" RepeatDirection="Horizontal" runat="server" Visible="false"
                                                                Enabled="false">
                                                            </asp:CheckBoxList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
