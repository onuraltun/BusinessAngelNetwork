using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;
using Business;
using Types.TypeDataSets;
using Business.Project;
using System.Web.UI.HtmlControls;

namespace Web
{
    public partial class _Professional_Default : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["task"] != null && Request.QueryString["task"].ToString() == "activated")
                    Araclar.MesajGoster(this.Page, "activated", Araclar.MesajTipiEnum.Bilgi);

                if (UserSession.UserMemberShipType != MemberShipType.Professional.GetHashCode())
                {
                    pnlMemberLeft.Visible = false;
                    pnlGuestLeft.Visible = true;
                    pnlMemberMiddle.Visible = false;
                    pnlGuestMiddle.Visible = true;

                    BSPage bs = new BSPage();
                    DSPage ds = new DSPage();
                    ds = bs.Getir_byRECID(MembershipPages.Professional.GetHashCode());
                    if (ds.PAGE.Count > 0)
                    {
                        if (UserSession.SeciliDil == Dil.English)
                        {
                            exltPage.Text = ds.PAGE[0].BODYENG;
                        }
                        else
                        {
                            exltPage.Text = ds.PAGE[0].BODY;
                        }

                    }
                }
                else
                {
                    pnlMemberLeft.Visible = true;
                    pnlGuestLeft.Visible = false;
                    pnlMemberMiddle.Visible = true;
                    pnlGuestMiddle.Visible = false;

                    BSProject bs = new BSProject();
                    DSProject ds = new DSProject();
                    ds = bs.Getir_byPROAPPROVED(0, UserSession.KullaniciID);

                    string strScrolling = "";
                    HtmlTableCell cellScrolling = new HtmlTableCell();

                    if (ds.PROJECT.Rows.Count > 5)
                        strScrolling = "<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' direction='up' scrollamount='2'  width='95%'>";

                    foreach (DSProject.PROJECTRow dr in ds.PROJECT.Rows)
                    {
                        string desc = dr.NAME;

                        if (desc.Length > 200)
                            desc = desc.Substring(0, 200);

                        strScrolling = strScrolling + "<a href='/Professional/ProjectAcception.aspx?t="
                        + dr.RECID.ToString() + "'>" + desc + "...<br /><br />";
                    }
                    if (ds.PROJECT.Rows.Count > 5)
                        strScrolling = strScrolling + "</Marquee>";
                    cellScrolling.InnerHtml = strScrolling;
                    cellScrolling.VAlign = "top";
                    rowScrolling.Cells.Add(cellScrolling);
                }
            }
        }
    }
}
