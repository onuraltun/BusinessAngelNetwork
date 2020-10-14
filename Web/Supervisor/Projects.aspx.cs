using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Project;
using Web.Library;
using Types.TypeDataSets;
using Types.Enums;
using System.Configuration;
using Business.Member;
using Microsoft.Reporting.WebForms;

namespace Web.Supervisor
{
    public partial class Projects : MasterOfMaster
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
            get { return MemberShipType.Supervisor; }
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
                BSProject bs = new BSProject();
                DSProject ds = new DSProject();
                ds = bs.Getir_byNOTAPPROVED();
                dsProjelerim = ds;
                Araclar.GridDoldur(ds, gvListe);
            }
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = CacheHelper.SektorGetir().SECTOR.FindByRECID(Convert.ToInt32(e.Row.Cells[2].Text)).DESCRIPTION;
                if (dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(gvListe.DataKeys[e.Row.RowIndex]["RECID"].ToString())).IsPPTNull())
                {
                    e.Row.FindControl("tdPPT").Visible = false;
                }
            }
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
                mvProjeler.SetActiveView(vKayitGir);
            }
            else if (e.CommandName == "pptDownload")
            {
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));
                if (!dr.IsPPTNull())
                    Araclar.Ctrl2PPT(dr.PPT);
                else
                    Araclar.MesajGoster(this.Page, "projectPPTfileNotFound", Araclar.MesajTipiEnum.Hata);
            }
            else if (e.CommandName == "ProList")
            {
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));
                BSProject bs = new BSProject();
                Araclar.GridDoldur(bs.ProjeDanismanlariniGetir(Convert.ToInt32(e.CommandArgument), 1, 1), gvProfessionals);
                mvProjeler.SetActiveView(vProfessionals);
            }
            else if (e.CommandName == "businessPlan")
            {
                BSProject bs = new BSProject();
                DSProjectBusinessPlan ds = new DSProjectBusinessPlan();
                ds = bs.BusinessPlanSorgula(Convert.ToInt32(e.CommandArgument));
                //DSProjectBusinessPlan.PROJECT_BUSINESS_PLANRow drPlan = ds.PROJECT_BUSINESS_PLAN[0];

                //for (int i = 0; i < ds.PROJECT_BUSINESS_PLAN.Columns.Count; i++)
                //{
                //    if (vBusinessPlan.FindControl("extxt" + ds.PROJECT_BUSINESS_PLAN.Columns[i].ColumnName) != null)
                //    {
                //        ((Literal)vBusinessPlan.FindControl("extxt" + ds.PROJECT_BUSINESS_PLAN.Columns[i].ColumnName)).Text = drPlan[ds.PROJECT_BUSINESS_PLAN.Columns[i].ColumnName].ToString();
                //    }
                //}
                //mvProjeler.SetActiveView(vBusinessPlan);
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

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvProjeler.SetActiveView(vListe);
        }

        protected void btnProjeKabul_Click(object sender, EventArgs e)
        {
            dsProjelerim.PROJECT.FindByRECID(this.MasterID).LOGOAPPROVED = true;
            dsProjelerim.PROJECT.FindByRECID(this.MasterID).APPROVED = true;
            BSProject bs = new BSProject();
            bs.Kaydet(dsProjelerim);
            dsProjelerim = bs.Getir_byNOTAPPROVED();
            Araclar.MesajGoster(this.Page, "projectAccepted", Araclar.MesajTipiEnum.Bilgi);
            mvProjeler.SetActiveView(vListe);
            Araclar.GridDoldur(dsProjelerim, gvListe);
        }
    }
}
