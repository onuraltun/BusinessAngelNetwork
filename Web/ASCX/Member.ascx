<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Member.ascx.cs" Inherits="Web.ASCX.Member" %>
<%@ Register Src="Decimal.ascx" TagName="Decimal" TagPrefix="uc1" %>
<%@ Register Src="Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<asp:MultiView ID="mvListe" runat="server" ActiveViewIndex="0">
    <asp:View ID="vListe" runat="server">
        <table class="belgeHeader">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="gvListe" OnRowDataBound="gvListe_RowDataBound" runat="server" OnRowCommand="gvListe_RowCommand"
                        AutoGenerateColumns="False" DataKeyNames="RECID,SUPERVISORAPPROVED">
                        <Columns>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="SURNAME" HeaderText="SURNAME" />
                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                            <asp:BoundField DataField="MEMBERSHIPTYPE" HeaderText="MEMBERSHIPTYPE" />
                            <asp:CheckBoxField DataField="MEMBERAPPROVED" HeaderText="MEMBERAPPROVED" />
                            <asp:CheckBoxField DataField="SUPERVISORAPPROVED" HeaderText="SUPERVISORAPPROVED" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbViewMemberShort" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                        CausesValidation="false" CssClass="tip" OnClientClick="#" Text="View"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table class="belgeHeader" width="100%">
                                        <tr>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibView" runat="server" CausesValidation="false" CommandName="Goster"
                                                    ToolTip="View" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                    ImageUrl="~/images/ara.gif" />
                                            </td>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibOnayla" runat="server" CausesValidation="false" CommandName="Onayla"
                                                    ToolTip="Accept" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                    ImageUrl="~/images/accept.png" />
                                            </td>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibOnayKaldir" runat="server" CausesValidation="false" CommandName="OnayKaldir"
                                                    ToolTip="Remove Accept" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                    ImageUrl="~/images/exclamation.png" />
                                            </td>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibSec" runat="server" CausesValidation="false" CommandName="Sec"
                                                    ToolTip="Update" CssClass="tip" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>'
                                                    ImageUrl="~/images/update.gif" />
                                            </td>
                                            <td class="inputs">
                                                <asp:ImageButton ID="ibSil" runat="server" CommandName="Sil" CausesValidation="false"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RECID") %>' ImageUrl="~/images/delete.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="inputs">
                    <asp:Button ID="btnYeniKayit" runat="server" CssClass="btnKaydet" OnClick="btnYeniKayit_Click"
                        Visible="false" />
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="vKayitGir" runat="server">
        <table class="belgeHeader" width="100%">
            <tr runat="server" id="trMembershipType" visible="false">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltMembershipType"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:DropDownList ID="drpMembershipType" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpMembershipType"
                        ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                        ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:DropDownList ID="drpTitle" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:CompareValidator ID="cvdrpTitle" runat="server" ControlToValidate="drpTitle"
                        ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                        ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltName"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtNAME" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNAME"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltSurname"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtSURNAME" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCONFIRMPASSWORD"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr runat="server" id="trEmail">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltEmail"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtEMAIL" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEMAIL"
                        ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEMAIL"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr runat="server" id="trPassword">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltPassword"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtPASSWORD" runat="server" TextMode="Password"></asp:TextBox>
                    <AjaxControlToolkit:PasswordStrength ID="txtPASSWORD_PasswordStrength" runat="server"
                        TargetControlID="txtPASSWORD" StrengthIndicatorType="BarIndicator" MinimumNumericCharacters="1"
                        MinimumSymbolCharacters="0" PreferredPasswordLength="8" RequiresUpperAndLowerCaseCharacters="true"
                        BarBorderCssClass="BarBorder" BarIndicatorCssClass="BarIndicator">
                    </AjaxControlToolkit:PasswordStrength>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPASSWORD"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr runat="server" id="trConfirmPassword">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltConfirmPassword"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtCONFIRMPASSWORD" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPASSWORD"
                        ControlToValidate="txtCONFIRMPASSWORD" ErrorMessage="*" SetFocusOnError="True"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCONFIRMPASSWORD"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltCompanyName"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtCOMPANYNAME" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltPosition"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtPOSITION" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltAddress"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtADDRESS" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtADDRESS"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <table border="0" width="100%">
                        <tr>
                            <td class="labels">
                                <asp:Literal runat="server" ID="ltCITY"></asp:Literal>:
                            </td>
                            <td class="inputs">
                                <asp:TextBox ID="txtCITY" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCITY"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal runat="server" ID="ltPROVINCE"></asp:Literal>:
                            </td>
                            <td class="inputs">
                                <asp:TextBox ID="txtPROVINCE" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPROVINCE"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal runat="server" ID="ltCOUNTRY"></asp:Literal>:
                            </td>
                            <td class="inputs">
                                <asp:TextBox ID="txtCOUNTRY" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCOUNTRY"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                <asp:Literal runat="server" ID="ltPOSTALCODE"></asp:Literal>:
                            </td>
                            <td class="inputs">
                                <asp:TextBox ID="txtPOSTALCODE" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPOSTALCODE"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltTelephone"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtTELEPHONE" runat="server"></asp:TextBox>
                    <AjaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="(999) 999 99 99" MaskType="Number" TargetControlID="txtTELEPHONE"
                        AutoComplete="False" ClearMaskOnLostFocus="False">
                    </AjaxControlToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltFax"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtFAX" runat="server"></asp:TextBox>
                    <AjaxControlToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="(999) 999 99 99" MaskType="Number" TargetControlID="txtFAX"
                        AutoComplete="False" ClearMaskOnLostFocus="False">
                    </AjaxControlToolkit:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <asp:Literal runat="server" ID="ltMobileNumber"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtMOBILENUMBER" runat="server"></asp:TextBox>
                    <AjaxControlToolkit:MaskedEditExtender ID="meetxtMOBILENUMBER" runat="server" CultureAMPMPlaceholder=""
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                        Enabled="True" Mask="(999) 999 99 99" MaskType="Number" TargetControlID="txtMOBILENUMBER"
                        AutoComplete="False" ClearMaskOnLostFocus="False">
                    </AjaxControlToolkit:MaskedEditExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                        ControlToValidate="txtMOBILENUMBER"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr runat="server" id="trAmount">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltAmountsPerInvestments"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:TextBox ID="txtAMOUNTSPERINVESTMENT" runat="server"></asp:TextBox>
                    <AjaxControlToolkit:MaskedEditExtender ID="txtAMOUNTSPERINVESTMENT_MaskedEditExtender"
                        runat="server" InputDirection="RightToLeft" Mask="999,999,999.99" MaskType="Number"
                        TargetControlID="txtAMOUNTSPERINVESTMENT">
                    </AjaxControlToolkit:MaskedEditExtender>
                    <AjaxControlToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                        ControlExtender="txtAMOUNTSPERINVESTMENT_MaskedEditExtender" ControlToValidate="txtAMOUNTSPERINVESTMENT"
                        EmptyValueMessage="*" ErrorMessage="*" InvalidValueMessage="*" IsValidEmpty="False"
                        MaximumValueMessage="*" MinimumValue="0"></AjaxControlToolkit:MaskedEditValidator>
                </td>
            </tr>
            <tr runat="server" id="trInvestorType">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltInvestorType"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:DropDownList ID="drpInvestorType" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:CompareValidator ID="cvdrpInvestorType" runat="server" ControlToValidate="drpInvestorType"
                        ErrorMessage="*" Operator="GreaterThan" SetFocusOnError="True" Type="Integer"
                        ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr runat="server" id="trSector">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltInterestedSectors"></asp:Literal>
                </td>
                <td class="inputs">
                    <asp:ListBox ID="lbSector" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr runat="server" id="trExpertise">
                <td class="labels">
                    <asp:Literal runat="server" ID="ltExpertise"></asp:Literal>
                </td>
                <td class="inputs">
                    <uc2:Aciklama ID="txtExpertise" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    &nbsp;
                </td>
                <td class="inputs">
                    <asp:Button ID="btnKaydet" runat="server" CssClass="btnKritik" OnClick="btnKaydet_Click" />
                    &nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" CausesValidation="False"
                        OnClick="btnVazgec_Click" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>