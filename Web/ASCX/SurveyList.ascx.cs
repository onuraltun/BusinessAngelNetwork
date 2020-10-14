using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Business.Survey;
using Types.TypeDataSets;
using Web.Library;
using Types.Enums;

namespace Web.ASCX
{
    public partial class SurveyList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            BSSurvey bs = new BSSurvey();
            DSSurvey ds = new DSSurvey();
            ds = bs.TestleriGetir(UserSession.UserMemberShipType);

            //if (ds.SURVEY.Rows.Count > 5)
            strScrolling = "<Marquee id='mqSurveys' OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='2'  width='95%'>";

            int counter = 0;
            foreach (DSSurvey.SURVEYRow dr in ds.SURVEY.Rows)
            {
                if (counter == 3)
                    break;
                else
                    counter++;
                string desc = "";
                if (UserSession.SeciliDil == Dil.English)
                    desc = dr.Subject_EN;
                else
                    desc = dr.Subject_TR;

                if (desc.Length > 200)
                    desc = desc.Substring(0, 200);

                strScrolling = strScrolling + "<a href='/Common/Survey.aspx?t="
                + dr.SurveyID.ToString() + "'>" + dr.DateStart.ToShortDateString() + "</a><br />"
                + desc + "...<br /><br />";
            }
            //if (ds.SURVEY.Rows.Count > 5)
            strScrolling = strScrolling + "</Marquee>";
            cellScrolling.InnerHtml = strScrolling;
            cellScrolling.VAlign = "top";
            rowScrolling.Cells.Add(cellScrolling);
        }
    }
}