<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEventToForum.ascx.cs"
    Inherits="Web.ASCX.AddEventToForum" %>
<asp:LinkButton runat="server" ID="lbAddEvent" Style="display: none"></asp:LinkButton>
<asp:Panel ID="pnlFile" runat="server" Style="display: none;" Width="650px" HorizontalAlign="Left">
    <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="PencereSolUstKose">
            </td>
            <td class="PencereTransparan">
            </td>
            <td class="PencereSagUstKose">
            </td>
        </tr>
        <tr>
            <td class="PencereTransparan">
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="white">
                    <tr>
                        <td valign="top" class="PencereBaslik">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <b>
                                            <asp:Literal runat="server" ID="ltAddEvent"></asp:Literal></b>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnVazgecFiltre2" runat="server" Text="X" CssClass="PencereKapat"
                                            ToolTip="Pencereyi kapatmak için tıklayınız..." />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="PencereDetay">
                        </td>
                    </tr>
                    <tr>
                        <td class="PencereDetay">
                            <table class="belgeHeader" width="100%" runat="server" id="tblEvent" visible="false">
                                <tr>
                                    <td class="labels">
                                        &nbsp;
                                    </td>
                                    <td class="inputs">
                                        <asp:Literal ID="ltValidate" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="lblName" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="reftxtName" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="lblNameEng" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtNameEng" runat="server"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="reftxtNameEng" runat="server" ControlToValidate="txtNameEng"
                                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="lblLocation" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtLocation" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="lblBody" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtBody" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="ltBodyEng" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtBodyEng" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="lblDate" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                        <AjaxControlToolkit:MaskedEditExtender ID="txtDate_MaskedEditExtender" runat="server"
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" DisplayMoney="Right" Enabled="True" Mask="99/99/9999 99:99:99"
                                            MaskType="DateTime" TargetControlID="txtDate">
                                        </AjaxControlToolkit:MaskedEditExtender>
                                        <AjaxControlToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                            ControlExtender="txtDate_MaskedEditExtender" ControlToValidate="txtDate" EmptyValueMessage="*"
                                            InvalidValueMessage="*" IsValidEmpty="False" MinimumValue="01.01.2008 00:00:00"
                                            MinimumValueMessage="*"></AjaxControlToolkit:MaskedEditValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="labels">
                                        <asp:Literal ID="lbEventType" runat="server"></asp:Literal>
                                    </td>
                                    <td class="inputs">
                                        <asp:DropDownList ID="drpEventType" runat="server">
                                        </asp:DropDownList>
                                        &nbsp;<asp:CompareValidator ID="cvdrpEventType" runat="server" ControlToValidate="drpEventType"
                                            ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                                            ValueToCompare="0"></asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table class="belgeHeader" width="100%">
                    <tr>
                        <td class="labels">
                        </td>
                        <td class="inputs">
                            <asp:Button ID="btnAddEvent" runat="server" CssClass="btnListele" Text="Gönder" OnClick="btnAddEvent_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="PencereTransparan">
            </td>
        </tr>
        <tr>
            <td class="PencereSolAltKose">
            </td>
            <td class="PencereTransparan">
            </td>
            <td class="PencereSagAltKose">
            </td>
        </tr>
    </table>
</asp:Panel>
<AjaxControlToolkit:ModalPopupExtender ID="mpFiltre2" CancelControlID="btnVazgecFiltre2"
    runat="server" TargetControlID="lbAddEvent" PopupControlID="pnlFile">
</AjaxControlToolkit:ModalPopupExtender>
<table width="100%">
    <tr>
        <td class="Baslik">
            <asp:Literal runat="server" ID="ltApprovedProject"></asp:Literal>
        </td>
    </tr>
</table>
<asp:GridView ID="gvProject" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProject_RowCommand"
    DataKeyNames="RECID">
    <Columns>
        <asp:BoundField DataField="ACRONYM" HeaderText="PROJECT" />
        <asp:TemplateField HeaderText="ADDEVENT">
            <ItemTemplate>
                <table class="belgeHeader" width="100%">
                    <tr>
                        <td class="inputs">
                            <asp:ImageButton CssClass="tip" ToolTip="ADDEVENT" ID="ibView" runat="server" CausesValidation="false"
                                CommandName="AddEvent" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                ImageUrl="~/images/bplan.png" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
