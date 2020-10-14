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
using System.Data;

namespace Web.ASCX
{
    public partial class Drafts : System.Web.UI.UserControl
    {
        protected bool YeniMessage
        {
            get
            {
                return Convert.ToBoolean(ViewState["__YeniKayitMi"]);
            }
            set
            {
                ViewState["__YeniKayitMi"] = value;
            }
        }

        protected int MessageID
        {
            get
            {
                return Convert.ToInt32(ViewState["__MasterID"]);
            }
            set
            {
                ViewState["__MasterID"] = value;
            }
        }

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

            ds = bs.GonderdigimMesajlariGetir(UserSession.KullaniciID, Mesaj_Status.Taslak.GetHashCode().ToString());

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
            DataSet dsGonderebileceklerim = bs.GonderilecekleriGetir(UserSession.KullaniciID);
            if (dsGonderebileceklerim.Tables[0].Rows.Count > 0)
                exdrpTo.SelectedValue = dsGonderebileceklerim.Tables[0].Rows[0]["RECID"].ToString();
            Araclar.Kombo_Doldur(exdrpTo, dsGonderebileceklerim, "AdiSoyadi", "RECID", Araclar.KomboTip.Seciniz);
            exdrpTo.SelectedValue = "0";

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
                mvMesajlar.SetActiveView(vGonder);
                DSMessage.MESSAGERow dr = dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(e.CommandArgument));
                txtKonu.Text = dr.SUBJECT;
                txtMesaj.Text = dr.BODY;
                exdrpTo.SelectedValue = dr.TO_USER.ToString();
                this.MessageID = dr.RECID;
                this.YeniMessage = false;
            }
            else if (e.CommandName == "Sil")
            {
                DSMessage.MESSAGERow dr = dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(e.CommandArgument));
                dr.Delete();
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

        protected void btnMesajGonder_Click(object sender, EventArgs e)
        {
            MesajGonder(Mesaj_Status.Okunmadi.GetHashCode());
        }

        protected void MesajGonder(int Status)
        {
            DSMessage ds = new DSMessage();
            ds = dsMesajlarim;
            DSMessage.MESSAGERow dr;
            if (this.YeniMessage)
                dr = ds.MESSAGE.NewMESSAGERow();
            else
                dr = dsMesajlarim.MESSAGE.FindByRECID(this.MessageID);
            dr.BODY = txtMesaj.Text.Trim();
            dr.FROM_USER = UserSession.KullaniciID;
            dr.RECEIVER_DELETED = false;
            dr.SENDDATE = DateTime.Now;
            dr.SENDER_DELETED = false;
            dr.STATUS = Status;
            dr.SUBJECT = txtKonu.Text.Trim();
            dr.TO_USER = Convert.ToInt32(exdrpTo.SelectedValue);
            if (this.YeniMessage)
                ds.MESSAGE.AddMESSAGERow(dr);
            BSMessages bs = new BSMessages();
            bs.MesajGonder(ds);
            if (Mesaj_Status.Okunmadi.GetHashCode() == Status)
                Araclar.MesajGoster(this.Page, "mesajSent", Araclar.MesajTipiEnum.Bilgi);
            else
                Araclar.MesajGoster(this.Page, "DraftMessageSaved", Araclar.MesajTipiEnum.Bilgi);
            Araclar.Temizle(vGonder);
            mvMesajlar.SetActiveView(vListe);
            exdrpTo.SelectedValue = "0";
            Listele();
        }

        protected void btnMesajKaydet_Click(object sender, EventArgs e)
        {
            MesajGonder(Mesaj_Status.Taslak.GetHashCode());
        }

        protected void btnYeniMesaj_Click(object sender, EventArgs e)
        {
            mvMesajlar.SetActiveView(vGonder);
            this.YeniMessage = true;
            exdrpTo.Enabled = true;
        }

        protected void btnReplyMessage_Click(object sender, EventArgs e)
        {
            mvMesajlar.SetActiveView(vGonder);
            BSMessages bs = new BSMessages();
            Araclar.Kombo_Doldur(exdrpTo, bs.GonderilecekleriGetir(UserSession.KullaniciID), "AdiSoyadi", "RECID", Araclar.KomboTip.Seciniz);
            exdrpTo.Enabled = false;
            Listele();
        }

        protected void btnReturninbox_Click(object sender, EventArgs e)
        {
            mvMesajlar.SetActiveView(vListe);
            Listele();
        }
    }
}