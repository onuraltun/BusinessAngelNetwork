using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.Enums;
using Web.Library;
using Business.Project;
using Types.TypeDataSets;
using Microsoft.Reporting.WebForms;
using Business.Member;
using System.Configuration;
using Business.Messages;

namespace Web.Investor
{
    public partial class SearchBusinessIdeas : MasterOfMaster
    {
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
            get { return MemberShipType.Investor; }
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
                Araclar.Kombo_Doldur(drpSektorler, CacheHelper.SektorGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                txtAmount1.Text = "0";
                txtAmount2.Text = "100000";
                cbIsCertifiedByAdmin.Checked = false;
                Listele();
            }
        }

        protected void Listele()
        {
            BSProject bs = new BSProject();
            DSProject ds = new DSProject();

            string WhereCondition = string.Empty;
            if (cbIsCertifiedByAdmin.Checked)
                WhereCondition = "(APPROVED = 1)";
            else
                WhereCondition = "(APPROVED = 0)";

            if (txtAmount1.Text != string.Empty && txtAmount2.Text != string.Empty)
            {
                WhereCondition += " AND (INVESTMENTAMOUNT BETWEEN " + txtAmount1.Text + " AND " + txtAmount2.Text + ")";
            }

            if (drpSektorler.SelectedValue != "0")
            {
                WhereCondition += " AND SECTOR = " + drpSektorler.SelectedValue;
            }

            //WhereCondition += " AND RECID not in(SELECT PROJECT FROM PROJECT_PROFESSIONAL WHERE (MEMBER = " + UserSession.KullaniciID.ToString() + "))";

            ds = bs.Getir(WhereCondition);
            this.dsProjelerim = ds;
            Araclar.GridDoldur(ds, gvListe);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "accept")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));

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
                exltLogo.Text = "<img src=\"" + ConfigurationManager.AppSettings["RootDirectory"] + "common/ShowPicture.aspx?id=" + this.MasterID.ToString() + "\"/>";
                BSMember bsMember = new BSMember();
                DSMember dsMember = new DSMember();
                dsMember = bsMember.KullaniciGetirRecId(dr.CREATEDBY);
                ucMail.DanismanAdiSoyadi = dsMember.MEMBER.FindByRECID(dr.CREATEDBY).NAME + " " + dsMember.MEMBER.FindByRECID(dr.CREATEDBY).SURNAME;
                ucMail.ToUser = dr.CREATEDBY;
                mvProjects.SetActiveView(vProjectDetail);
            }
            else if (e.CommandName == "pptDownload")
            {
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));
                if (!dr.IsPPTNull())
                    Araclar.Ctrl2PPT(dr.PPT);
                else
                    Araclar.MesajGoster(this.Page, "projectPPTfileNotFound", Araclar.MesajTipiEnum.Hata);
            }

            else if (e.CommandName == "businessPlan")
            {
                BSProject bs = new BSProject();
                DSProjectBusinessPlan ds = new DSProjectBusinessPlan();
                ds = bs.BusinessPlanSorgula(Convert.ToInt32(e.CommandArgument));
                rtpRaporum.ProcessingMode = ProcessingMode.Local;
                rtpRaporum.ShowPrintButton = false;
                rtpRaporum.ShowFindControls = false;
                rtpRaporum.ShowPageNavigationControls = false;
                rtpRaporum.ShowZoomControl = false;
                rtpRaporum.ShowRefreshButton = false;
                rtpRaporum.ShowToolBar = true;
                rtpRaporum.LocalReport.DataSources.Clear();
                rtpRaporum.LocalReport.DataSources.Add(new ReportDataSource("DSProjectBusinessPlan_PROJECT_BUSINESS_PLAN", ds.PROJECT_BUSINESS_PLAN));
                rtpRaporum.LocalReport.ReportPath = "./Reports/rptBusinessPlan.rdlc";

                ReportParameter prProjectName = new ReportParameter();
                prProjectName.Name = "ProjectName";
                prProjectName.Values.Add(dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument)).NAME);

                ReportParameter[] parameters = { prProjectName };
                rtpRaporum.LocalReport.SetParameters(parameters);


                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = rtpRaporum.LocalReport.Render(
                   "PDF", null, out mimeType, out encoding,
                    out extension,
                   out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=BusinessPlan.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = CacheHelper.SektorGetir().SECTOR.FindByRECID(Convert.ToInt32(e.Row.Cells[2].Text)).DESCRIPTION;
                //if (dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(gvListe.DataKeys[e.Row.RowIndex]["RECID"].ToString())).IsPPTNull())
                //{
                //    e.Row.FindControl("tdPPT").Visible = false;
                //}
            }
        }

        protected void btnFiltrele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvProjects.SetActiveView(vList);
        }

        protected void btnProjeyeDanismanOl_Click(object sender, EventArgs e)
        {
            try
            {
                BSInvestor_Project bs = new BSInvestor_Project();
                DSInvestor_Project ds = new DSInvestor_Project();
                DSInvestor_Project.INVESTOR_PROJECTRow dr = ds.INVESTOR_PROJECT.NewINVESTOR_PROJECTRow();
                dr.PROJECT = this.MasterID;
                dr.INVESTOR = UserSession.KullaniciID;
                ds.INVESTOR_PROJECT.AddINVESTOR_PROJECTRow(dr);
                bs.Kaydet(ds);
            }
            catch (Exception ex)
            {
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Hata);
                return;
            }

            //MesajGonder(dsProjelerim.PROJECT.FindByRECID(this.MasterID).CREATEDBY);
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            mvProjects.SetActiveView(vList);
        }

        protected void MesajGonder(int to)
        {
            DSMessage ds = new DSMessage();
            DSMessage.MESSAGERow dr = ds.MESSAGE.NewMESSAGERow();
            if (UserSession.SeciliDil == Dil.Turkish)
                dr.BODY = UserSession.Adi + " " + UserSession.Soyadi + " " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " adlı projenize danışman olmak istiyor!";
            else
                dr.BODY = UserSession.Adi + " " + UserSession.Soyadi + " wants to be consultant of " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME;
            dr.FROM_USER = UserSession.KullaniciID;
            dr.RECEIVER_DELETED = false;
            dr.SENDDATE = DateTime.Now;
            dr.SENDER_DELETED = false;
            dr.STATUS = Mesaj_Status.Okunmadi.GetHashCode();
            dr.SUBJECT = DilCevirGetir(UserSession.SeciliDil, "ProjectConsultantRequest");
            dr.TO_USER = to;
            ds.MESSAGE.AddMESSAGERow(dr);
            BSMessages bs = new BSMessages();
            bs.MesajGonder(ds);
        }
    }
}
