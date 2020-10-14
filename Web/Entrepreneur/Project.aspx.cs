using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Management;
using Types.TypeDataSets;
using Business.Project;
using System.IO;
using System.Drawing;
using System.Configuration;
using Types.Enums;
using Business.Messages;

namespace Web.Entrepreneur
{
    public partial class Project : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Entrepreneur; }
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
                Araclar.Kombo_Doldur(drpBussinesType, CacheHelper.BusinessModelTypes(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                Araclar.Kombo_Doldur(drpSektorler, CacheHelper.SektorGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                Araclar.Kombo_Doldur(drpSectorSec, CacheHelper.SektorGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                Listele();
            }
        }

        protected void Listele()
        {
            BSProject bs = new BSProject();
            DSProject ds = new DSProject();
            ds = bs.Getir_byCREATEDBY(UserSession.KullaniciID);
            Araclar.GridDoldur(ds, gvListe);
            dsProjelerim = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSProject bs = new BSProject();
            DSProject ds = new DSProject();
            ds = dsProjelerim;

            DSProject.PROJECTRow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.PROJECT.NewPROJECTRow();
                dr.CREATEDBY = UserSession.KullaniciID;
                dr.CREATIONDATE = DateTime.Now;
                dr.MODIFICATIONDATE = DateTime.Now;
                dr.MODIFIEDBY = UserSession.KullaniciID;
                dr.LOGOAPPROVED = false;
                dr.APPROVED = false;
            }
            else
            {
                dr = ds.PROJECT.FindByRECID(this.MasterID);
                dr.MODIFICATIONDATE = DateTime.Now;
                dr.MODIFIEDBY = UserSession.KullaniciID;
            }

            dr.ACRONYM = txtAcronym.Text;
            dr.BUSINESSMODELTYPE = Convert.ToInt32(drpBussinesType.SelectedValue);
            dr.BUSINESSSUMMARY = txtBusinessSummary.Text;
            dr.COMPETITIVEADVANGE = txtComptetitiveAdvange.Text;
            dr.COMPETITORS = txtComptetitors.Text;
            dr.CUSTOMERPROBLEM = txtCustomerProblem.Text;
            dr.CUSTOMERS = txtCustomers.Text;
            dr.INVESTMENTAMOUNT = txtInvestmentAmount.Text;
            dr.MANAGEMENT = txtManagement.Text;
            dr.NAME = txtName.Text;
            dr.ONELINEPITCH = txtProjectOneLinePitch.Text;
            dr.PRODUCTORSERVICES = txtProductorServices.Text;
            dr.SECTOR = Convert.ToInt32(drpSektorler.SelectedValue);
            dr.STRATEGY = txtStrategy.Text;
            dr.TARGETMARKET = txtTargetMarket.Text;

            bool LogoUploadEdilebilirMi = false;

            if (fuLogo.HasFile)
            {
                if (!this.YeniKayitMi)
                {
                    if (!dr.LOGOAPPROVED)
                        LogoUploadEdilebilirMi = true;
                }
                else
                    LogoUploadEdilebilirMi = true;

                if (LogoUploadEdilebilirMi)
                {
                    int MB1 = 1024 * 1024;

                    if (fuLogo.PostedFile.ContentLength > MB1)
                    {
                        if (UserSession.SeciliDil == Dil.Turkish)
                            ltValidate.Text = "Lütfen 1 Mb'dan daha küçük bir resim seçiniz!";
                        else
                            ltValidate.Text = "Selected file can not be larger than 1 mb.";
                        return;
                    }

                    if (fuLogo.PostedFile.ContentType != "image/bmp" & fuLogo.PostedFile.ContentType != "image/jpg" & fuLogo.PostedFile.ContentType != "image/gif" & fuLogo.PostedFile.ContentType != "image/pjpeg" & fuLogo.PostedFile.ContentType != "image/x-png")
                    {
                        if (UserSession.SeciliDil == Dil.Turkish)
                            ltValidate.Text = "Lütfen geçerli bir resim dosyası seçiniz!";
                        else
                            ltValidate.Text = "Selected file format does not supported!";
                        return;
                    }

                    HttpPostedFile resim = fuLogo.PostedFile;
                    System.Drawing.Image originalImg = System.Drawing.Image.FromStream(resim.InputStream);

                    Bitmap tumb = new Bitmap(100, 100);
                    Graphics gf = Graphics.FromImage(tumb);
                    SolidBrush sb = new SolidBrush(Color.White);
                    gf.FillRectangle(sb, 0, 0, tumb.Width, tumb.Height);
                    gf.DrawImage(originalImg, 0, 0, tumb.Width, tumb.Height);

                    byte[] content = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(tumb).ConvertTo(tumb, typeof(byte[]));
                    dr.LOGO = content;
                }
                else
                {
                    Araclar.MesajGoster(this.Page, "projectLogoAcceptedbyAdminAndCantChange", Araclar.MesajTipiEnum.Hata);
                }
            }
            else
                LogoUploadEdilebilirMi = true;

            if (fuPresentationFile.HasFile)
            {
                int MB1 = 1024 * 1024;

                if (fuPresentationFile.PostedFile.ContentLength > MB1)
                {
                    if (UserSession.SeciliDil == Dil.Turkish)
                        ltValidate.Text = "Lütfen 1 Mb'dan daha küçük bir resim seçiniz!";
                    else
                        ltValidate.Text = "Selected file can not be larger than 1 mb.";
                    return;
                }

                if (fuPresentationFile.PostedFile.ContentType != "application/vnd.ms-powerpoint")
                {
                    if (UserSession.SeciliDil == Dil.Turkish)
                        ltValidate.Text = "Lütfen geçerli bir power point dosyası seçiniz!";
                    else
                        ltValidate.Text = "Selected file format does not supported!";
                    return;
                }
                byte[] pptFile = new byte[fuPresentationFile.PostedFile.ContentLength];
                int sonuc = fuPresentationFile.PostedFile.InputStream.Read(pptFile, 0, fuPresentationFile.PostedFile.ContentLength);
                dr.PPT = pptFile;
            }

            if (this.YeniKayitMi)
                ds.PROJECT.AddPROJECTRow(dr);

            bs.Kaydet(ds);
            Listele();
            if (LogoUploadEdilebilirMi)
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            btnVazgec_Click(null, null);
        }

        protected void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Temizle(vKayitGir);
            mvProjeler.SetActiveView(vKayitGir);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSProject bs = new BSProject();
                bs.Kaydet(dsProjelerim);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.YeniKayitMi = false;
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(e.CommandArgument));

                txtAcronym.Text = dr.ACRONYM;
                drpBussinesType.SelectedValue = dr.BUSINESSMODELTYPE.ToString();
                txtBusinessSummary.Text = dr.BUSINESSSUMMARY;
                txtComptetitiveAdvange.Text = dr.COMPETITIVEADVANGE;
                txtComptetitors.Text = dr.COMPETITORS;
                txtCustomerProblem.Text = dr.CUSTOMERPROBLEM;
                txtCustomers.Text = dr.CUSTOMERS;
                txtInvestmentAmount.Text = dr.INVESTMENTAMOUNT;
                txtManagement.Text = dr.MANAGEMENT;
                txtName.Text = dr.NAME;
                txtProjectOneLinePitch.Text = dr.ONELINEPITCH;
                txtProductorServices.Text = dr.PRODUCTORSERVICES;
                drpSektorler.SelectedValue = dr.SECTOR.ToString();
                txtStrategy.Text = dr.STRATEGY;
                txtTargetMarket.Text = dr.TARGETMARKET;
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
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(this.MasterID);
                BSProject bs = new BSProject();
                drpSectorSec.SelectedValue = dr.SECTOR.ToString();
                mvProjeler.SetActiveView(vProfessionals);
                btnListele_Click(null, null);
            }
            else if (e.CommandName == "businessPlan")
            {
                Response.Redirect("BusinessPlan.aspx?pid=" + e.CommandArgument.ToString());
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvProjeler.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbLogo = (LinkButton)e.Row.FindControl("lbLogo");
                lbLogo.ToolTip = " <img src=\"" + ConfigurationManager.AppSettings["RootDirectory"] + "common/ShowPicture.aspx?id=" + lbLogo.CommandArgument.ToString() + "\"/>";

                ImageButton ibSec = (ImageButton)e.Row.FindControl("ibSec");
                ibSec.CssClass = "tip";
                ibSec.ToolTip = DilCevirGetir(UserSession.SeciliDil, "updateProject");

                ImageButton ibPPT = (ImageButton)e.Row.FindControl("ibPPT");
                ibPPT.CssClass = "tip";
                ibPPT.ToolTip = DilCevirGetir(UserSession.SeciliDil, "downloadPresentationFile");

                ImageButton ibSil = (ImageButton)e.Row.FindControl("ibSil");
                ibSil.CssClass = "tip";
                ibSil.ToolTip = DilCevirGetir(UserSession.SeciliDil, "deleteProject");

                ImageButton ibDanismanlar = (ImageButton)e.Row.FindControl("ibDanismanlar");
                ibDanismanlar.CssClass = "tip";
                ibDanismanlar.ToolTip = DilCevirGetir(UserSession.SeciliDil, "ProjectProfessionals");

                e.Row.Cells[2].Text = CacheHelper.SektorGetir().SECTOR.FindByRECID(Convert.ToInt32(e.Row.Cells[2].Text)).DESCRIPTION;
            }
        }

        protected void gvProfessionals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(this.MasterID);
                BSProject bs = new BSProject();
                bs.ProjeDanismaniSil(Convert.ToInt32(e.CommandArgument), this.MasterID);
                Araclar.GridDoldur(bs.ProjeDanismanlariniGetir(this.MasterID, 1, 1), gvProfessionals);
                Araclar.GridDoldur(bs.DanismanSorgula(dr.SECTOR, this.MasterID), gvProfessionalsList);
            }
            else if (e.CommandName == "Mail")
            {
                mpSendMessage.Show();
                ucSendMessage.ToUser = Convert.ToInt32(e.CommandArgument);

                foreach (GridViewRow grow in gvProfessionals.Rows)
                {
                    if (gvProfessionals.DataKeys[grow.RowIndex]["RECID"].ToString() == e.CommandArgument.ToString())
                    {
                        ucSendMessage.DanismanAdiSoyadi = grow.Cells[0].Text;
                        break;
                    }
                }
            }
            else if (e.CommandName == "CV")
            {
                Response.Redirect("/common/ViewMember.aspx?m=" + e.CommandArgument.ToString());
            }
        }

        protected void gvProfessionalsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddPro")
            {
                if (gvProfessionalsList.Rows.Count < 10)
                {
                    BSProject bs = new BSProject();
                    DSProjectProfessionals ds = new DSProjectProfessionals();
                    DSProjectProfessionals.PROJECT_PROFESSIONALRow dr = ds.PROJECT_PROFESSIONAL.NewPROJECT_PROFESSIONALRow();
                    dr.MEMBER = Convert.ToInt32(e.CommandArgument);
                    dr.PROJECT = this.MasterID;
                    dr.APPROVED = true;
                    dr.ADMINAPPROVED = true;
                    dr.PROAPPROVED = false;
                    ds.PROJECT_PROFESSIONAL.AddPROJECT_PROFESSIONALRow(dr);
                    bs.DanismanKaydet(ds);
                    DSProject.PROJECTRow drPrj = dsProjelerim.PROJECT.FindByRECID(this.MasterID);
                    Araclar.GridDoldur(bs.DanismanSorgula(drPrj.SECTOR, this.MasterID), gvProfessionalsList);
                    Araclar.GridDoldur(bs.ProjeDanismanlariniGetir(this.MasterID, 1, 1), gvProfessionals);
                    MesajGonder(Convert.ToInt32(e.CommandArgument));
                }
                else
                    Araclar.MesajGoster(this.Page, "max10ProfessionalPerProject", Araclar.MesajTipiEnum.Hata, 0);
            }
            else if (e.CommandName == "CV")
            {
                Response.Redirect("/common/ViewMember.aspx?m=" + e.CommandArgument.ToString());
            }
        }

        protected void MesajGonder(int to)
        {
            DSMessage ds = new DSMessage();
            DSMessage.MESSAGERow dr = ds.MESSAGE.NewMESSAGERow();
            if (UserSession.SeciliDil == Dil.Turkish)
                dr.BODY = UserSession.Adi + " " + UserSession.Soyadi + " tarafından " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " projesine danışman olarak eklendiniz!";
            else
                dr.BODY = "You are added " + dsProjelerim.PROJECT.FindByRECID(this.MasterID).NAME + " project as Professional by " + UserSession.Adi + " " + UserSession.Soyadi;
            dr.FROM_USER = UserSession.KullaniciID;
            dr.RECEIVER_DELETED = false;
            dr.SENDDATE = DateTime.Now;
            dr.SENDER_DELETED = false;
            dr.STATUS = Mesaj_Status.Okunmadi.GetHashCode();
            dr.SUBJECT = DilCevirGetir(UserSession.SeciliDil, "YouAreAddedAProjectAsProfessional");
            dr.TO_USER = to;
            ds.MESSAGE.AddMESSAGERow(dr);
            BSMessages bs = new BSMessages();
            bs.MesajGonder(ds);
        }

        protected void btnListele_Click(object sender, EventArgs e)
        {
            DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(this.MasterID);
            BSProject bs = new BSProject();
            Araclar.GridDoldur(bs.ProjeDanismanlariniGetir(this.MasterID, 1, 1), gvProfessionals);
            Araclar.GridDoldur(bs.DanismanSorgula(Convert.ToInt32(drpSectorSec.SelectedValue), this.MasterID), gvProfessionalsList);

            if (cbRD.Checked || cbTeknolojiTransfer.Checked)
            {
                Araclar.MesajGoster(this.Page, "werecommendyoutoworkwithacademiciansonyourproject", Araclar.MesajTipiEnum.Uyari);
            }
        }
    }
}
