using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business.Member;
using Web.Library;
using Types.Enums;
using Types.TypeDataSets;
using Business.Project;
using System.Configuration;

namespace Web.Professional
{
    public partial class MyEntrepreneur : MasterOfMaster
    {
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Professional; }
        }

        protected DSProject dsProjelerim
        {
            get
            {
                return (DSProject)Session["__Projelerim"];
            }
            set
            {
                Session["__Projelerim"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSMember bs = new BSMember();
                DataSet ds = new DataSet();
                ds = bs.GirisimcilerimiGetir(UserSession.KullaniciID);
                Araclar.GridDoldur(ds, gvListe);
            }
            ucWriteMessage.Gonderildi += new Web.ASCX.WriteMessage.Gonder(ucWriteMessage_Gonderildi);
        }

        void ucWriteMessage_Gonderildi()
        {
            mvProjects.SetActiveView(vListe);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "detay")
            {
                Response.Redirect("/common/ViewMember.aspx?m=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Mail")
            {
                ucWriteMessage.ToUser = Convert.ToInt32(e.CommandArgument);
                BSMember bsMember = new BSMember();
                DSMember dsMember = new DSMember();
                dsMember = bsMember.KullaniciGetirRecId(Convert.ToInt32(e.CommandArgument));
                ucWriteMessage.DanismanAdiSoyadi = dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).NAME + " " + dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).SURNAME;
                mvProjects.SetActiveView(vMail);
            }
            else if (e.CommandName == "proje")
            {
                BSProject bs = new BSProject();
                DSProject ds = new DSProject();
                ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));
                dsProjelerim = ds;
                DSProject.PROJECTRow dr = ds.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));

                extxtAcronym.Text = dr.ACRONYM;
                exltBusinessModelType.Text = CacheHelper.BusinessModelTypes().BUSINESSMODELTYPE.FindByRECID(dr.BUSINESSMODELTYPE).DESCRIPTION;
                extxtBusinessSummary.Text = dr.BUSINESSSUMMARY;
                extxtComptetitiveAdvange.Text = dr.COMPETITIVEADVANGE;
                extxtComptetitors.Text = dr.COMPETITORS;
                extxtCustomerProblem.Text = dr.CUSTOMERPROBLEM;
                extxtCustomers.Text = dr.CUSTOMERS;
                exltInvestmenAmount.Text = dr.INVESTMENTAMOUNT;
                extxtManagement.Text = dr.MANAGEMENT;
                extxtName.Text = dr.NAME;
                extxtProjectOneLinePitch.Text = dr.ONELINEPITCH;
                extxtProductorServices.Text = dr.PRODUCTORSERVICES;
                exltSektor.Text = CacheHelper.SektorGetir().SECTOR.FindByRECID(dr.SECTOR).DESCRIPTION;
                extxtStrategy.Text = dr.STRATEGY;
                extxtTargetMarket.Text = dr.TARGETMARKET;
                exltIsCertfied.Text = (dr.APPROVED) ? DilCevirGetir(UserSession.SeciliDil, "yes") : DilCevirGetir(UserSession.SeciliDil, "no");
                mvProjects.SetActiveView(vDetay);
            }
            else if (e.CommandName == "pptDownload")
            {
                BSProject bs = new BSProject();
                DSProject ds = new DSProject();
                ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));
                DSProject.PROJECTRow dr = ds.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));
                if (!dr.IsPPTNull())
                    Araclar.Ctrl2PPT(dr.PPT);
                else
                    Araclar.MesajGoster(this.Page, "projectPPTfileNotFound", Araclar.MesajTipiEnum.Hata);
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvProjects.SetActiveView(vListe);
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            mvProjects.SetActiveView(vListe);
        }

        protected void ibExcel0_Click(object sender, ImageClickEventArgs e)
        {
            Araclar.Ctrl2Word(vDetay);
        }
    }
}
