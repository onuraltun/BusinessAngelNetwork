using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Log;
using System.Data;
using Web.Library;
using Types.Enums;

namespace Web.Admin
{
    public partial class Log : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected DataSet dsLoglar
        {
            get
            {
                return (DataSet)Session["__loglar"];
            }
            set
            {
                Session["__loglar"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                exdrpIslemTuru.Items.Add(new ListItem("Yeni Kayıt", Log_Yapilan_Islem_Turu.Yeni_Kayit.GetHashCode().ToString()));
                exdrpIslemTuru.Items.Add(new ListItem("Kayıt Güncelleme", Log_Yapilan_Islem_Turu.Kayit_Guncelleme.GetHashCode().ToString()));
                exdrpIslemTuru.Items.Add(new ListItem("Silinen Kayıtlar", Log_Yapilan_Islem_Turu.Kayit_Silme.GetHashCode().ToString()));
                exdrpIslemTuru.Items.Add(new ListItem("Diğer", Log_Yapilan_Islem_Turu.Diger.GetHashCode().ToString()));

                Araclar.Kombo_Doldur(drpMemberShipType, CacheHelper.KullaniciTipiGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Normal);

                tvFiltrelemeBaslangic.Tarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                tvFiltrelemeBitis.Tarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                Listele();
            }
        }

        protected void btnFiltrele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        protected void Listele()
        {
            BSLog oYetki = new BSLog();
            DataSet ds = new DataSet();

            string whereCondition = string.Empty;

            whereCondition = " Log.OPERATIONTYPE=" + exdrpIslemTuru.SelectedValue;
            whereCondition += " AND (MEMBERSHIPTYPE.RECID = " + drpMemberShipType.SelectedValue + ")";

            if (Araclar.IsDateTime(tvFiltrelemeBaslangic.Text) & Araclar.IsDateTime(tvFiltrelemeBitis.Text))
            {
                whereCondition += " AND (OPDATE BETWEEN CONVERT(DATETIME, '" + tvFiltrelemeBaslangic.Tarih.ToShortDateString() + " 00:00:00', 103) AND CONVERT(DATETIME, '" + tvFiltrelemeBitis.Tarih.ToShortDateString() + " 23:59:59', 103))";
            }

            ds = oYetki.LogGetir(whereCondition);

            dsLoglar = ds;
            gvLoglar.PageIndex = 0;
            Araclar.GridDoldur(ds, gvLoglar);
        }

        protected void gvLoglar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLoglar.PageIndex = e.NewPageIndex;
            Araclar.GridDoldur(dsLoglar, gvLoglar);
        }
    }
}
