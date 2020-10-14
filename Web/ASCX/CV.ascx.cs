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
    public partial class CV : System.Web.UI.UserControl
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

        public int? MemberID
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

        protected DSCV dsCVler
        {
            get
            {
                return (DSCV)Session["__CVler"];
            }
            set
            {
                Session["__CVler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CV_Work1.Member = MemberID.Value;
                CV_Work1.TaskName = TaskName;
                CV_Education1.Member = MemberID.Value;
                CV_Education1.TaskName = TaskName;
                CV_Language1.Member = MemberID.Value;
                CV_Language1.TaskName = TaskName;
                Prepare();
                CV_Work1.Listele();
                CV_Education1.Listele();
                CV_Language1.Listele();
            }
        }

        public void Prepare()
        {
            if (TaskName == "Update")
            {
                BSCV bs = new BSCV();
                DSCV ds = new DSCV();
                ds = bs.Getir_byMEMBER(MemberID.Value);
                if (ds.CV.Count == 0)
                {
                    this.YeniKayitMi = true;
                    Araclar.Temizle(vKayitGir);
                    mvListe.SetActiveView(vKayitGir);
                }
                else
                {
                    dsCVler = ds;
                    BindToControl(MemberID.Value);
                }
            }
            else if (TaskName == "Admin" &&
                (UserSession.UserMemberShipType == MemberShipType.Admin.GetHashCode() || UserSession.UserMemberShipType == MemberShipType.Supervisor.GetHashCode()))
            {
                mvListe.SetActiveView(vListe);
                Listele();
            }
            else if (TaskName == "ReadOnly")
            {
                //txtAdditionalInformation.Enabled = false;
                //txtAddress.Enabled = false;
                //txtAnnexes.Enabled = false;
                //txtArtisticSkills.Enabled = false;
                //txtComputerSkills.Enabled = false;
                //txtDateofBirth.Enabled = false;
                //txtDesiredEmployment.Enabled = false;
                //txtEmail.Enabled = false;
                //txtFax.Enabled = false;
                //txtGender.Enabled = false;
                //txtMobile.Enabled = false;
                //txtAdditionalInformation.Enabled = false;
                //txtAdditionalInformation.Enabled = false;
                //txtAdditionalInformation.Enabled = false;
                //txtAdditionalInformation.Enabled = false;
                btnKaydet.Visible = false;
                btnVazgec.Visible = false;
            }
            else
                mvListe.Visible = false;
        }

        protected void Listele()
        {
            BSCV bs = new BSCV();
            DSCV ds = new DSCV();
            ds = bs.Getir_byMEMBER(MemberID.Value);
            Araclar.GridDoldur(ds, gvListe);
            dsCVler = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSCV bs = new BSCV();
            DSCV ds = new DSCV();

            DSCV.CVRow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.CV.NewCVRow();
                dr.CREATEDBY = UserSession.KullaniciID;
                dr.CREATIONDATE = DateTime.Now;
            }
            else
            {
                ds = dsCVler;
                dr = ds.CV.FindByRECID(this.MasterID);
                dr.MODIFICATIONDATE = DateTime.Now;
                dr.MODIFIEDBY = UserSession.KullaniciID;
            }

            dr.AdditionalInformation = txtAdditionalInformation.Text;
            dr.Address = txtAddress.Text;
            dr.Annexes = txtAnnexes.Text;
            dr.ArtisticSkills = txtArtisticSkills.Text;
            dr.ComputerSkills = txtComputerSkills.Text;
            dr.DateofBirth = txtDateofBirth.Text;
            dr.DesiredEmployment = txtDesiredEmployment.Text;
            dr.Email = txtEmail.Text;
            dr.Fax = txtFax.Text;
            dr.Gender = txtGender.Text;
            dr.MEMBER = MemberID.Value;
            dr.Mobile = txtMobile.Text;
            dr.MotherTongue = txtMotherTongue.Text;
            dr.Nationality = txtNationality.Text;
            dr.OrganisationalSkills = txtOrganisationalSkills.Text;
            dr.OtherSkills = txtOtherSkills.Text;
            dr.SocialSkills = txtSocialSkills.Text;
            dr.SurnameFirstname = txtSurnameFirstname.Text;
            dr.TechnicalSkills = txtTechnicalSkills.Text;
            dr.Telephone = txtTelephone.Text;

            if (this.YeniKayitMi)
                ds.CV.AddCVRow(dr);

            bs.Kaydet(ds);


            Araclar araclar = new Araclar();

            if (this.YeniKayitMi)//register
            {

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
                dsCVler.CV.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSCV bs = new BSCV();
                bs.Kaydet(dsCVler);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                BindToControl(Convert.ToInt32(e.CommandArgument));
            }
            else if (e.CommandName == "Goster")
            {
                Response.Redirect("/Common/ViewCV.aspx?m=" + e.CommandArgument.ToString());
            }
        }

        private void BindToControl(int argument)
        {
            this.MasterID = argument;
            this.YeniKayitMi = false;
            DSCV.CVRow dr = dsCVler.CV.FindByRECID(argument);

            txtAdditionalInformation.Text = dr.AdditionalInformation;
            txtAddress.Text = dr.Address;
            txtAnnexes.Text = dr.Annexes;
            txtArtisticSkills.Text = dr.ArtisticSkills;
            txtComputerSkills.Text = dr.ComputerSkills;
            txtDateofBirth.Text = dr.DateofBirth;
            txtDesiredEmployment.Text = dr.DesiredEmployment;
            txtEmail.Text = dr.Email;
            txtFax.Text = dr.Fax;
            txtGender.Text = dr.Gender;
            txtMobile.Text = dr.Mobile;
            txtMotherTongue.Text = dr.MotherTongue;
            txtNationality.Text = dr.Nationality;
            txtOrganisationalSkills.Text = dr.OrganisationalSkills;
            txtOtherSkills.Text = dr.OtherSkills;
            txtSocialSkills.Text = dr.SocialSkills;
            txtSurnameFirstname.Text = dr.SurnameFirstname;
            txtTechnicalSkills.Text = dr.TechnicalSkills;
            txtTelephone.Text = dr.Telephone;
            mvListe.SetActiveView(vKayitGir);
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

    }
}