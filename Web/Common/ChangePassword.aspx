<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Web.ChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ctphMiddle" runat="server">
    <table width="100%">
        <tr>
            <td class="Baslik">
                <asp:Literal ID="ltPasswordChangeHeader" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <table>
        <tr runat="server" id="tr1">
            <td class="labels">
                <asp:Literal runat="server" ID="ltOldPassword"></asp:Literal>
            </td>
            <td class="inputs">
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
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
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnChange" CssClass="btnKaydet" runat="server" OnClick="btnActivate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
