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
    public partial class Inbox : System.Web.UI.UserControl
    {
        protected bool YeniMail
        {
            get
            {
                return Convert.ToBoolean(ViewState["__YeniMail"]);
            }
            set
            {
                ViewState["__YeniMail"] = value;
            }
        }

        protected int ToUser
        {
            get
            {
                return Convert.ToInt32(ViewState["__ToUser"]);
            }
            set
            {
                ViewState["__ToUser"] = value;
            }
        }

        protected int MailID
        {
            get
            {
                return Convert.ToInt32(ViewState["__MailID"]);
            }
            set
            {
                ViewState["__MailID"] = value;
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

            ds = bs.MesajlarimiGetir(UserSession.KullaniciID);

            this.dsMesajlarim = ds;

            string strGonderenler = string.Empty;

            foreach (DSMessage.MESSAGERow dr in ds.MESSAGE.Rows)
            {
                strGonderenler += dr.FROM_USER.ToString() + ",";
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
                lbFromUser.Text = dsGonderenler.MEMBER.FindByRECID(dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(lbFromUser.CommandArgument)).FROM_USER).NAME + " " + dsGonderenler.MEMBER.FindByRECID(dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(lbFromUser.CommandArgument)).FROM_USER).SURNAME;

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
                this.YeniMail = false;
                this.MailID = Convert.ToInt32(e.CommandArgument);
                mvMesajlar.SetActiveView(vOku);
                DSMessage.MESSAGERow dr = dsMesajlarim.MESSAGE.FindByRECID(this.MailID);
                this.ToUser = dr.FROM_USER;
                exltFrom.Text = "<b>" + dsGonderenler.MEMBER.FindByRECID(dr.FROM_USER).NAME + " " + dsGonderenler.MEMBER.FindByRECID(dr.FROM_USER).SURNAME.ToUpper() + "</b>";
                exltMailMessage.Text = "<b>" + dr.BODY.Replace("\r\n", "<br />") + "</b>";
                exltMailSubject.Text = "<b>" + dr.SUBJECT + "</b>";
                dr.STATUS = Mesaj_Status.Okundu.GetHashCode();
                BSMessages bs = new BSMessages();
                bs.MesajGonder(dsMesajlarim);
                dsMesajlarim.AcceptChanges();
            }
            else if (e.CommandName == "Sil")
            {
                DSMessage.MESSAGERow dr = dsMesajlarim.MESSAGE.FindByRECID(Convert.ToInt32(e.CommandArgument));
                dr.RECEIVER_DELETED = true;
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
            DSMessage.MESSAGERow dr = ds.MESSAGE.NewMESSAGERow();
            dr.BODY = txtMesaj.Text.Trim();
            dr.FROM_USER = UserSession.KullaniciID;
            dr.RECEIVER_DELETED = false;
            dr.SENDDATE = DateTime.Now;
            dr.SENDER_DELETED = false;
            dr.STATUS = Status;
            dr.SUBJECT = txtKonu.Text.Trim();
            if (!this.YeniMail)
                dr.TO_USER = this.ToUser;
            else
                dr.TO_USER = Convert.ToInt32(exdrpTo.SelectedValue);
            ds.MESSAGE.AddMESSAGERow(dr);
            BSMessages bs = new BSMessages();
            bs.MesajGonder(ds);
            if (Mesaj_Status.Okunmadi.GetHashCode() == Status)
                Araclar.MesajGoster(this.Page, "mesajSent", Araclar.MesajTipiEnum.Bilgi);
            else
                Araclar.MesajGoster(this.Page, "DraftMessageSaved", Araclar.MesajTipiEnum.Bilgi);
            Araclar.Temizle(vGonder);
            mvMesajlar.SetActiveView(vListe);
        }

        protected void btnMesajKaydet_Click(object sender, EventArgs e)
        {
            MesajGonder(Mesaj_Status.Taslak.GetHashCode());
        }

        protected void btnYeniMesaj_Click(object sender, EventArgs e)
        {
            this.YeniMail = true;
            mvMesajlar.SetActiveView(vGonder);
            BSMessages bs = new BSMessages();
            Araclar.Kombo_Doldur(exdrpTo, bs.GonderilecekleriGetir(UserSession.KullaniciID), "AdiSoyadi", "RECID", Araclar.KomboTip.Seciniz);
            exdrpTo.Enabled = true;
        }

        protected void btnReplyMessage_Click(object sender, EventArgs e)
        {
            this.YeniMail = false;
            mvMesajlar.SetActiveView(vGonder);
            BSMessages bs = new BSMessages();
            Araclar.Kombo_Doldur(exdrpTo, bs.GonderilecekleriGetir(UserSession.KullaniciID), "AdiSoyadi", "RECID", Araclar.KomboTip.Seciniz);
            exdrpTo.SelectedValue = this.ToUser.ToString();
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