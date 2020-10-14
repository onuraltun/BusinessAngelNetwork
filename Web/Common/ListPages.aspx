<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="ListPages.aspx.cs" Inherits="Web.ListPages" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <table width="100%">
        <tr>
            <td style="text-align: left">
                <asp:Literal runat="server" ID="exlblTitle"></asp:Literal><br />
                <asp:Literal runat="server" ID="exlblPage"></asp:Literal>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvListe" OnRowDataBound="gvListe_RowDataBound" runat="server" OnRowCommand="gvListe_RowCommand"
        AutoGenerateColumns="False" DataKeyNames="RECID">
        <Columns>
            <asp:BoundField DataField="TITLE" HtmlEncode="false" HeaderText="TITLE" />
            <asp:BoundField DataField="TITLEENG" HtmlEncode="false" HeaderText="TITLEENG" />
            <asp:BoundField DataField="CREATIONDATE" HeaderText="CREATIONDATE" />
            <asp:TemplateField>
                <ItemTemplate>
                    <table class="belgeHeader" width="100%">
                        <tr>
                            <td class="inputs">
                                <asp:ImageButton ID="ibView" runat="server" CausesValidation="false" CommandName="View"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/ara.gif" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
