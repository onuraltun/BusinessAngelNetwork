<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Advisors.aspx.cs" Inherits="Web.Entrepreneur.Advisors" %>

<%@ Register Src="../ASCX/MessageMainPanel.ascx" TagName="MessageMainPanel" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/SurveyList.ascx" TagName="SurveyList" TagPrefix="uc2" %>
<%@ Register Src="../ASCX/Events.ascx" TagName="Events" TagPrefix="uc3" %>
<%@ Register Src="../ASCX/Training.ascx" TagName="Training" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ctphLeft" runat="server">
    <uc1:MessageMainPanel ID="mesajpane" runat="server" />
    <br />
    <br />
    <uc2:SurveyList ID="mysurveylist" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ctphMiddle" runat="server">
    <table width="100%">
        <tr>
            <td class="Baslik">
                <asp:Literal ID="ltawaitingProfessionalRequests" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table class="belgeHeader">
        <tr>
            <td class="inputs">
                <asp:GridView ID="gvListe" runat="server" AutoGenerateColumns="false" Width="100%"
                    OnRowCommand="gvListe_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="PROJECTNAME" HeaderText="PROJECTNAME" />
                        <asp:BoundField DataField="NAMESURNAME" HeaderText="ProfessionalNAMESURNAME" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibDanismanlar" runat="server" CausesValidation="false" CommandName="AddPro"
                                    OnRowCommand="gvListe_RowCommand" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                    ImageUrl="~/images/add.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="ctphRight" ContentPlaceHolderID="ctphRight" runat="server">
    <uc3:Events ID="myeventn" runat="server" />
    <br />
    <br />
    <uc4:Training ID="mytrain" runat="server" />
</asp:Content>
