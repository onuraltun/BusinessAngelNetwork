using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;
using Types.TypeDataSets;
using Business.Project;
using Business.Member;

namespace Web.Entrepreneur
{
    public partial class BusinessPlan : MasterOfMaster
    {
        DSProjectBusinessPlan.PROJECT_BUSINESS_PLANRow dr;

        protected DSProjectBusinessPlan dsPlan
        {
            get
            {
                return (DSProjectBusinessPlan)Session["__DSProjectBusinessPlan"];
            }
            set
            {
                Session["__DSProjectBusinessPlan"] = value;
            }
        }

        protected int ProjectID
        {
            get
            {
                return Convert.ToInt32(ViewState["__ProjectID"]);
            }
            set
            {
                ViewState["__ProjectID"] = value;
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

        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Entrepreneur; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["pid"] == null)
                    Response.Redirect("Project.aspx");
                else
                    this.ProjectID = Convert.ToInt32(Request.QueryString["pid"]);

                BSProject bs = new BSProject();
                DSProjectBusinessPlan ds = new DSProjectBusinessPlan();
                ds = bs.BusinessPlanSorgula(this.ProjectID);
                if (ds.PROJECT_BUSINESS_PLAN.Rows.Count > 0)
                {
                    this.dsPlan = ds;
                    this.YeniKayitMi = false;
                    this.MasterID = ds.PROJECT_BUSINESS_PLAN[0].RECID;
                    dr = ds.PROJECT_BUSINESS_PLAN[0];
                    Yukle(mvPlan);
                }
                else
                    this.YeniKayitMi = true;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            mvPlan.ActiveViewIndex++;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            mvPlan.ActiveViewIndex--;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSProject bs = new BSProject();
            DSProjectBusinessPlan ds = new DSProjectBusinessPlan();

            if (this.YeniKayitMi)
                dr = ds.PROJECT_BUSINESS_PLAN.NewPROJECT_BUSINESS_PLANRow();
            else
            {
                ds = bs.BusinessPlanSorgula(this.ProjectID);
                dr = ds.PROJECT_BUSINESS_PLAN[0];
            }

            Kayit(mvPlan);
            dr.PROJECTID = this.ProjectID;

            if (this.YeniKayitMi)
                ds.PROJECT_BUSINESS_PLAN.AddPROJECT_BUSINESS_PLANRow(dr);

            bs.BusinessPlanKaydet(ds);

            BSMember bsMember = new BSMember();
            DSMember dsMember = new DSMember();
            dsMember = bsMember.KullaniciGetirRecId(UserSession.KullaniciID);
            dsMember = bsMember.KullaniciGetirRecId(dsMember.MEMBER.FindByRECID(UserSession.KullaniciID).SUPERVISOR);

            MailGonder mailGonder = new MailGonder();
            mailGonder.From = UserSession.Adi + " " + UserSession.Soyadi.ToUpper();
            mailGonder.Konu = DilCevirGetir(UserSession.SeciliDil, "newBusinessPlan");
            mailGonder.Mesaj = DilCevirGetir(UserSession.SeciliDil, "newbusinessplansaved");
            mailGonder.To = dsMember.MEMBER[0].EMAIL;
            mailGonder.Gonder();

            if (mailGonder.Hata != null)
                Araclar.MesajGoster(this.Page, mailGonder.Hata.Message, Araclar.MesajTipiEnum.Hata);

            Response.Redirect("Project.aspx");
        }

        public void Kayit(Control ctrl)
        {
            if (ctrl.Controls.Count > 0)
            {
                foreach (Control ctrTemizlik in ctrl.Controls)
                {
                    Kayit(ctrTemizlik);
                }
                return;
            }

            if (ctrl is TextBox)
                dr[ctrl.ID.Replace("txt", "")] = ((TextBox)ctrl).Text;
        }

        public void Yukle(Control ctrl)
        {
            if (ctrl.Controls.Count > 0)
            {
                foreach (Control ctrTemizlik in ctrl.Controls)
                {
                    Yukle(ctrTemizlik);
                }
                return;
            }

            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = dr[ctrl.ID.Replace("txt", "")].ToString();
        }
    }
}
