using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Management;
using Types.TypeDataSets;
using System.IO;
using System.Drawing;
using Business;
using Types.Enums;

namespace Web.Admin
{
    public partial class Page : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Supervisor; }
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

        protected DSPage dsSayfalar
        {
            get
            {
                return (DSPage)Session["__Sayfalar"];
            }
            set
            {
                Session["__Sayfalar"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Araclar.Kombo_Doldur(drpPageType, CacheHelper.PageTypeGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                drpPageType.SelectedValue = Request.QueryString["t"].ToString();
                //if (Convert.ToInt32(Request.QueryString["t"]) != PageTypes.Page.GetHashCode())
                //    btnYeniKayit.Visible = true;
                Listele();
            }
        }

        protected void Listele()
        {
            BSPage bs = new BSPage();
            DSPage ds = new DSPage();
            ds = bs.Getir_byPAGETYPE(Convert.ToInt32(Request.QueryString["t"]));
            Araclar.GridDoldur(ds, gvListe);
            dsSayfalar = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSPage bs = new BSPage();
            DSPage ds = new DSPage();
            ds = dsSayfalar;

            DSPage.PAGERow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.PAGE.NewPAGERow();
                dr.CREATEDBY = UserSession.KullaniciID;
                dr.CREATIONDATE = DateTime.Now;
            }
            else
            {
                dr = ds.PAGE.FindByRECID(this.MasterID);
            }

            dr.TITLE = txtTitle.Value;
            dr.TITLEENG = txtTitleEng.Value;
            dr.PAGETYPE = Convert.ToInt32(drpPageType.SelectedValue);
            dr.BODY = txtBody.Value;
            dr.BODYENG = txtBodyEng.Value;

            if (this.YeniKayitMi)
                ds.PAGE.AddPAGERow(dr);

            bs.Kaydet(ds);
            Listele();
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            btnVazgec_Click(null, null);
        }

        protected void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Temizle(vKayitGir);
            drpPageType.SelectedValue = Request.QueryString["t"].ToString();
            mvSayfalar.SetActiveView(vKayitGir);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsSayfalar.PAGE.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSPage bs = new BSPage();
                bs.Kaydet(dsSayfalar);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.YeniKayitMi = false;
                DSPage.PAGERow dr = dsSayfalar.PAGE.FindByRECID(Convert.ToInt32(e.CommandArgument));

                txtTitle.Value = dr.TITLE;
                txtTitleEng.Value = dr.TITLEENG;
                txtBody.Value = dr.BODY;
                txtBodyEng.Value = dr.BODYENG;
                drpPageType.SelectedValue = dr.PAGETYPE.ToString();
                mvSayfalar.SetActiveView(vKayitGir);
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvSayfalar.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("ibSil")).Visible = (Convert.ToInt32(Request.QueryString["t"]) != PageTypes.Page.GetHashCode());
            }
        }



    }
}
