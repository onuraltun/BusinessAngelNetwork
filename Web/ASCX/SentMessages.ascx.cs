using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.TypeDataSets;
using Business.Messages;
using Web.Library;
using Business.Member;

namespace Web.ASCX
{
    public partial class SentMessages : System.Web.UI.UserControl
    {
        protected DSMessage dsMesajlarim
        {
            get
            {
                return (DSMessage)Session["dsMesajlarim"];
            }
            set
            {
                Session["dsMesajlarim"] = value;
            }
        }

        protected DSMember dsGonderenler
        {
            get
            {
                return (DSMember)Session["dsGonderenler"];
            }
            set
            {
                Session["dsGonderenler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listele();
            }
        }

        protected void Listele()
        {
            BSMessages bs = new BSMessages();
            DSMessage ds = new DSMessage();
            Araclar arc = new Araclar();

            ds = bs.GonderdigimMesajlariGetir(UserSession.KullaniciID, Mesaj_Status.Okunmadi.GetHashCode().ToString() + "," + Mesaj_Status.Okundu.GetHashCode().ToString());

            this.dsMesajlarim = ds;

            string strGonderenler = string.Empty;

            foreach (DSMessage.MESSAGERow dr in ds.MESSAGE.Rows)
            {
                strGonderenler += dr.TO_USER.ToString() + ",";
            }
            strGonderenler += "-1";

            BSMember bsMember = new BSMember();
            DSMember dsMember = new DSMember();
            dsMember = bsMember.KullanicilariGetirRecId(strGonderenler);
            this.dsGonderenler = dsMember;

            Araclar.GridDoldur(ds, gvMesajlar);
        }

        protected void gvMesajlar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbFromUser = (LinkButton)e.Row.FindControl("exlbFromUser");
                lbFromUser.Text = dsGonderenler.MEMBER.FindByRECID(dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(lbFromUser.CommandArgument)).TO_USER).NAME + " " + dsGonderenler.MEMBER.FindByRECID(dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(lbFromUser.CommandArgument)).TO_USER).SURNAME;

                if (gvMesajlar.DataKeys[e.Row.RowIndex]["STATUS"].ToString() == Mesaj_Status.Okunmadi.GetHashCode().ToString())
                {
                    e.Row.CssClass = "alternatif";
                }
            }
        }

        protected void gvMesajlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbOku")
            {
                mvMesajlar.SetActiveView(vOku);
                DSMessage.MESSAGERow dr = dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(e.CommandArgument));
                exltFrom.Text = "<b>" + dsGonderenler.MEMBER.FindByRECID(dr.TO_USER).NAME + " " + dsGonderenler.MEMBER.FindByRECID(dr.TO_USER).SURNAME.ToUpper() + "</b>";
                exltMailMessage.Text = "<b>" + dr.BODY.Replace("\r\n", "<br />") + "</b>";
                exltMailSubject.Text = "<b>" + dr.SUBJECT + "</b>";
            }
            else if (e.CommandName == "Sil")
            {
                DSMessage.MESSAGERow dr = dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(e.CommandArgument));
                dr.SENDER_DELETED = true;
                BSMessages bs = new BSMessages();
                bs.MesajGonder(dsMesajlarim);
                Listele();
                Araclar.MesajGoster(this.Page, "message_Deleted", Araclar.MesajTipiEnum.Bilgi, 0);
            }
        }

        protected void gvMesajlar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Araclar.GridDoldur(dsMesajlarim, gvMesajlar);
        }

        protected void btnReturninbox_Click(object sender, EventArgs e)
        {
            mvMesajlar.SetActiveView(vListe);
        }
    }
}