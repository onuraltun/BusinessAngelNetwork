<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssesSurvey.ascx.cs"
    Inherits="Web.ASCX.AssesSurvey" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal ID="exltTest" runat="server"></asp:Literal>
        </td>
    </tr>
</table>
<table class="belgeHeader">
    <tr>
        <td class="inputs">
            <asp:GridView ID="exgvSorular" ShowHeader="false" runat="server" AutoGenerateColumns="false"
                Width="100%" OnRowDataBound="exgvSorular_RowDataBound" DataKeyNames="SurveyQuestionID">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="exgvSiklar" AutoGenerateColumns="false" runat="server" Width="100%"
                                DataKeyNames="inputtypeid,SurveyQuestionID,SurveyOptionID" OnRowDataBound="exgvSiklar_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="exrblOptions" runat="server" RepeatDirection="Horizontal"
                                                Visible="false">
                                            </asp:RadioButtonList>
                                            <asp:TextBox ID="txtOption" runat="server" Visible="false"></asp:TextBox>
                                            <asp:CheckBoxList ID="excbOptions" RepeatDirection="Horizontal" runat="server" Visible="false">
                                            </asp:CheckBoxList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="inputs">
            <asp:Button ID="btnKaydet" CssClass="btnKritik" runat="server" OnClick="btnKaydet_Click" />
        </td>
    </tr>
</table>
