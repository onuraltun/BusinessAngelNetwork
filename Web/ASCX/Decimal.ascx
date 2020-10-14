<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Decimal.ascx.cs" Inherits="Web.ASCX.Decimal" %>
<div style="width:156px; height:25px">
<asp:TextBox ID="txtDecimal" runat="server"></asp:TextBox>
<AjaxControlToolkit:MaskedEditExtender ID="txtDecimal_MaskedEditExtender"
    runat="server" InputDirection="RightToLeft" Mask="9,999,999.99" MaskType="Number"
    TargetControlID="txtDecimal">
</AjaxControlToolkit:MaskedEditExtender>
<AjaxControlToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
    ControlExtender="txtDecimal_MaskedEditExtender" ControlToValidate="txtDecimal"
    EmptyValueMessage="*" ErrorMessage="*" InvalidValueMessage="*" IsValidEmpty="False"
    MaximumValueMessage="*" MinimumValue="0"></AjaxControlToolkit:MaskedEditValidator>
</div>