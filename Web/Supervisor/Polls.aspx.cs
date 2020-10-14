using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.TypeDataSets;
using Business.Poll;
using System.Data;
using Types.Enums;

namespace Web.Supervisor
{
    public partial class Polls : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Supervisor; }
        }

        protected bool YeniKayitMi
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

        protected int MasterID
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

        protected DSPoll_Options dsPollOptions
        {
            get
            {
                return (DSPoll_Options)Session["poll_options"];
            }
            set
            {
                Session["poll_options"] = value;
            }
        }

        protected DSPoll_Options dsPollOptions_tmp
        {
            get
            {
                return (DSPoll_Options)Session["tmp_poll_options"];
            }
            set
            {
                Session["tmp_poll_options"] = value;
            }
        }

        protected DSPoll dsPolls
        {
            get
            {
                return (DSPoll)Session["polls"];
            }
            set
            {
                Session["polls"] = value;
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
            BSPoll bs = new BSPoll();
            DSPoll ds = new DSPoll();
            ds = bs.AnketleriGetir();
            this.dsPolls = ds;

            DSPoll_Options dsOptions = new DSPoll_Options();
            dsOptions = bs.Anket_Secenekleri_Getir();
            this.dsPollOptions = dsOptions;

            Araclar.GridDoldur(ds, exgvPoll);
        }

        protected void exbtnYeniKayit_Click(object sender, EventArgs e)
        {
            DSPoll_Options ds = new DSPoll_Options();
            this.dsPollOptions_tmp = ds;
            Araclar.GridDoldur(ds, exgvSecenekGir);
            this.YeniKayitMi = true;
            mvListe.SetActiveView(vKayit);
            Araclar.Temizle(vKayit);
        }

        protected void exgvPoll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].CssClass = "tip";
                e.Row.Cells[0].ToolTip = "<div><iframe src=\"ShowPollOptions.aspx?ID=" + exgvPoll.DataKeys[e.Row.RowIndex]["RECID"].ToString() + "\"></div>";
            }
        }

        protected void exbtnVazgec_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
        }

        protected void exgvSecenekGir_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsPollOptions_tmp.POLL_OPTIONS.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                Araclar.GridDoldur(dsPollOptions_tmp, exgvSecenekGir);
            }
        }

        protected void exbtnSecenekEkle_Click(object sender, EventArgs e)
        {
            DSPoll_Options.POLL_OPTIONSRow dr = dsPollOptions_tmp.POLL_OPTIONS.NewPOLL_OPTIONSRow();
            dr.OPTIONTEXT_EN = txtSecenekEN.Text;
            dr.OPTIONTEXT_TR = txtSecenekTR.Text;
            dr.POLLID = this.MasterID;
            dsPollOptions_tmp.POLL_OPTIONS.AddPOLL_OPTIONSRow(dr);
            Araclar.GridDoldur(dsPollOptions_tmp, exgvSecenekGir);
            txtSecenekEN.Text = string.Empty;
            txtSecenekTR.Text = string.Empty;
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
        }

        protected void exgvPoll_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sec")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.YeniKayitMi = false;

                DSPoll.POLLRow drPoll = dsPolls.POLL.FindByRECID(this.MasterID);
                txtAnketKonuEN.Text = drPoll.NAME_EN;
                txtAnketKonuTR.Text = drPoll.NAME_TR;
                tvBas.Text = drPoll.STARTDATE.ToShortDateString();
                tvBit.Text = drPoll.ENDDATE.ToShortDateString();
                cbGirisimciGorsun.Checked = drPoll.ISFORE;
                cbUzmanGorsunMu.Checked = drPoll.ISFORPROFESSIONAL;
                cbYatirimciGorsunMu.Checked = drPoll.ISFORINVESTOR;
                cbZiyaretciGorsunMu.Checked = drPoll.ISFORGUEST;

                DSPoll_Options dsTmp = new DSPoll_Options();

                foreach (DSPoll_Options.POLL_OPTIONSRow drOpt in dsPollOptions.POLL_OPTIONS.Rows)
                {
                    if (drOpt.POLLID == this.MasterID)
                        dsTmp.POLL_OPTIONS.ImportRow(drOpt);
                }

                this.dsPollOptions_tmp = dsTmp;

                Araclar.GridDoldur(dsPollOptions_tmp, exgvSecenekGir);
                mvListe.SetActiveView(vKayit);
            }
            else if (e.CommandName == "Sil")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.dsPolls.POLL.FindByRECID(this.MasterID).Delete();

                foreach (DSPoll_Options.POLL_OPTIONSRow drOption in dsPollOptions.POLL_OPTIONS.Rows)
                {
                    if (drOption.POLLID == this.MasterID)
                        drOption.Delete();
                }
                BSPoll bs = new BSPoll();
                bs.AnketSil(dsPolls, dsPollOptions);
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
                Listele();
            }
        }

        protected void exbtnKaydet_Click(object sender, EventArgs e)
        {
            if (tvBas.Tarih > tvBit.Tarih)
            {
                Araclar.MesajGoster(this.Page, "Başlangıç tarihi bitiş tarihinden daha ileri olamaz!", Araclar.MesajTipiEnum.Hata, 0);
            }

            if (dsPollOptions_tmp.POLL_OPTIONS.Rows.Count < 2)
            {
                Araclar.MesajGoster(this.Page, "Lütfen en az iki adet seçenek giriniz!", Araclar.MesajTipiEnum.Hata, 0);
                return;
            }

            foreach (DSPoll.POLLRow dr in dsPolls.POLL.Rows)
            {
                if (cbGirisimciGorsun.Checked & dr.ISFORE)
                {
                    Araclar.MesajGoster(this.Page, "Girişimciler için bir adet anket zaten mevcut!", Araclar.MesajTipiEnum.Hata, 0);
                    return;
                }
                if (cbUzmanGorsunMu.Checked & dr.ISFORPROFESSIONAL)
                {
                    Araclar.MesajGoster(this.Page, "Uzmanlar için bir adet anket zaten mevcut!", Araclar.MesajTipiEnum.Hata, 0);
                    return;
                }
                if (cbYatirimciGorsunMu.Checked & dr.ISFORINVESTOR)
                {
                    Araclar.MesajGoster(this.Page, "Yatırımcılar için bir adet anket zaten mevcut!", Araclar.MesajTipiEnum.Hata, 0);
                    return;
                }
                if (cbZiyaretciGorsunMu.Checked & dr.ISFORGUEST)
                {
                    Araclar.MesajGoster(this.Page, "Ziyaretçiler için bir adet anket zaten mevcut!", Araclar.MesajTipiEnum.Hata, 0);
                    return;
                }
            }

            if (cbGirisimciGorsun.Checked == false & cbUzmanGorsunMu.Checked == false & cbYatirimciGorsunMu.Checked == false & cbYatirimciGorsunMu.Checked == false & cbZiyaretciGorsunMu.Checked == false)
            {
                Araclar.MesajGoster(this.Page, "Lütfen en az bir adet kullanıcı tipi seçiniz! (Yatırımcı,Uzman vb...)", Araclar.MesajTipiEnum.Hata, 0);
                return;
            }

            BSPoll bs = new BSPoll();
            DSPoll.POLLRow drPoll;

            if (this.YeniKayitMi)
            {
                drPoll = dsPolls.POLL.NewPOLLRow();
                drPoll.CREATEDBY = UserSession.KullaniciID;
                drPoll.CREATIONDATE = DateTime.Now;
            }
            else
            {
                drPoll = dsPolls.POLL.FindByRECID(this.MasterID);
            }
            drPoll.ENDDATE = tvBit.Tarih;
            drPoll.ISFORE = cbGirisimciGorsun.Checked;
            drPoll.ISFORGUEST = cbZiyaretciGorsunMu.Checked;
            drPoll.ISFORINVESTOR = cbYatirimciGorsunMu.Checked;
            drPoll.ISFORPROFESSIONAL = cbUzmanGorsunMu.Checked;
            drPoll.NAME_EN = txtAnketKonuEN.Text;
            drPoll.NAME_TR = txtAnketKonuTR.Text;
            drPoll.STARTDATE = tvBas.Tarih;

            if (this.YeniKayitMi)
                dsPolls.POLL.AddPOLLRow(drPoll);
            bs.AnketKayit(dsPolls, dsPollOptions_tmp);
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            Listele();
            mvListe.SetActiveView(vListe);
        }
    }
}
