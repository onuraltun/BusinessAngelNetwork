<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPollOptions.aspx.cs"
    Inherits="Web.Supervisor.ShowPollOptions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html" charset="windows-1254" />
    <meta http-equiv="Content-Language" content="tr" />
    <link rel="stylesheet" type="text/css" href="~/App_Themes/MersinBAN/ui.all.css" media="screen" />
</head>
<body>
    <form id="frmOptions" runat="server">
    <div>
        <table class="belgeHeader">
            <tr>
                <td class="inputs">
                    <asp:GridView ID="exgvSecenekGir" runat="server" Width="100%" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="OPTIONTEXT_TR" HeaderText="Seçenek" />
                            <asp:BoundField DataField="OPTIONTEXT_EN" HeaderText="Seçenek (İngilizce)" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
