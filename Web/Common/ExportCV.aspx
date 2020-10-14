<%@ Page Language="C#"  AutoEventWireup="true"
    CodeBehind="ExportCV.aspx.cs" Inherits="Web.Reports.ExportCV" EnableEventValidation="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rapor</title>

    <%--<script language="javascript" type="text/javascript">
        function degistir() {
            document.getElementById("rtpRaporum_ctl01_ctl05_ctl01").innerText = "Yazdır";
            document.getElementById("rtpRaporum_ctl01_ctl05_ctl01").title = "Yazdırmak için tıklayın...";
            document.getElementById("rtpRaporum_ctl01_ctl05_ctl00").options[0] = new Option("Lütfen bir rapor tipi seçiniz!", "0", true, false);
            document.getElementById('rtpRaporum_ctl01_ctl05_ctl01').Controller.SetViewerLinkActive(document.getElementById('rtpRaporum_ctl01_ctl05_ctl00').selectedIndex = 0);
        }
    </script>--%>

</head>
<body ><%--onload="javascript:degistir()"--%>
    <form id="frmReport" runat="server">
    <rsweb:ReportViewer ID="rtpRaporum" runat="server" Height="700px" Width="800px">
    </rsweb:ReportViewer>
    </form>
</body>
</html>
