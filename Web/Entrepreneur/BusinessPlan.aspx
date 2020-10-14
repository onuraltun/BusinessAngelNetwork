<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true"
    CodeBehind="BusinessPlan.aspx.cs" Inherits="Web.Entrepreneur.BusinessPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctphTable" runat="server">
    <table class="belgeHeader">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="Baslik">
                            <asp:Literal ID="ltHeaderBusinessPlanForStartupProjects" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:MultiView ID="mvPlan" runat="server" ActiveViewIndex="0">
        <asp:View ID="vPlanA" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        A.<asp:Literal ID="ltBusinessPlanA" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; 1.<asp:Literal ID="ltBusinessPlanA1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.<asp:Literal ID="ltBusinessPlanA1a" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA1a" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.<asp:Literal ID="ltBusinessPlanA1b" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA1b" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.<asp:Literal ID="ltBusinessPlanA1c" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA1c" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; d.<asp:Literal ID="ltBusinessPlanA1d" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA1d" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanA2" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.<asp:Literal ID="ltBusinessPlanA2a" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA2a" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.<asp:Literal ID="ltBusinessPlanA2b" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA2b" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.<asp:Literal ID="ltBusinessPlanA2c" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtA2c" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanBSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanB" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        B.<asp:Literal ID="ltBusinessPlanB" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanB1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanB2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanB3" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB3" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels" colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp; 4.<asp:Literal ID="ltBusinessPlanB4" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.<asp:Literal ID="ltBusinessPlanB4a" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB4a" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.<asp:Literal ID="ltBusinessPlanB4b" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB4b" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.<asp:Literal ID="ltBusinessPlanB4c" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB4c" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5.<asp:Literal ID="ltBusinessPlanB5" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB5" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6.<asp:Literal ID="ltBusinessPlanB6" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtB6" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanCSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanASection" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanC" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        C.<asp:Literal ID="ltBusinessPlanC" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanC1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtC1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanC2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtC2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanC3" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtC3" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanDSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanBSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanD" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        D.<asp:Literal ID="ltBusinessPlanD" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanD1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtD1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanD2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtD2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanESection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanCSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanE" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        E.<asp:Literal ID="ltBusinessPlanE" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanE1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtE1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanE2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtE2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanE3" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtE3" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 4.<asp:Literal ID="ltBusinessPlanE4" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtE4" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 5.<asp:Literal ID="ltBusinessPlanE5" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtE5" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanFSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanDSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanF" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        F.<asp:Literal ID="ltBusinessPlanF" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanF1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtF1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanF2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtF2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanGSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanESection22" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanG" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        G.<asp:Literal ID="ltBusinessPlanG" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanG1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtG1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanHSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanFSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanH" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        H.<asp:Literal ID="ltBusinessPlanH" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanH1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtH1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanH2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtH2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanISection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanGSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanI" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        I.<asp:Literal ID="ltBusinessPlanI" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanI1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtI1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlan2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtI2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 3.<asp:Literal ID="ltBusinessPlanI3" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtI3" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 4.<asp:Literal ID="ltBusinessPlanI4" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtI4" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 5.<asp:Literal ID="ltBusinessPlanI5" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtI5" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanJSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanHSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanJ" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        J.<asp:Literal ID="ltBusinessPlanJ" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanJ1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtJ1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp; 2.<asp:Literal ID="ltBusinessPlanJ2" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtJ2" runat="server" Height="85px" Width="364px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanKSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanISection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanK" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        K.<asp:Literal ID="ltBusinessPlanK" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanK1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtK1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanLSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanJSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanL" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    L
                                </td>
                                <td align="center" height="15" width="32">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        L.<asp:Literal ID="ltBusinessPlanL" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanL1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtL1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnBusinessPlanMSection" runat="server" CssClass="btn" OnClick="btnNext_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanK2Section" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vPlanM" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="50%" border="0" cellpadding="0" cellspacing="0" style="color: White;
                            font-weight: bold; background-color: Gray">
                            <tr>
                                <td align="center" height="15" width="32">
                                    A
                                </td>
                                <td align="center" height="15" width="32">
                                    B
                                </td>
                                <td align="center" height="15" width="32">
                                    C
                                </td>
                                <td align="center" height="15" width="32">
                                    D
                                </td>
                                <td align="center" height="15" width="32">
                                    E
                                </td>
                                <td align="center" height="15" width="32">
                                    F
                                </td>
                                <td align="center" height="15" width="32">
                                    G
                                </td>
                                <td align="center" height="15" width="32">
                                    H
                                </td>
                                <td align="center" height="15" width="32">
                                    I
                                </td>
                                <td align="center" height="15" width="32">
                                    J
                                </td>
                                <td align="center" height="15" width="32">
                                    K
                                </td>
                                <td align="center" height="15" width="32">
                                    L
                                </td>
                                <td align="center" height="15" width="32" style="background-color: Maroon">
                                    M
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table class="belgeHeader">
                <tr>
                    <td class="labels" colspan="2">
                        M.<asp:Literal ID="ltBusinessPlanM" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.<asp:Literal ID="ltBusinessPlanM1" runat="server"></asp:Literal>
                    </td>
                    <td class="inputs">
                        <asp:TextBox ID="txtM1" runat="server" Height="85px" TextMode="MultiLine" Width="364px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="labels">
                        &nbsp;
                    </td>
                    <td class="inputs">
                        <asp:Button ID="btnKaydet" runat="server" CssClass="btnKritik" OnClick="btnKaydet_Click" />
                        &nbsp;<asp:Button ID="btnBusinessPlanLSection2" runat="server" CssClass="btn" OnClick="btnPrevious_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
