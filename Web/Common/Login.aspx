<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ctphMiddle" runat="server">
    <asp:Panel runat="server" ID="pnlLogin" DefaultButton="btnLogin">
        <table width="100%" height="300" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" valign="middle">
                    <table width="401" height="187" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td runat="server" id="tdLogin" class="LoginBG">
                                <br />
                                <br />
                                <table width="280" border="0" cellspacing="4" cellpadding="0">
                                    <tr>
                                        <td width="80" class="LoginTitle">
                                            <b>
                                                <asp:Literal ID="ltEmail" runat="server"></asp:Literal>
                                            </b>
                                        </td>
                                        <td width="12" class="LoginTitle">
                                            <b>:</b>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserName" Width="160px" runat="server" MaxLength="30"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="lblEmailGir" runat="server" ControlToValidate="txtUserName"
                                                SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="lblHataliEmail" runat="server" ControlToValidate="txtUserName"
                                                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="80" class="LoginTitle">
                                            <b>
                                                <asp:Literal ID="ltPassword" runat="server"></asp:Literal>
                                            </b>
                                        </td>
                                        <td width="12" class="LoginTitle">
                                            <b>:</b>
                                        </td>
                                        <td align="left" valign="middle">
                                            <asp:TextBox ID="txtPassword" Width="160px" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="lblSifreGir" runat="server" ControlToValidate="txtPassword"
                                                SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" valign="middle">
                                        </td>
                                        <td width="12" align="center" valign="middle">
                                        </td>
                                        <td align="left" valign="middle">
                                            <asp:CheckBox ID="cbRememberMe" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" valign="middle">
                                            &nbsp;
                                        </td>
                                        <td width="12" align="center" valign="middle">
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/giris.jpg" OnClick="btnLogin_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table border="0" width="401" height="30" cellpadding="1" cellspacing="0">
                        <tr>
                            <td style="background-color: #dddddd">
                                <table border="0" height="30" width="100%" cellpadding="1" cellspacing="0">
                                    <tr>
                                        <td style="background-color: #ffffff" align="center">
                                            <asp:LinkButton ID="lbForgotPassword" runat="server" CausesValidation="false"></asp:LinkButton>
                                            -
                                            <asp:LinkButton ID="lbRegister" runat="server" CausesValidation="false"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
