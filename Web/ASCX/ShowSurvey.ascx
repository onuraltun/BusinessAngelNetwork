<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowSurvey.ascx.cs"
    Inherits="Web.ASCX.ShowSurvey" %>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal ID="exltTest" runat="server"></asp:Literal>
        </td>
    </tr>
</table>
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
                                    Visible="false" Style="border: 10px; margin-left: 10px;">
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtOption" runat="server" Visible="false" ReadOnly="true"></asp:TextBox>
                                <asp:CheckBoxList ID="excbOptions" RepeatDirection="Horizontal" runat="server" Visible="false"
                                    Enabled="false">
                                </asp:CheckBoxList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ImageButton ID="ibExcel" runat="server" ImageUrl="~/images/word.jpg" OnClick="ibExcel_Click" />
