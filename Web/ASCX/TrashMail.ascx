<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrashMail.ascx.cs" Inherits="Web.ASCX.TrashMail" %>
<asp:MultiView ID="mvMesajlar" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <table width="100%">
            <tr>
                <td class="Baslik">
                    <asp:Literal runat="server" ID="ltsentMessagesPageHeader"></asp:Literal>
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
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="imgDirection" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TO/FROM_USER">
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
                        </Columns>
                    </asp:GridView>
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
                    &nbsp;<asp:Button ID="btnReturninbox" runat="server" CssClass="btnListele" OnClick="btnReturninbox_Click"
                        CausesValidation="False" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>