using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Types.TypeDataSets;
using Types.Enums;
using Web.Library;
using Business;

namespace Web.ASCX
{
    public partial class News : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            BSPage bs = new BSPage();
            DSPage ds = new DSPage();
            ds = bs.Getir_byPAGETYPE(PageTypes.News.GetHashCode());

            strScrolling = "<Marquee id='mqNews' OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='2' height='150px' width='95%'>";

            int i = 0;
            foreach (DSPage.PAGERow dr in ds.PAGE)
            {
                if (i == 4)
                    break;
                i++;
                string desc = "";
                string title = "";
                if (UserSession.SeciliDil == Dil.English)
                {
                    title = dr.TITLEENG;
                    desc = dr.BODYENG;
                }
                else
                {
                    title = dr.TITLE;
                    desc = dr.BODY;
                }

                if (desc.Length > 300)
                    desc = desc.Substring(0, 300);

                strScrolling = strScrolling + "<a href='/Common/ViewPage.aspx?p="
                + dr.RECID + "'>" + title + "</a><br />"
                + desc.Replace("<p>", "").Replace("<p>", "") + "...<br /><br />";
            }
            strScrolling = strScrolling + "</Marquee>";
            cellScrolling.InnerHtml = strScrolling;
            rowScrolling.Cells.Add(cellScrolling);


        }

    }
}