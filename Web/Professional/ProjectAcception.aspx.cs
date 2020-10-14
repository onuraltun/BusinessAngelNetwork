using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;
using Business.Project;
using Types.TypeDataSets;
using Microsoft.Reporting.WebForms;
using Business.Member;
using System.Configuration;
using Business.Messages;

namespace Web.Professional
{
    public partial class ProjectAcception : MasterOfMaster
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listele();
                if (Request.QueryString["t"] != null)
                {
                    this.MasterID = Convert.ToInt32(Request.QueryString["t"]);
                    DetayGor();
                }
            }
        }

        protected void Listele()
        {
            BSProject bs = new BSProject();
            DSProject ds = new DSProject();
            ds = bs.Getir_byPROAPPROVED(0, UserSession.KullaniciID);
            dsProjelerim = ds;
            Araclar.GridDoldur(ds, gvListe);
        }

        protected void DetayGor()
        {
            DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(this.MasterID);

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

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "accept")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                DetayGor();
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
                if (dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(gvListe.DataKeys[e.Row.RowIndex]["RECID"].ToString())).IsPPTNull())
                {
                    e.Row.FindControl("tdPPT").Visible = false;
                }
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvProjects.SetActiveView(vList);
        }

        protected void MesajGonder(int to)
        {
            #region Normal Mesaj
            DSMessage ds = new DSMessage();
            DSMessage.MESSAGERow dr = ds.MESSAGE.NewMESSAGERow();
            if (UserSession.SeciliDil == Dil.Turkish)
                dr.BODY = UserSession.Adi + " " + UserSession.Soyadi + " " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " adlı projenize danışman olmayı kabul etti!";
            else
                dr.BODY = UserSession.Adi + " " + UserSession.Soyadi + " accepted the request for " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " project";
            dr.FROM_USER = UserSession.KullaniciID;
            dr.RECEIVER_DELETED = false;
            dr.SENDDATE = DateTime.Now;
            dr.SENDER_DELETED = false;
            dr.STATUS = Mesaj_Status.Okunmadi.GetHashCode();
            dr.SUBJECT = DilCevirGetir(UserSession.SeciliDil, "ProjectConsultantAcception");
            dr.TO_USER = to;
            ds.MESSAGE.AddMESSAGERow(dr);
            BSMessages bs = new BSMessages();
            bs.MesajGonder(ds);
            #endregion

            #region Mail

            DSMember dsMembers = new DSMember();
            BSMember bsMembers = new BSMember();
            dsMembers = bsMembers.KullanicilariGetirRecId(to + "," + UserSession.KullaniciID.ToString());

            MailGonder mGonder = new MailGonder();
            mGonder.From = dsMembers.MEMBER.FindByRECID(UserSession.KullaniciID).EMAIL;
            if (UserSession.SeciliDil == Dil.Turkish)
            {
                mGonder.Konu = "Proje Kabul";
                mGonder.Mesaj = UserSession.Adi + " " + UserSession.Soyadi + " " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " adlı projenize danışman olmayı kabul etti!";
            }
            else
            {
                mGonder.Konu = "Project Consultancy Acception";
                mGonder.Mesaj = UserSession.Adi + " " + UserSession.Soyadi + " accepted the request for " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " project";
            }
            mGonder.To = dsMembers.MEMBER.FindByRECID(to).EMAIL;
            mGonder.Gonder();
            if (mGonder.Hata != null)
            {
                Araclar.MesajGoster(this.Page, mGonder.Hata.Message, Araclar.MesajTipiEnum.Hata, 0);
            }

            #endregion
        }

        protected void btnProjeyeDanismanOl_Click(object sender, EventArgs e)
        {
            BSProject bs = new BSProject();
            DSProjectProfessionals ds = new DSProjectProfessionals();
            ds = bs.DanismanKaydiniGetir(UserSession.KullaniciID, this.MasterID);
            DSProjectProfessionals.PROJECT_PROFESSIONALRow dr = ds.PROJECT_PROFESSIONAL[0];
            dr.PROAPPROVED = true;
            bs.DanismanKaydet(ds);
            MesajGonder(dsProjelerim.PROJECT.FindByRECID(this.MasterID).CREATEDBY);
            Araclar.MesajGoster(this.Page, "projectAccepted", Araclar.MesajTipiEnum.Bilgi);
            Listele();
            mvProjects.SetActiveView(vList);
        }
    }
}
