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
    public partial class CV_Work : System.Web.UI.UserControl
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
                    lbNewWork.Visible = false;
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
                BSCV_Work bs = new BSCV_Work();
                DSCV_Work ds = new DSCV_Work();
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


                BSCV_Work bs = new BSCV_Work();
                DSCV_Work ds = new DSCV_Work();


                DSCV_Work.CV_WORKRow dr = ds.CV_WORK.NewCV_WORKRow();

                dr.Dates = txtDates.Text;
                dr.MainActivities = txtMainActivities.Text;
                dr.NameAndAddress = txtNameAndAddress.Text;
                dr.Occupation = txtOccupation.Text;
                dr.TypeOfBusiness = txtTypeOfBusiness.Text;
                dr.MEMBER = Member;

                ds.CV_WORK.AddCV_WORKRow(dr);

                bs.Kaydet(ds);

                Listele();

                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                BSCV_Work bs = new BSCV_Work();
                DSCV_Work ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                ds.CV_WORK.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                BSCV_Work bs = new BSCV_Work();
                DSCV_Work ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                if (ds.CV_WORK.Count > 0)
                {
                    txtDates.Text = ds.CV_WORK[0].Dates;
                    txtMainActivities.Text = ds.CV_WORK[0].MainActivities;
                    txtNameAndAddress.Text = ds.CV_WORK[0].NameAndAddress;
                    txtOccupation.Text = ds.CV_WORK[0].Occupation;
                    txtTypeOfBusiness.Text = ds.CV_WORK[0].TypeOfBusiness;
                }
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