using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Member;
using Types.TypeDataSets;
using Web.Library;
using System.Text;
using System.Configuration;
using Business;
using System.Drawing;
using Types.Enums;
using System.IO;

namespace Web.ASCX
{
    public partial class CV_Education : System.Web.UI.UserControl
    {
        #region properties

        public int Member
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

        public string TaskName
        {
            get
            {
                return ViewState["__TaskName"].ToString();
            }
            set
            {
                ViewState["__TaskName"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (TaskName == "ReadOnly")
                {
                    lbNewEducation.Visible = false;
                    gvListe.Columns[gvListe.Columns.Count - 1].Visible = false;
                }
            }
        }

        public void Listele()
        {
            if (Member != 0)
            {
                Araclar araclar = new Araclar();
                //exltHeader.Text = araclar.DilCevirGetir(UserSession.SeciliDil, Work);
                BSCV_Education bs = new BSCV_Education();
                DSCV_Education ds = new DSCV_Education();
                ds = bs.Getir_byMEMBER(Member);
                Araclar.GridDoldur(ds, gvListe);
                mvListe.SetActiveView(vListe);
            }
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (Member != 0)
            {
                Araclar araclar = new Araclar();

                BSCV_Education bs = new BSCV_Education();
                DSCV_Education ds = new DSCV_Education();

                DSCV_Education.CV_EDUCATIONRow dr = ds.CV_EDUCATION.NewCV_EDUCATIONRow();

                dr.Dates = txtDates.Text;
                dr.LevelInNational = txtLevelInNational.Text;
                dr.MainActivities = txtMainActivities.Text;
                dr.NameAndTypeOfOrganisation = txtNameAndTypeOfOrganisation.Text;
                dr.PrincipalSubjects = txtPrincipalSubjects.Text;
                dr.TitleOfQualification = txtTitleOfQualification.Text;
                dr.MEMBER = Member;

                ds.CV_EDUCATION.AddCV_EDUCATIONRow(dr);

                bs.Kaydet(ds);

                Listele();

                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                BSCV_Education bs = new BSCV_Education();
                DSCV_Education ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                ds.CV_EDUCATION.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                //BSCV_Education bs = new BSCV_Education();
                //DSCV_Education ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                //if (ds.CV_EDUCATION.Count > 0)
                //{
                //    txtDates.Text = ds.CV_EDUCATION[0].Dates;
                //    txtLevelInNational.Text = ds.CV_EDUCATION[0].LevelInNational;
                //    txtMainActivities.Text = ds.CV_EDUCATION[0].MainActivities;
                //    txtNameAndTypeOfOrganisation.Text = ds.CV_EDUCATION[0].NameAndTypeOfOrganisation;
                //    txtPrincipalSubjects.Text = ds.CV_EDUCATION[0].PrincipalSubjects;
                //    txtTitleOfQualification.Text = ds.CV_EDUCATION[0].TitleOfQualification;
                //}
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        public string DilCevir(string deyim)
        {
            Araclar araclar = new Araclar();
            return araclar.DilCevirGetir(UserSession.SeciliDil, deyim);
        }

    }
}