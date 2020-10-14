<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Maillist.aspx.cs" Inherits="Web.Admin.Maillist" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                            OnRowCommand="gvListe_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="RECID" HeaderText="RECID" />
                                <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
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
            </table>
        </asp:View>
        <asp:View ID="vKayitGir" runat="server">
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        RECID
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtRECID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        NAME
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtNAME" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        EMAIL
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtEMAIL" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
