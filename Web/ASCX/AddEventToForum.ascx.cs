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
using Types.Enums;

namespace Web.ASCX
{
    public partial class AddEventToForum : System.Web.UI.UserControl
    {
        protected DSProject dsProjeler
        {
            get
            {
                return (DSProject)Session["__ProjelerbyCREATEDBY"];
            }
            set
            {
                Session["__ProjelerbyCREATEDBY"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Araclar.Kombo_Doldur(drpEventType, CacheHelper.EventTypeGetir().EVENTTYPE.Select("RECID IN (" + Enums.EventIds + ")"), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);

                BSProject bs = new BSProject();
                DSProject ds = new DSProject();
                ds = bs.Getir_byCREATEDBY(UserSession.KullaniciID);

                Araclar.GridDoldur(ds.PROJECT.Select("APPROVED = True"), gvProject);
                dsProjeler = ds;
            }
        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            BSEvent bs = new BSEvent();
            DSEvent ds = new DSEvent();

            DSEvent.EVENTRow dr;

            dr = ds.EVENT.NewEVENTRow();
            dr.CREATEDBY = UserSession.KullaniciID;
            dr.CREATIONDATE = DateTime.Now;


            dr.NAME = txtName.Text;
            dr.NAMEENG = txtNameEng.Text;
            dr.EVENTTYPE = Convert.ToInt32(drpEventType.SelectedValue);
            dr.DESCRIPTION = txtBody.Text;
            dr.DESCRIPTIONENG = txtBodyEng.Text;
            dr.LOCATION = txtLocation.Text;
            DateTime date;
            if (DateTime.TryParse(txtDate.Text, out date))
                dr.DATE = date;

            ds.EVENT.AddEVENTRow(dr);

            bs.Kaydet(ds);
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
        }

        protected void gvProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEvent")
            {
                tblEvent.Visible = true;
                mpFiltre2.Show();
            }
        }
    }
}