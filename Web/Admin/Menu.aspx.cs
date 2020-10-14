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
    public partial class Menu : MasterOfMaster
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

        protected DSMenu dsMenuler
        {
            get
            {
                return (DSMenu)Session["__Menuler"];
            }
            set
            {
                Session["__Menuler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSPage bsPage = new BSPage();
                DSPage dsPage = bsPage.Getir_byPAGETYPE(1);
                Araclar.Kombo_Doldur(exdrpPageLink, dsPage, "TITLE", "RECID", Araclar.KomboTip.Seciniz);

                BSMenu bsMenu = new BSMenu();
                DSMenu dsMenu = bsMenu.Getir();
                Araclar.Kombo_Doldur(exdrpParentMenu, dsMenu, "TEXTTR", "MENUID", Araclar.KomboTip.Seciniz);

                Listele();
            }
        }

        protected void Listele()
        {
            BSMenu bs = new BSMenu();
            DSMenu ds = new DSMenu();
            ds = bs.Getir();
            Araclar.GridDoldur(ds, gvListe);
            dsMenuler = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSMenu bs = new BSMenu();
            DSMenu ds = new DSMenu();
            ds = dsMenuler;

            DSMenu.MenuRow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.Menu.NewMenuRow();
            }
            else
            {
                dr = ds.Menu.FindByMenuID(this.MasterID);
            }

            dr.Link = txtLink.Text;
            dr.TextEng = txtTextEng.Text;
            dr.TextTR = txtTextTR.Text;

            if (txtOrderValue.Text != "")
                dr.OrderValue = Convert.ToInt32(txtOrderValue.Text);
            else
                dr.OrderValue = 0;

            if (exdrpPageLink.SelectedValue == "0")
                dr.Link = txtLink.Text;
            else
                dr.Link = string.Format("/Common/ViewPage.aspx?p={0}", exdrpPageLink.SelectedValue);

            if (exdrpParentMenu.SelectedValue == "0")
                dr.SetParentIDNull();
            else
                dr.ParentID = Convert.ToInt32(exdrpParentMenu.SelectedValue);

            if (this.YeniKayitMi)
                ds.Menu.AddMenuRow(dr);

            bs.Kaydet(ds);

            CacheHelper.MenuTemizle();

            Listele();
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            btnVazgec_Click(null, null);
        }

        protected void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Temizle(vKayitGir);
            exdrpPageLink.SelectedValue = "0";
            txtOrderValue.Text = "0";
            mvMenuler.SetActiveView(vKayitGir);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                try
                {
                    dsMenuler.Menu.FindByMenuID(Convert.ToInt32(e.CommandArgument)).Delete();
                    BSMenu bs = new BSMenu();
                    bs.Kaydet(dsMenuler);
                    CacheHelper.MenuTemizle();
                    Listele();
                    Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
                }
                catch (Exception ex)
                {
                    Araclar.MesajGoster(this.Page, "mustdeleteparentmenu", Araclar.MesajTipiEnum.Hata);
                }
            }
            else if (e.CommandName == "Sec")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.YeniKayitMi = false;
                DSMenu.MenuRow dr = dsMenuler.Menu.FindByMenuID(Convert.ToInt32(e.CommandArgument));

                if (dr.Link.StartsWith("/Common/ViewPage.aspx"))
                {
                    txtLink.Text = "";
                    txtLink.Enabled = false;
                    exdrpPageLink.SelectedValue = dr.Link.Substring("/Common/ViewPage.aspx?p=".Length);
                }
                else
                {
                    txtLink.Enabled = true;
                    exdrpPageLink.SelectedValue = "0";
                    txtLink.Text = dr.Link;
                }

                if (dr.IsOrderValueNull())
                    txtOrderValue.Text = "0";
                else
                    txtOrderValue.Text = dr.OrderValue.ToString();

                if (dr.IsParentIDNull())
                    exdrpParentMenu.SelectedValue = "0";
                else
                    exdrpParentMenu.SelectedValue = dr.ParentID.ToString();

                txtTextEng.Text = dr.TextEng;
                txtTextTR.Text = dr.TextTR;

                mvMenuler.SetActiveView(vKayitGir);
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvMenuler.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        protected void exdrpPageLink_TextChanged(object sender, EventArgs e)
        {
            if (exdrpPageLink.SelectedValue == "0")
            {
                txtLink.Enabled = true;
            }
            else
            {
                txtLink.Enabled = false;
                txtLink.Text = "";
            }

        }

    }
}
