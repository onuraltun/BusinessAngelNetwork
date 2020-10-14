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
    public partial class CV_Language : System.Web.UI.UserControl
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
                    lbNewLanguage.Visible = false;
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
                BSCV_Language bs = new BSCV_Language();
                DSCV_Language ds = new DSCV_Language();
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


                BSCV_Language bs = new BSCV_Language();
                DSCV_Language ds = new DSCV_Language();


                DSCV_Language.CV_LANGUAGERow dr = ds.CV_LANGUAGE.NewCV_LANGUAGERow();

                dr.LANGUAGE = txtLANGUAGE.Text;
                dr.Listening = txtListening.Text;
                dr.Reading = txtReading.Text;
                dr.SpokenInteraction = txtSpokenInteraction.Text;
                dr.SpokenProduction = txtSpokenProduction.Text;
                dr.Writing = txtWriting.Text;
                dr.MEMBER = Member;

                ds.CV_LANGUAGE.AddCV_LANGUAGERow(dr);

                bs.Kaydet(ds);

                Listele();

                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                BSCV_Language bs = new BSCV_Language();
                DSCV_Language ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                ds.CV_LANGUAGE.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                BSCV_Language bs = new BSCV_Language();
                DSCV_Language ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                if (ds.CV_LANGUAGE.Count > 0)
                {
                    txtLANGUAGE.Text = ds.CV_LANGUAGE[0].LANGUAGE;
                    txtListening.Text = ds.CV_LANGUAGE[0].Listening;
                    txtReading.Text = ds.CV_LANGUAGE[0].Reading;
                    txtSpokenInteraction.Text = ds.CV_LANGUAGE[0].SpokenInteraction;
                    txtSpokenProduction.Text = ds.CV_LANGUAGE[0].SpokenProduction;
                    txtWriting.Text = ds.CV_LANGUAGE[0].Writing;
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