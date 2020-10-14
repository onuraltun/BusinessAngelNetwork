using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Management;
using Types.TypeDataSets;
using System.IO;
using System.Drawing;
using Business.Event;
using Types.Enums;
using System.Data;

namespace Web.Admin
{
    public partial class Event : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Supervisor; }
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

        protected DSEvent dsAktiviteler
        {
            get
            {
                return (DSEvent)Session["__Aktiviteler"];
            }
            set
            {
                Session["__Aktiviteler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["t"].ToString() == "1")
                    Araclar.Kombo_Doldur(drpEventType, CacheHelper.EventTypeGetir().EVENTTYPE.Select("RECID in (" + Enums.EventIds + ")"), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                else
                    Araclar.Kombo_Doldur(drpEventType, CacheHelper.EventTypeGetir().EVENTTYPE.Select("RECID in (" + Enums.TrainingIds + ")"), "DESCRIPTION", "RECID", Araclar.KomboTip.Seciniz);
                drpEventType.SelectedValue = Request.QueryString["t"].ToString();
                Listele();
            }
        }

        protected void Listele()
        {
            File1.TaskName = "Admin";
            BSEvent bs = new BSEvent();
            DSEvent ds = new DSEvent();
            if (Request.QueryString["t"].ToString() == "1")
                ds = bs.EventleriGetir();
            else
                ds = bs.Getir_byEVENTTYPE(Convert.ToInt32(Request.QueryString["t"]));
            Araclar.GridDoldur(ds, gvListe);
            dsAktiviteler = ds;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            BSEvent bs = new BSEvent();
            DSEvent ds = new DSEvent();
            ds = dsAktiviteler;

            DSEvent.EVENTRow dr;

            if (this.YeniKayitMi)
            {
                dr = ds.EVENT.NewEVENTRow();
                dr.CREATEDBY = UserSession.KullaniciID;
                dr.CREATIONDATE = DateTime.Now;
            }
            else
            {
                dr = ds.EVENT.FindByRECID(this.MasterID);
            }

            dr.NAME = txtName.Text;
            dr.NAMEENG = txtNameEng.Text;
            dr.EVENTTYPE = Convert.ToInt32(drpEventType.SelectedValue);
            dr.DESCRIPTION = txtBody.Value;
            dr.DESCRIPTIONENG = txtBodyEng.Value;
            dr.LOCATION = txtLocation.Text;
            DateTime date;
            if (DateTime.TryParse(txtDate.Text, out date))
                dr.DATE = date;


            if (this.YeniKayitMi)
                ds.EVENT.AddEVENTRow(dr);

            bs.Kaydet(ds);
            Listele();
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            btnVazgec_Click(null, null);
        }

        protected void btnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Temizle(vKayitGir);
            //drpEventType.SelectedValue = Request.QueryString["t"].ToString();
            File1.RelationID = 0;
            mvAktiviteler.SetActiveView(vKayitGir);
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsAktiviteler.EVENT.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                BSEvent bs = new BSEvent();
                bs.Kaydet(dsAktiviteler);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                this.YeniKayitMi = false;
                DSEvent.EVENTRow dr = dsAktiviteler.EVENT.FindByRECID(Convert.ToInt32(e.CommandArgument));

                File1.RelationID = dr.RECID;
                File1.Listele();
                File1.Visible = true;

                txtName.Text = dr.NAME;
                txtNameEng.Text = dr.NAMEENG;
                txtBody.Value = dr.DESCRIPTION;
                txtBodyEng.Value = dr.DESCRIPTIONENG;
                txtLocation.Text = dr.LOCATION;
                txtDate.Text = dr.DATE.ToString();
                drpEventType.SelectedValue = dr.EVENTTYPE.ToString();
                mvAktiviteler.SetActiveView(vKayitGir);
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvAktiviteler.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grv = ((GridView)e.Row.FindControl("gvListe2"));
                //grv.RowCommand += new GridViewCommandEventHandler(grv_RowCommand);

                BSAttendedEvent bs = new BSAttendedEvent();
                DataTable ds = new DataTable();
                ds = bs.Getir_Katilanlar(Convert.ToInt32(gvListe.DataKeys[e.Row.RowIndex].Value));
                grv.DataSource = ds;
                grv.DataBind();
            }
        }

        protected void gvListe2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Onayla")
            {
                BSAttendedEvent bs = new BSAttendedEvent();
                DSAttendedEvent ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));
                ds.ATTENDEDEVENT[0].APPROVED = true;
                ds.ATTENDEDEVENT[0].APPROVEDBY = UserSession.KullaniciID;
                ds.ATTENDEDEVENT[0].APPROVEDDATE = DateTime.Now;
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            if (e.CommandName == "OnayKaldir")
            {
                BSAttendedEvent bs = new BSAttendedEvent();
                DSAttendedEvent ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));
                ds.ATTENDEDEVENT[0].SetAPPROVEDNull();
                ds.ATTENDEDEVENT[0].SetAPPROVEDBYNull();
                ds.ATTENDEDEVENT[0].SetAPPROVEDDATENull();
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "AttendSil")
            {
                BSAttendedEvent bs = new BSAttendedEvent();
                bs.Sil_byRECID(Convert.ToInt32(e.CommandArgument));
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
        }

        protected void gvListe2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lbSec = (ImageButton)e.Row.FindControl("ibAttendSec");
                ImageButton lbSil = (ImageButton)e.Row.FindControl("ibRemoveAttend");
                if (((GridView)e.Row.Parent.Parent).DataKeys[e.Row.RowIndex]["APPROVED"] == DBNull.Value)
                {
                    lbSec.Visible = true;
                    lbSil.Visible = false;
                }
                else
                {
                    lbSec.Visible = false;
                    lbSil.Visible = true;
                }

                e.Row.Cells[2].Text = CacheHelper.KullaniciTipiGetir().MEMBERSHIPTYPE.FindByRECID(Convert.ToInt32(e.Row.Cells[2].Text)).DESCRIPTION;
            }
        }
    }
}
