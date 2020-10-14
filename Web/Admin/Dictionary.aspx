<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Dictionary.aspx.cs" Inherits="Web.Admin.Dictionary" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvKelimeler" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                            OnRowCommand="gvListe_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="CONTROLNAME" HeaderText="CONTROLNAME" />
                                <asp:BoundField DataField="ENGLISH" HeaderText="ENGLISH" />
                                <asp:BoundField DataField="TURKISH" HeaderText="TURKISH" />
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
                        <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet" Visible="false"
                            OnClick="btnYeniKayit_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayitGir" runat="server">
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblControlName" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="exltControlName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltEnglish" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtEnglish" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtEnglish" runat="server" ControlToValidate="txtEnglish"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblTurkish" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtTurkish" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtTurkish" runat="server" ControlToValidate="txtTurkish"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
</asp:Content>
