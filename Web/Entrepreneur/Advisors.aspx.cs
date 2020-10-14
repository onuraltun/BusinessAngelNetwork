using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;
using Business.Project;
using System.Data;
using Types.TypeDataSets;

namespace Web.Entrepreneur
{
    public partial class Advisors : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Entrepreneur; }
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
            BSProject bs = new BSProject();
            DataSet ds = new DataSet();
            ds = bs.Getir_OnayBekleyenDanismalar(UserSession.KullaniciID);
            Araclar.GridDoldur(ds, gvListe);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddPro")
            {
                BSProject bs = new BSProject();
                DSProjectProfessionals ds = new DSProjectProfessionals();
                ds = bs.DanismanKaydiniGetir(Convert.ToInt32(e.CommandArgument));

                if (bs.ProjeDanismanlariniGetir(ds.PROJECT_PROFESSIONAL.FindByRECID(Convert.ToInt32(e.CommandArgument)).PROJECT, 1, 1).Tables[0].Rows.Count > 9)
                {
                    Araclar.MesajGoster(this.Page, "max10ProfessionalPerProject", Araclar.MesajTipiEnum.Hata, 0);
                    return;
                }
                else
                {
                    DSProjectProfessionals.PROJECT_PROFESSIONALRow dr = ds.PROJECT_PROFESSIONAL.FindByRECID(Convert.ToInt32(e.CommandArgument));
                    dr.APPROVED = true;
                    bs.DanismanKaydet(ds);
                    Listele();
                    Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
                }
            }
        }
    }
}
