using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Business.Event;
using Types.TypeDataSets;
using Types.Enums;
using Web.Library;

namespace Web.ASCX
{
    public partial class Training : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            BSEvent bs = new BSEvent();
            DSEvent ds = new DSEvent();
            ds = bs.EventlerinTumunuTopladaGetir(EventTypes.Training);

            strScrolling = "<Marquee id='mqTrainings' OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='2' height='150px' width='95%'>";

            foreach (DSEvent.EVENTRow dr in ds.EVENT)
            {
                string desc = "";
                if (UserSession.SeciliDil == Dil.English)
                    desc = dr.DESCRIPTIONENG;
                else
                    desc = dr.DESCRIPTION;

                if (desc.Length > 200)
                    desc = desc.Substring(0,200);

                strScrolling = strScrolling + "<a href='/Common/AttendedEvent.aspx?t="
                + dr.RECID + "'>" + dr.DATE.ToShortDateString() + "</a><br />"
                + desc + "...<br /><br />";
            }
            strScrolling = strScrolling + "</Marquee>";
            cellScrolling.InnerHtml = strScrolling;
            rowScrolling.Cells.Add(cellScrolling);


        }

    }
}