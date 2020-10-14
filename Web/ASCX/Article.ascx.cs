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
    public partial class Article : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            BSPage bs = new BSPage();
            DSPage ds = new DSPage();
            ds = bs.Getir_byPAGETYPE(PageTypes.Article.GetHashCode());

            if (ds.PAGE.Count > 0)
            {
                string desc = "";
                string title = "";
                if (UserSession.SeciliDil == Dil.English)
                {
                    title = ds.PAGE[0].TITLEENG;
                    desc = ds.PAGE[0].BODYENG;
                }
                else
                {
                    title = ds.PAGE[0].TITLE;
                    desc = ds.PAGE[0].BODY;
                }

                if (desc.Length > 900)
                    desc = desc.Substring(0,900);

                strScrolling = strScrolling + "<a href='/Common/ViewPage.aspx?p="
                + ds.PAGE[0].RECID + "'>" + title + "</a>"
                + desc + "...";

                cellScrolling.InnerHtml = strScrolling;
            }

            rowScrolling.Cells.Add(cellScrolling);
        }

    }
}