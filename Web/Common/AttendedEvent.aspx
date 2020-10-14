<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="AttendedEvent.aspx.cs" Inherits="Web.Common.AttendedEvent" %>

<%@ Register Src="../ASCX/Takvim.ascx" TagName="Takvim" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/File.ascx" TagName="File" TagPrefix="uc10" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvAktiviteler" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID"
                            OnRowCommand="gvListe_RowCommand" OnRowDataBound="gvListe_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr runat="server" id="trEVENTTYPE">
                                                <td class="inputs">
                                                    <%= DilCevir("EVENTTYPE")%>
                                                </td>
                                                <td class="inputs">
                                                    <asp:Literal runat="server" ID="exltEVENTTYPE"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trNAME">
                                                <td class="inputs">
                                                    <%= DilCevir("NAME")%>
                                                </td>
                                                <td class="inputs">
                                                    <%#DataBinder.Eval(Container.DataItem, "NAME")%>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trNAMEENG">
                                                <td class="inputs">
                                                    <%= DilCevir("NAMEENG") %>
                                                </td>
                                                <td class="inputs">
                                                    <%#DataBinder.Eval(Container.DataItem, "NAMEENG")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inputs">
                                                    <%= DilCevir("DATE")%>
                                                </td>
                                                <td class="inputs">
                                                    <%#DataBinder.Eval(Container.DataItem, "DATE")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inputs">
                                                    <%= DilCevir("LOCATION")%>
                                                </td>
                                                <td class="inputs">
                                                    <%#DataBinder.Eval(Container.DataItem, "LOCATION")%>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trDESCRIPTION">
                                                <td class="inputs">
                                                    <%= DilCevir("DESCRIPTION")%>
                                                </td>
                                                <td class="inputs">
                                                    <%#DataBinder.Eval(Container.DataItem, "DESCRIPTION")%>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trDESCRIPTIONENG">
                                                <td class="inputs">
                                                    <%= DilCevir("DESCRIPTIONENG")%>
                                                </td>
                                                <td class="inputs">
                                                    <%#DataBinder.Eval(Container.DataItem, "DESCRIPTIONENG")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Documents">
                                    <ItemStyle VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <uc10:File runat="server" ID="File1" FileType="USED_ON_EVENT" TableName="EVENT" TaskName="Guest" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attend">
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:Literal runat="server" ID="exltApproved"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Ekle"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/add.png" />
                                                    <asp:ImageButton ID="ibSil" runat="server" CausesValidation="false" CommandName="Sil"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ATTENDEDRECID") %>' ImageUrl="~/images/delete.png" />
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
