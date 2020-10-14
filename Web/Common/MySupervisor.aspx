<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="MySupervisor.aspx.cs" Inherits="Web.Common.MySupervisor" %>

<%@ Register Src="../ASCX/WriteMessage.ascx" TagName="WriteMessage" TagPrefix="uc10" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ctphMiddle" runat="server">
    <asp:GridView ID="gvListe" OnRowDataBound="gvListe_RowDataBound" runat="server" OnRowCommand="gvListe_RowCommand"
        AutoGenerateColumns="False" DataKeyNames="RECID">
        <Columns>
            <asp:BoundField DataField="NAME" HeaderText="NAME" />
            <asp:BoundField DataField="SURNAME" HeaderText="SURNAME" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbViewMemberShort" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                        CausesValidation="false" CssClass="tip" OnClientClick="#" Text="View"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table class="belgeHeader" width="100%">
                        <tr>
                            <td class="inputs">
                                <asp:ImageButton ID="ibView" runat="server" CausesValidation="false" CommandName="Message"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/mail.png" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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
                                                <asp:Literal runat="server" ID="ltFileTitle"></asp:Literal></b>
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
                                <contenttemplate>
                                        <uc10:WriteMessage runat="server" ID="WriteMessage1" />
                                    </contenttemplate>
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
    <asp:LinkButton runat="server" ID="ltHidden" Style="display: none"></asp:LinkButton>
    <AjaxControlToolkit:ModalPopupExtender ID="mpFiltre2" CancelControlID="btnVazgecFiltre2"
        runat="server" TargetControlID="ltHidden" PopupControlID="pnlFile">
    </AjaxControlToolkit:ModalPopupExtender>
    
    
</asp:Content>
