<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Inbox.ascx.cs" Inherits="Web.ASCX.Inbox" %>
<asp:MultiView ID="mvMesajlar" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal runat="server" ID="ltinbox"></asp:Literal>
                </td>
            </tr>
        </table>
        <table class="belgeHeader" width="100%">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="gvMesajlar" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID,STATUS"
                        Width="100%" OnRowDataBound="gvMesajlar_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvMesajlar_PageIndexChanging"
                        OnRowCommand="gvMesajlar_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="FROM_USER">
                                <ItemTemplate>
                                    <asp:LinkButton ID="exlbFromUser" runat="server" CommandName="lbOku" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SUBJECT">
                                <ItemTemplate>
                                    <asp:LinkButton ID="exlbSubject" runat="server" CommandName="lbOku" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                        Text='<%#DataBinder.Eval(Container.DataItem,"SUBJECT") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SENDDATE" HeaderText="SENDDATE" HtmlEncode="false" DataFormatString="{0:dd.MM.yyyy}" />
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
                    <asp:Button ID="btnYeniMesaj" runat="server" CssClass="btnKaydet" OnClick="btnYeniMesaj_Click" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="vOku" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal runat="server" ID="ltMessageReadPanel"></asp:Literal>
                </td>
            </tr>
        </table>
        <table class="belgeHeader" width="100%">
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltKimden" runat="server"></asp:Literal>
                </td>
                <td class="inpust">
                    <asp:Literal ID="exltFrom" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltMailKonusu" runat="server"></asp:Literal>
                </td>
                <td class="inpust">
                    <asp:Literal ID="exltMailSubject" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltMailMessage" runat="server"></asp:Literal>
                </td>
                <td class="inpust">
                    <asp:Literal ID="exltMailMessage" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    &nbsp;
                </td>
                <td class="inpust">
                    <asp:Button ID="btnReplyMessage" runat="server" CssClass="btn" OnClick="btnReplyMessage_Click" />
                    &nbsp;<asp:Button ID="btnReturninbox" runat="server" CssClass="btnListele" OnClick="btnReturninbox_Click"
                        CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="vGonder" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal runat="server" ID="ltMessageWritePanel"></asp:Literal>
                </td>
            </tr>
        </table>
        <table class="belgeHeader" width="100%">
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltKime" runat="server"></asp:Literal>
                </td>
                <td class="inpust">
                    <asp:DropDownList ID="exdrpTo" runat="server">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="excvexdrpTo" runat="server" ControlToValidate="exdrpTo"
                        ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                        ValueToCompare="0" ValidationGroup="sendmessage"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltKonu" runat="server"></asp:Literal>
                </td>
                <td class="inpust">
                    <asp:TextBox ID="txtKonu" runat="server" MaxLength="50" Width="420px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="exreftxtKonu" runat="server" ControlToValidate="txtKonu"
                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="sendmessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal ID="ltMesaj" runat="server"></asp:Literal>
                </td>
                <td class="inpust">
                    <asp:TextBox ID="txtMesaj" runat="server" Width="420px" Height="213px" TextMode="MultiLine"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="exreftxtMesaj" runat="server" ControlToValidate="txtMesaj"
                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="sendmessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    &nbsp;
                </td>
                <td class="inpust">
                    <asp:Button ID="btnMesajGonder" runat="server" CssClass="button-mailsend" OnClick="btnMesajGonder_Click"
                        ValidationGroup="sendmessage" />
                    &nbsp;<asp:Button ID="btnMesajKaydet" runat="server" OnClick="btnMesajKaydet_Click"
                        ValidationGroup="sendmessage" CssClass="button-draftmail" />
                    &nbsp;<asp:Button ID="btnReturninboxx" runat="server" CssClass="btnListele" OnClick="btnReturninbox_Click"
                        CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
