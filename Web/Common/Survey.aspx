<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Survey.aspx.cs" Inherits="Web.Common.Survey" EnableEventValidation="false" %>

<%@ Register Src="../ASCX/AssesSurvey.ascx" TagName="AssesSurvey" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/ShowSurvey.ascx" TagName="ShowSurvey" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvSurvey" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltSurveyList" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvSurvey" runat="server" Width="100%" DataKeyNames="SurveyID,Subject_EN"
                            AutoGenerateColumns="false" OnRowCommand="exgvSurvey_RowCommand" EmptyDataText="Kayýt bulunamadý!"
                            OnRowDataBound="exgvSurvey_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Subject_TR" HeaderText="Konusu" />
                                <asp:BoundField DataField="DateStart" HeaderText="Baþlangýç Tarihi" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="DateEnd" HeaderText="Bitiþ Tarihi" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td id="tdDegerlendir" runat="server" visible="false" class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyID") %>' ImageUrl="~/images/update.gif" />
                                                </td>
                                                <td id="tdGoster" runat="server" visible="false" class="inputs">
                                                    <asp:ImageButton ID="ibSonuclar" runat="server" CommandName="Sonuc" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SurveyID") %>' ImageUrl="~/images/ara.gif" />
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
        <asp:View ID="vDegerlendirme" runat="server">
            <uc1:AssesSurvey ID="ucTestYap" runat="server" />
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnReturnSurveyList" runat="server" CssClass="btnListele" OnClick="btnReturnSurveyList_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vGoruntuleme" runat="server">
            <uc2:ShowSurvey ID="ucTestiGor" runat="server" />
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnReturnSurveyList2" runat="server" CssClass="btnListele" OnClick="btnReturnSurveyList_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
