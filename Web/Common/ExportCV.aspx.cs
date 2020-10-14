using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Web.Library;
using Business.Member;
using Types.TypeDataSets;

namespace Web.Reports
{
    public partial class ExportCV : MasterOfMaster
    {

        protected override Types.Enums.MemberShipType PageMemberShip
        {
            get { return Types.Enums.MemberShipType.NotGuest; }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int member = Convert.ToInt32(Session["cvMEMBER"]);
                //member = 1;

                BSCV bsCV = new BSCV();
                DSCV dsCV = new DSCV();
                dsCV = bsCV.Getir_byMEMBER(member);

                if (dsCV.CV.Rows.Count == 0)
                {
                    Response.Write(DilCevirGetir(UserSession.SeciliDil, "CVnotsaved"));
                    return;
                }

                BSCV_Work bsCV_Work = new BSCV_Work();
                DSCV_Work dsCV_Work = new DSCV_Work();
                dsCV_Work = bsCV_Work.Getir_byMEMBER(member);

                BSCV_Education bsCV_Education = new BSCV_Education();
                DSCV_Education dsCV_Education = new DSCV_Education();
                dsCV_Education = bsCV_Education.Getir_byMEMBER(member);

                BSCV_Language bsCV_Language = new BSCV_Language();
                DSCV_Language dsCV_Language = new DSCV_Language();
                dsCV_Language = bsCV_Language.Getir_byMEMBER(member);

                BSMember bsMember = new BSMember();
                DSMember dsMember = new DSMember();
                dsMember = bsMember.KullaniciGetirRecId(member);

                rtpRaporum.ProcessingMode = ProcessingMode.Local;
                rtpRaporum.ShowPrintButton = false;
                rtpRaporum.ShowFindControls = false;
                rtpRaporum.ShowPageNavigationControls = false;
                rtpRaporum.ShowZoomControl = false;
                rtpRaporum.ShowRefreshButton = false;
                rtpRaporum.ShowToolBar = true;
                rtpRaporum.LocalReport.DataSources.Clear();
                rtpRaporum.LocalReport.DataSources.Add(new ReportDataSource("DSCV_CV", dsCV.CV));
                rtpRaporum.LocalReport.DataSources.Add(new ReportDataSource("DSCV_Work_CV_WORK", dsCV_Work.CV_WORK));
                rtpRaporum.LocalReport.DataSources.Add(new ReportDataSource("DSCV_Language_CV_LANGUAGE", dsCV_Language.CV_LANGUAGE));
                rtpRaporum.LocalReport.DataSources.Add(new ReportDataSource("DSCV_Education_CV_EDUCATION", dsCV_Education.CV_EDUCATION));
                rtpRaporum.LocalReport.DataSources.Add(new ReportDataSource("DSMember_MEMBER", dsMember.MEMBER));
                rtpRaporum.LocalReport.ReportPath = "Reports\\CV.rdlc";

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = rtpRaporum.LocalReport.Render(
                   "PDF", null, out mimeType, out encoding,
                    out extension,
                   out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=" + dsCV.CV[0].SurnameFirstname + " CV.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();


            }
        }
    }
}
