using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Member;
using Types.TypeDataSets;
using Types.Enums;
using System.Configuration;

namespace Web.Common
{
    public partial class MySupervisor : MasterOfMaster
    {
        protected override Types.Enums.MemberShipType PageMemberShip
        {
            get { return Types.Enums.MemberShipType.NotGuest; }
        }

        protected DSMember dsUyeler
        {
            get
            {
                return (DSMember)Session["__Uyeler"];
            }
            set
            {
                Session["__Uyeler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSMember bs = new BSMember();
                DSMember ds = new DSMember();
                ds = bs.KullaniciGetirRecId(UserSession.KullaniciID);
                if (!ds.MEMBER[0].IsSUPERVISORNull())
                {
                    DSMember dsSupervisor = bs.KullaniciGetirRecId(ds.MEMBER[0].SUPERVISOR);
                    Araclar.GridDoldur(dsSupervisor, gvListe);
                    dsUyeler = dsSupervisor;
                }
            }
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbView = (LinkButton)e.Row.FindControl("lbViewMemberShort");
                lbView.ToolTip = " <iframe height=\"240\" width=\"250\" src=\"" + ConfigurationManager.AppSettings["RootDirectory"] + "Common/ViewMemberShort.aspx?m=" + lbView.CommandArgument.ToString() + "\"/>";

            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Message")
            {
                WriteMessage1.ToUser = Convert.ToInt32(e.CommandArgument);
                WriteMessage1.DanismanAdiSoyadi = dsUyeler.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).NAME + " "
                    + dsUyeler.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).SURNAME;

                mpFiltre2.Show();
            }
        }
    }
}
