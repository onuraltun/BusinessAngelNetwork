<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Log.aspx.cs" Inherits="Web.Admin.Log" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <table width="100%">
        <tr>
            <td class="Baslik">
                Log Kayýtlarý
            </td>
        </tr>
    </table>
    <table class="belgeHeader" width="100%">
        <tr>
            <td class="inputs">
                <asp:GridView ID="gvLoglar" runat="server" AutoGenerateColumns="false" Width="100%"
                    AllowPaging="True" OnPageIndexChanging="gvLoglar_PageIndexChanging" EmptyDataText="Log Kaydý Bulunamadý!">
                    <Columns>
                        <asp:BoundField DataField="USERNAMEUSRNAME" HeaderText="Adý Soyadý" />
                        <asp:BoundField DataField="OPDATE" HeaderText="Ýþlem Tarihi" />
                        <asp:BoundField DataField="IPADDRESS" HeaderText="IPAdres" />
                        <asp:BoundField DataField="DETAIL" HeaderText="Detay" HtmlEncode="False" />
                        <asp:BoundField DataField="TABLENAME" HeaderText="Tablo" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="inputs">
                <asp:Button ID="btnAra" runat="server" CssClass="btnListele" Text="Filtrele" />
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
                                <asp:UpdatePanel ID="upMuhabirAra" runat="server">
                                    <ContentTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="labels">
                                                    Tarih Aralýðý:
                                                </td>
                                                <td class="inputs">
                                                    <uc1:Takvim ID="tvFiltrelemeBaslangic" runat="server" />
                                                    &nbsp;-
                                                    <uc1:Takvim ID="tvFiltrelemeBitis" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labels">
                                                    Ýþlem Türü:
                                                </td>
                                                <td class="inputs">
                                                    <asp:DropDownList ID="exdrpIslemTuru" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="labels">
                                                    Kullanýcý Tipi:
                                                </td>
                                                <td class="inputs">
                                                    <asp:DropDownList ID="drpMemberShipType" runat="server">
                                                    </asp:DropDownList>
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
                                <asp:Button ID="btnFiltrele" runat="server" CssClass="btnListele" Text="Loglarda Ara"
                                    OnClick="btnFiltrele_Click" />
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
    <cc1:ModalPopupExtender ID="mpFiltre" CancelControlID="btnVazgecFiltre" runat="server"
        TargetControlID="btnAra" PopupControlID="pnlAra">
    </cc1:ModalPopupExtender>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ctphMiddle" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ctphRight" runat="server">
</asp:Content>
