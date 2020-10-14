<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="MyEntrepreneur.aspx.cs" Inherits="Web.Professional.MyEntrepreneur"
    EnableEventValidation="false" %>

<%@ Register Src="../ASCX/CV.ascx" TagName="CV" TagPrefix="uc1" %>
<%@ Register Src="../ASCX/WriteMessage.ascx" TagName="WriteMessage" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <asp:MultiView ID="mvProjects" runat="server" ActiveViewIndex="0">
        <asp:View ID="vListe" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltMyEntrepreneur" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:GridView ID="gvListe" runat="server" Width="100%" DataKeyNames="MemberID" AutoGenerateColumns="false"
                            OnRowCommand="gvListe_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="adisoyadi" HeaderText="namesurname" />
                                <asp:BoundField DataField="projectname" HeaderText="lblProjectName" />
                                <asp:BoundField DataField="ACRONYM" HeaderText="ACRONYM" />
                                <asp:BoundField DataField="MODIFICATIONDATE" HeaderText="MODiFiCATiONDATE" HtmlEncode="false"
                                    DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="belgeHeader" width="100%">
                                            <tr>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="detay"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MemberID") %>' ImageUrl="~/images/professional.png" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibPRoje" runat="server" CausesValidation="false" CommandName="proje"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PROJEID") %>' ImageUrl="~/images/ara.gif" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibPPT" runat="server" CausesValidation="false" CommandName="pptDownload"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PROJEID") %>' ImageUrl="~/images/ppt.JPG" />
                                                </td>
                                                <td class="inputs">
                                                    <asp:ImageButton ID="ibSendMessage" runat="server" CommandName="Mail" CausesValidation="false"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MemberID") %>' ImageUrl="~/images/mail.png" />
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
        <asp:View ID="vDetay" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltBusinessBriefReport" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader" width="100%">
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectName" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectAcronym" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtAcronym" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProjectOneLinePitch" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtProjectOneLinePitch" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblSector2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        &nbsp;<asp:Literal ID="exltSektor" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBusinessSummary" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtBusinessSummary" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblManagement" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtManagement" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCustomErProblem" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtCustomerProblem" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblProductorServices" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtProductorServices" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblTargetMarket" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtTargetMarket" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCustomers" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtCustomers" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblStrategy" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtStrategy" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblBusinessModelType" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        &nbsp;<asp:Literal ID="exltBusinessModelType" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblCompetitors" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtComptetitors" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="lblComptetitiveAdvange" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="extxtComptetitiveAdvange" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltinvestmentAmount3" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        &nbsp;<asp:Literal ID="exltInvestmenAmount" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        <asp:Literal ID="ltisCertified" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:Literal ID="exltIsCertfied" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:ImageButton ID="ibExcel0" runat="server" ImageUrl="~/images/word.jpg" OnClick="ibExcel0_Click" />
                        &nbsp;<asp:Button ID="btnReturnProjectList" runat="server" CssClass="btn" CausesValidation="False"
                            OnClick="btnVazgec_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vMail" runat="server">
            <table width="100%">
                <tr>
                    <td class="Baslik">
                        <asp:Literal ID="ltSendMessage" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <uc2:WriteMessage ID="ucWriteMessage" runat="server" />
            <table class="belgeHeader">
                <tr>
                    <td class="inputs">
                        <asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
