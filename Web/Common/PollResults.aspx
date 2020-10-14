<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PollResults.aspx.cs" Inherits="Web.Common.PollResults" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Anket Sonucu</title>
    <link href="~/App_Themes/MersinBAN/Gridler.css" rel="stylesheet" type="text/css" />
    <link href="~/App_Themes/MersinBAN/Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="Cerceve" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblAnketKonusu" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView CssClass="CerceveBorderSiyah" DataKeyNames="RECID,OPTIONTEXT_EN" ID="gvAnketSonucu"
                        runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvAnketSonucu_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Seçenek" DataField="OPTIONTEXT_TR">
                                <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Sonuçlar">
                                <ItemTemplate>
                                    <asp:Image ID="ISonuc" runat="server" Height="10px" ImageUrl="~/images/AnketSonuc.jpg" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lbYuzde" Font-Size="9px" runat="server"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbToplam" runat="server" Font-Bold="True" Text="Toplam:"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
