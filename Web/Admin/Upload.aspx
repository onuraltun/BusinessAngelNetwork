<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Upload.aspx.cs" Inherits="Web.Admin.Upload" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ctphMiddle" runat="server">
    <asp:FileUpload runat="server" ID="File1" />
    <br />
    <asp:Button runat="server" ID="btnUpload" />
    <br />
    <br />
    <asp:Button runat="server" ID="btnRefresh" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="File">
                <ItemTemplate>
                    <a href="<%#DataBinder.Eval(Container.DataItem,"URL") %>" target="_blank">
                        <%#DataBinder.Eval(Container.DataItem,"Name") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <table class="belgeHeader" width="100%">
                        <tr>
                            <td class="inputs">
                                <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Name") %>' ImageUrl="~/images/delete.png" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
