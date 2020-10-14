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
    public partial class Maillist : MasterOfMaster
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

        protected DSMaillist dsMailListesi
        {
            get
            {
                return (DSMaillist)Session["__MailListesi"];
            }
            set
            {
                Session["__MailListesi"] = value;
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
            BSMaillist bs = new BSMaillist();
            DSMaillist ds = new DSMaillist();
            ds = bs.Getir_AmaHicBiriEksikKalmasinHa();
            Araclar.GridDoldur(ds, gvListe);
            dsMailListesi = ds;
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsMailListesi.MAILLIST.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSMaillist bs = new BSMaillist();
                bs.Kaydet(dsMailListesi);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
        }

    }
}
