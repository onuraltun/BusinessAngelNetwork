using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Member;
using Types.TypeDataSets;
using Web.Library;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using Types.Enums;

namespace Web.ASCX
{
    public partial class Member : System.Web.UI.UserControl
    {
        #region properties

        private string taskName;
        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
            }

        }

        private MemberShipType memberShipType;
        public MemberShipType MemberShipTypeProperty
        {
            get
            {
                if (ViewState["__memberShipType"] != null)
                    return (MemberShipType)(ViewState["__memberShipType"]);
                else
                    return MemberShipType.Guest;
            }
            set
            {
                ViewState["__memberShipType"] = value;
            }

        }

        #endregion

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

        protected int MemberID
        {
            get
            {
                return Convert.ToInt32(ViewState["__MemberID"]);
            }
            set
            {
                ViewState["__MemberID"] = value;
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

        protected DSMember dsUyeler
        {
            get
            {
                return (DSMember)Session["__Uyeler"];
            }
            set
            {
                Session["__Uyeler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Araclar.Kombo_Doldur(drpTitle, CacheHelper.TitleGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                Araclar.Kombo_Doldur(drpInvestorType, CacheHelper.InvestorTypeGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);

                drpMembershipType.Items.Add(new ListItem(MemberShipType.Entrepreneur.ToString(), MemberShipType.Entrepreneur.GetHashCode().ToString()));
                drpMembershipType.Items.Add(new ListItem(MemberShipType.Investor.ToString(), MemberShipType.Investor.GetHashCode().ToString()));
                drpMembershipType.Items.Add(new ListItem(MemberShipType.Professional.ToString(), MemberShipType.Professional.GetHashCode().ToString()));
                drpMembershipType.Items.Add(new ListItem(MemberShipType.Admin.ToString(), MemberShipType.Admin.GetHashCode().ToString()));
                drpMembershipType.Items.Add(new ListItem(MemberShipType.Supervisor.ToString(), MemberShipType.Supervisor.GetHashCode().ToString()));

                if (TaskName == "Admin")
                    trMembershipType.Visible = true;

                lbSector.DataTextField = "Description";
                lbSector.DataValueField = "RecId";
                lbSector.DataSource = CacheHelper.SektorGetir();
                lbSector.DataBind();

                if (TaskName == "ReadOnly")
                    MemberID = Convert.ToInt32(Request.QueryString["m"]);
                else
                    MemberID = UserSession.KullaniciID;
                Prepare();
            }
        }

        public void Prepare()
        {

            if (MemberShipTypeProperty == MemberShipType.Investor)
            {
                trInvestorType.Visible = true;
                trAmount.Visible = true;
            }
            else
            {
                trInvestorType.Visible = false;
                trAmount.Visible = false;
            }

            if (MemberShipTypeProperty == MemberShipType.Professional)
            {
                trSector.Visible = true;
                trExpertise.Visible = true;

                if (MemberID != GuestUserID.UserID.GetHashCode())
                {
                    BSProfessional_Sectors bsSek = new BSProfessional_Sectors();
                    DSProfessionalSectors dsSek = bsSek.Getir_byMEMBERID(MemberID);
                    foreach (DSProfessionalSectors.PROFESSIONAL_SECTORSRow row in dsSek.PROFESSIONAL_SECTORS)
                    {
                        if (lbSector.Items.FindByValue(row.SECTORID.ToString()) != null)
                            lbSector.Items.FindByValue(row.SECTORID.ToString()).Selected = true;
                    }
                }
            }
            else
            {
                trSector.Visible = false;
                trExpertise.Visible = false;
            }

            if (TaskName == "Register")
            {
                this.YeniKayitMi = true;
                Araclar.Temizle(vKayitGir);
                mvListe.SetActiveView(vKayitGir);
            }
            else if (TaskName == "Update")
            {
                trPassword.Visible = false;
                trConfirmPassword.Visible = false;
                trEmail.Visible = false;
                BSMember bs = new BSMember();
                DSMember ds = new DSMember();
                ds = bs.KullaniciGetirRecId(MemberID);
                dsUyeler = ds;
                BindToControl(MemberID);
            }
            else if (TaskName == "Admin" &&
                (UserSession.UserMemberShipType == MemberShipType.Admin.GetHashCode() || UserSession.UserMemberShipType == MemberShipType.Supervisor.GetHashCode()))
            {
                trPassword.Visible = false;
                trConfirmPassword.Visible = false;
                trEmail.Visible = false;
                mvListe.SetActiveView(vListe);
                Listele();
            }
            else
                mvListe.Visible = false;
        }

        protected void Listele()
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();
            ds = bs.KullanicilariGetir((MemberShipType)UserSession.UserMemberShipType);
            Araclar.GridDoldur(ds, gvListe);
            dsUyeler = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();

            DSMember.MEMBERRow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.MEMBER.NewMEMBERRow();
                dr.CREATEDBY = UserSession.KullaniciID;
                dr.CREATIONDATE = DateTime.Now;
                dr.SUPERVISORAPPROVED = false;
            }
            else
            {
                ds = dsUyeler;
                dr = ds.MEMBER.FindByRECID(this.MasterID);
                dr.MODIFICATIONDATE = DateTime.Now;
                dr.MODIFICATEDBY = UserSession.KullaniciID;
            }


            dr.ADDRESS = txtADDRESS.Text;
            dr.CITY = txtCITY.Text;
            dr.PROVINCE = txtPROVINCE.Text;
            dr.COUNTRY = txtCOUNTRY.Text;
            dr.POSTALCODE = txtPOSTALCODE.Text;
            dr.CITY = txtCITY.Text;
            dr.PROVINCE = txtPROVINCE.Text;
            dr.COUNTRY = txtCOUNTRY.Text;
            dr.POSTALCODE = txtPOSTALCODE.Text;

            if (Araclar.IsDecimal(txtAMOUNTSPERINVESTMENT.Text))
                dr.AMOUNTSPERINVESTMENT = Convert.ToDecimal(txtAMOUNTSPERINVESTMENT.Text);

            dr.COMPANYNAME = txtCOMPANYNAME.Text;
            dr.EMAIL = txtEMAIL.Text;
            dr.FAX = txtFAX.Text;
            if (Araclar.IsNumeric(drpInvestorType.SelectedValue) && drpInvestorType.SelectedValue != "0")
                dr.INVESTORTYPE = Convert.ToInt32(drpInvestorType.SelectedValue);
            else
                dr.SetINVESTORTYPENull();

            if (TaskName == "Admin")
                dr.MEMBERSHIPTYPE = Convert.ToInt32(drpMembershipType.SelectedValue);
            else if (dr.MEMBERSHIPTYPE == 0)
                dr.MEMBERSHIPTYPE = MemberShipTypeProperty.GetHashCode();

            dr.MOBILENUMBER = txtMOBILENUMBER.Text;
            dr.NAME = txtNAME.Text;

            if (this.YeniKayitMi)
            {
                SHA1 oSHA1 = SHA1CryptoServiceProvider.Create();
                string pass = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(txtPASSWORD.Text)));
                dr.PASSWORD = pass;
            }

            dr.POSITION = txtPOSITION.Text;
            dr.SURNAME = txtSURNAME.Text;
            dr.TELEPHONE = txtTELEPHONE.Text;
            dr.TITLE = Convert.ToInt32(drpTitle.SelectedValue);


            if (this.YeniKayitMi)
                ds.MEMBER.AddMEMBERRow(dr);

            bs.Kaydet(ds);

            if (dr.MEMBERSHIPTYPE == MemberShipType.Professional.GetHashCode())
            {
                BSProfessional_Sectors bsSector = new BSProfessional_Sectors();
                bsSector.Sil_byMEMBERID(dr.RECID);
                DSProfessionalSectors dsSector = new DSProfessionalSectors();
                foreach (ListItem item in lbSector.Items)
                {
                    if (item.Selected)
                    {
                        DSProfessionalSectors.PROFESSIONAL_SECTORSRow drSector = dsSector.PROFESSIONAL_SECTORS.NewPROFESSIONAL_SECTORSRow();
                        drSector.MEMBERID = dr.RECID;
                        drSector.SECTORID = Convert.ToInt32(item.Value);
                        dsSector.PROFESSIONAL_SECTORS.AddPROFESSIONAL_SECTORSRow(drSector);
                    }
                }
                bsSector.Kaydet(dsSector);
            }

            Araclar araclar = new Araclar();

            if (this.YeniKayitMi)//register
            {
                SHA1 oSHA1 = SHA1CryptoServiceProvider.Create();
                string actCode = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(txtEMAIL.Text)));

                string strTitle = CacheHelper.TitleGetir().TITLE.FindByRECID(dr.TITLE).DESCRIPTION;

                MailGonder mail = new MailGonder();
                mail.To = dr.EMAIL;

                if (UserSession.SeciliDil == Dil.Turkish)
                {
                    mail.Konu = "MersinBAN üyelik aktivasyonu";
                    mail.Mesaj = string.Format("{0} {1} {2},{3}{4} {5}{6}", araclar.DilCevirGetir(UserSession.SeciliDil, strTitle), dr.NAME, dr.SURNAME, @"

Üyeliğinizi aktifleştirmek için aşağıdaki adrese girip aktivasyon kodunu giriniz.

http://www.mersinban.com/common/activation.aspx?a=", dr.RECID, @"

Aktivasyon Kodu: ", actCode);
                }
                else
                {
                    mail.Konu = "MersinBAN membership activation";
                    mail.Mesaj = string.Format("{0} {1} {2},{3}{4} {5}{6}", araclar.DilCevirGetir(UserSession.SeciliDil, strTitle),
                        dr.NAME, dr.SURNAME, @"

Go to address below and write the code for activation.

http://www.mersinban.com/common/activation.aspx?a=", dr.RECID, @"

Activation Code: ", actCode);
                }
                mail.Gonder();
            }

            if (TaskName == "Admin")
            {
                btnVazgec_Click(null, null);
                Listele();
            }
            else if (TaskName == "Update")
            {

            }
            else if (TaskName == "Register")
            {
                Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Common/Activation.aspx?a=" + dr.RECID.ToString());
            }

            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
        }

        protected void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Temizle(vKayitGir);
            mvListe.SetActiveView(vKayitGir);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsUyeler.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSMember bs = new BSMember();
                bs.Kaydet(dsUyeler);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Onayla")
            {
                DSMember.MEMBERRow dr = dsUyeler.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument));
                dr.SUPERVISORAPPROVED = true;
                dr.SUPERVISOR = UserSession.KullaniciID;
                BSMember bs = new BSMember();
                bs.Kaydet(dsUyeler);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "OnayKaldir")
            {
                DSMember.MEMBERRow dr = dsUyeler.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument));
                dr.SUPERVISORAPPROVED = false;
                BSMember bs = new BSMember();
                bs.Kaydet(dsUyeler);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                BindToControl(Convert.ToInt32(e.CommandArgument));
            }
            else if (e.CommandName == "Goster")
            {
                Response.Redirect("/Admin/ViewMember.aspx?m=" + e.CommandArgument.ToString());
            }
        }

        private void BindToControl(int argument)
        {
            this.MasterID = argument;
            this.YeniKayitMi = false;
            DSMember.MEMBERRow dr = dsUyeler.MEMBER.FindByRECID(argument);

            trInvestorType.Visible = trAmount.Visible = (dr.MEMBERSHIPTYPE == MemberShipType.Investor.GetHashCode());

            if (!dr.IsADDRESSNull())
                txtADDRESS.Text = dr.ADDRESS;
            if (!dr.IsCITYNull())
                txtCITY.Text = dr.CITY;
            if (!dr.IsPROVINCENull())
                txtPROVINCE.Text = dr.PROVINCE;
            if (!dr.IsCOUNTRYNull())
                txtCOUNTRY.Text = dr.COUNTRY;
            if (!dr.IsPOSTALCODENull())
                txtPOSTALCODE.Text = dr.POSTALCODE;

            if (!dr.IsAMOUNTSPERINVESTMENTNull())
                txtAMOUNTSPERINVESTMENT.Text = dr.AMOUNTSPERINVESTMENT.ToString();
            if (!dr.IsCOMPANYNAMENull())
                txtCOMPANYNAME.Text = dr.COMPANYNAME;
            txtEMAIL.Text = dr.EMAIL;
            if (!dr.IsFAXNull())
                txtFAX.Text = dr.FAX;
            if (!dr.IsINVESTORTYPENull())
                drpInvestorType.SelectedValue = dr.INVESTORTYPE.ToString();
            if (!dr.IsMOBILENUMBERNull())
                txtMOBILENUMBER.Text = dr.MOBILENUMBER;
            txtNAME.Text = dr.NAME;
            if (!dr.IsPOSITIONNull())
                txtPOSITION.Text = dr.POSITION;
            txtSURNAME.Text = dr.SURNAME;
            if (!dr.IsTELEPHONENull())
                txtTELEPHONE.Text = dr.TELEPHONE;
            drpTitle.SelectedValue = dr.TITLE.ToString();
            drpMembershipType.SelectedValue = dr.MEMBERSHIPTYPE.ToString();
            mvListe.SetActiveView(vKayitGir);
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbView = (LinkButton)e.Row.FindControl("lbViewMemberShort");
                lbView.ToolTip = " <iframe height=\"240\" width=\"250\" src=\"" + ConfigurationManager.AppSettings["RootDirectory"] + "Common/ViewMemberShort.aspx?m=" + lbView.CommandArgument.ToString() + "\"/>";

                ImageButton lbSec = (ImageButton)e.Row.FindControl("ibOnayla");
                ImageButton lbSil = (ImageButton)e.Row.FindControl("ibOnayKaldir");
                if (Convert.ToBoolean(((GridView)e.Row.Parent.Parent).DataKeys[e.Row.RowIndex]["SUPERVISORAPPROVED"]) == false)
                {
                    lbSec.Visible = true;
                    lbSil.Visible = false;
                }
                else
                {
                    lbSec.Visible = false;
                    lbSil.Visible = true;
                }

                e.Row.Cells[3].Text = CacheHelper.KullaniciTipiGetir().MEMBERSHIPTYPE.FindByRECID(Convert.ToInt32(e.Row.Cells[3].Text)).DESCRIPTION;
            }
        }
    }
}