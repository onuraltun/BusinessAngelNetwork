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
using Business.Project;

namespace Web.ASCX
{
    public partial class NewBusinessIdeas : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            string strScrolling = "";
            HtmlTableCell cellScrolling = new HtmlTableCell();
            BSProject bs = new BSProject();
            DSProject ds = new DSProject();
            ds = bs.NewBusinessIdeas();

            strScrolling = "<Marquee id='mqBusinessIdeas' OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='2' height='150px' width='95%'>";

            foreach (DSProject.PROJECTRow dr in ds.PROJECT)
            {
                string desc = "";
                desc = dr.ACRONYM;

                if (desc.Length > 200)
                    desc = desc.Substring(0, 200);

                strScrolling = strScrolling + "<a href='/Common/ViewProject.aspx?p="
                + dr.RECID + "'>" + dr.CREATIONDATE.ToShortDateString() + "</a><br />"
                + desc + "...<br /><br />";
            }
            strScrolling = strScrolling + "</Marquee>";
            cellScrolling.InnerHtml = strScrolling;
            rowScrolling.Cells.Add(cellScrolling);

        }

        protected void ltNewBusinessIdeasHeader_Click(object sender, EventArgs e)
        {
            if (UserSession.UserMemberShipType == MemberShipType.Investor.GetHashCode())
                Response.Redirect("/Investor/SearchBusinessIdeas.aspx");
            else if (UserSession.UserMemberShipType == MemberShipType.Professional.GetHashCode())
                Response.Redirect("/Investor/SearchBusinessIdeas.aspx");
        }

    }
}