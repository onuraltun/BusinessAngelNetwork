<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Search.aspx.cs" Inherits="Web.Common.Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvAktiviteler" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal runat="server" ID="ltSearchResults"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID">
                            <Columns>
                                <asp:TemplateField HeaderText="Pages">
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <a href="/Common/ViewPage.aspx?p=<%#DataBinder.Eval(Container.DataItem,"RECID") %>">
                                                        <%#DataBinder.Eval(Container.DataItem,"TITLE") %></a><br />
                                                    <%#DataBinder.Eval(Container.DataItem,"BODY") %><br />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attend">
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <a href="/Common/ViewPage.aspx?p=<%#DataBinder.Eval(Container.DataItem,"RECID") %>">
                                                        <%#DataBinder.Eval(Container.DataItem,"TITLEENG") %></a><br />
                                                    <%#DataBinder.Eval(Container.DataItem,"BODYENG") %><br />
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
    </asp:MultiView>
</asp:Content>
