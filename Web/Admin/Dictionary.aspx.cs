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
    public partial class Dictionary : MasterOfMaster
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

        protected DSDictionary dsKelimeler
        {
            get
            {
                return (DSDictionary)Session["__Kelimeler"];
            }
            set
            {
                Session["__Kelimeler"] = value;
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
            BSDictionary bs = new BSDictionary();
            DSDictionary ds = new DSDictionary();
            ds = bs.Getir();
            Araclar.GridDoldur(ds, gvListe);
            dsKelimeler = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSDictionary bs = new BSDictionary();
            DSDictionary ds = new DSDictionary();
            ds = dsKelimeler;

            DSDictionary.DICTIONARYRow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.DICTIONARY.NewDICTIONARYRow();
            }
            else
            {
                dr = ds.DICTIONARY.FindByRECID(this.MasterID);
            }

            dr.ENGLISH = txtEnglish.Text;
            dr.TURKISH = txtTurkish.Text;

            if (this.YeniKayitMi)
                ds.DICTIONARY.AddDICTIONARYRow(dr);

            bs.Kaydet(ds);
            Listele();
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            btnVazgec_Click(null, null);
        }

        protected void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Temizle(vKayitGir);
            mvKelimeler.SetActiveView(vKayitGir);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsKelimeler.DICTIONARY.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSDictionary bs = new BSDictionary();
                bs.Kaydet(dsKelimeler);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.YeniKayitMi = false;
                DSDictionary.DICTIONARYRow dr = dsKelimeler.DICTIONARY.FindByRECID(Convert.ToInt32(e.CommandArgument));

                txtEnglish.Text = dr.ENGLISH;
                txtTurkish.Text = dr.TURKISH;
                exltControlName.Text = dr.CONTROLNAME;

                mvKelimeler.SetActiveView(vKayitGir);
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvKelimeler.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

    }
}
