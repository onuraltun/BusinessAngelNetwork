<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="True"
    CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<%@ Register Src="../ASCX/Aciklama.ascx" TagName="Aciklama" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphMiddle" runat="server">
    <table>
        <tr>
            <td colspan="2" class="labels">
                <asp:Literal runat="server" ID="ltContactInfo"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="labels">
                <asp:Literal runat="server" ID="exLtResult"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="labels">
                <asp:Literal runat="server" ID="ltNameSurname"></asp:Literal>
            </td>
            <td class="inputs">
                <asp:TextBox ID="txtNameSurname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameSurname"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labels">
                <asp:Literal runat="server" ID="ltEmail"></asp:Literal>
            </td>
            <td class="inputs">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEMAIL"
                    ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEMAIL"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labels">
                <asp:Literal runat="server" ID="ltTelephone"></asp:Literal>
            </td>
            <td class="inputs">
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
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
                <asp:Literal ID="ltSubject" runat="server"></asp:Literal>
            </td>
            <td class="inputs">
                <asp:TextBox runat="server" ID="txtSubject"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labels">
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </td>
            <td class="inputs">
                <uc2:Aciklama ID="txtMessage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSend" CssClass="btnKaydet" runat="server" OnClick="btnSend_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
