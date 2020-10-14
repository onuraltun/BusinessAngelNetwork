using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Event;
using Types.TypeDataSets;
using Web.Library;
using Business.Project;
using System.Data;

namespace Web.ASCX
{
    public partial class AddProfessionalFeedback : System.Web.UI.UserControl
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public void Listele()
        {
            if (MemberID != null)
            {
                BSProfessional_Feedback bs = new BSProfessional_Feedback();
                DataSet ds = new DataSet();
                ds = bs.Getir_byPROFESSIONALWithName(MemberID.Value);
                Araclar.GridDoldur(ds, gvFeedback);
            }
        }

        public void AddNew()
        {
            mpFiltre2.Show();
        }

        protected void btnAddFeedback_Click(object sender, EventArgs e)
        {
            BSProfessional_Feedback bs = new BSProfessional_Feedback();
            DSProfessional_Feedback ds = new DSProfessional_Feedback();

            DSProfessional_Feedback.PROFFESIONAL_FEEDBACKRow dr;

            dr = ds.PROFFESIONAL_FEEDBACK.NewPROFFESIONAL_FEEDBACKRow();
            dr.CREATEDBY = UserSession.KullaniciID;
            dr.CREATIONDATE = DateTime.Now;

            dr.PROFESSIONAL = MemberID.Value;
            dr.FEEDBACK = txtFeedback.Text;
            dr.POINT = Rating1.CurrentRating;

            ds.PROFFESIONAL_FEEDBACK.AddPROFFESIONAL_FEEDBACKRow(dr);

            bs.Kaydet(ds);
            Listele();
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
        }
    }
}