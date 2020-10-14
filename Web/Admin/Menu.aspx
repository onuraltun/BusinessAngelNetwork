<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Menu.aspx.cs" Inherits="Web.Admin.Menu" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvMenuler" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="MenuID"
                            OnRowCommand="gvListe_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="TextEng" HeaderText="Text Eng" />
                                <asp:BoundField DataField="TextTR" HeaderText="Text TR" />
                                <asp:BoundField DataField="link" HeaderText="Link" />
                                <asp:BoundField DataField="OrderValue" HeaderText="Order Value" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MenuID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MenuID") %>' ImageUrl="~/images/delete.png" />
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
                        <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet" OnClick="btnYeniKayit_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vKayitGir" runat="server">
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltTextEng" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtTextEng" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtTextEng" runat="server" ControlToValidate="txtTextEng"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblTextTR" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtTextTR" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="reftxtTextTR" runat="server" ControlToValidate="txtTextTR"
                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblLink" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblPageLink" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:DropDownList ID="exdrpPageLink" runat="server" OnTextChanged="exdrpPageLink_TextChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltParentMenu" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:DropDownList ID="exdrpParentMenu" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltOrderValue" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtOrderValue" runat="server"></asp:TextBox>
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
