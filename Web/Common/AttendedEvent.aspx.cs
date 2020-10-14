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
using System.Data;
using Types.Enums;
using System.Web.UI.HtmlControls;

namespace Web.Common
{
    public partial class AttendedEvent : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
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

        protected DataTable dsAktiviteler
        {
            get
            {
                return (DataTable)Session["__Aktiviteler"];
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
                if (UserSession.UserMemberShipType == MemberShipType.Guest.GetHashCode())
                {
                    gvListe.Columns[gvListe.Columns.Count - 1].Visible = false;
                    //gvListe.Columns[gvListe.Columns.Count - 3].Visible = false;
                }
                Listele();
            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ekle")
            {
                BSAttendedEvent bs = new BSAttendedEvent();
                DSAttendedEvent ds = new DSAttendedEvent();
                DSAttendedEvent.ATTENDEDEVENTRow dr = ds.ATTENDEDEVENT.NewATTENDEDEVENTRow();
                dr.ATTENDDATE = DateTime.Now;
                dr.MEMBER = UserSession.KullaniciID;
                dr.EVENT = Convert.ToInt32(e.CommandArgument);
                ds.ATTENDEDEVENT.AddATTENDEDEVENTRow(dr);
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sil")
            {
                BSAttendedEvent bs = new BSAttendedEvent();
                bs.Sil_byRECID(Convert.ToInt32(e.CommandArgument));
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
        }

        protected void Listele()
        {
            BSEvent bs = new BSEvent();
            DataTable ds = new DataTable();

            DateTime? date = null;
            if (Request.QueryString["e"] != null)
            {
                date = new DateTime(Convert.ToInt64(Request.QueryString["e"]));
                ds = bs.BenimkileriGetir(UserSession.KullaniciID, date, null, EventTypes.Event);
            }
            else if (Request.QueryString["t"] != null)
            {
                ds = bs.BenimkileriGetir(UserSession.KullaniciID, null, Convert.ToInt32(Request.QueryString["t"]), EventTypes.Training);
            }
            else
            {
                if (Request.QueryString["type"] == null)
                    ds = bs.BenimkileriGetir(UserSession.KullaniciID, null, null, null);
                else
                    ds = bs.BenimkileriGetir(UserSession.KullaniciID, null, null, (EventTypes)Convert.ToInt32(Request.QueryString["type"]));
            }

            dsAktiviteler = ds;
            Araclar.GridDoldur(ds, gvListe);
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (dsAktiviteler == null)
                    return;

                ImageButton lbSec = (ImageButton)e.Row.FindControl("ibSec");
                ImageButton lbSil = (ImageButton)e.Row.FindControl("ibSil");
                if (dsAktiviteler.Rows[e.Row.RowIndex]["ATTENDEDRECID"] == DBNull.Value)
                {
                    lbSec.Visible = true;
                    lbSil.Visible = false;
                }
                else
                {
                    lbSec.Visible = false;
                    lbSil.Visible = true;
                }

                Literal ltEventType = (Literal)e.Row.FindControl("exltEVENTTYPE");
                ltEventType.Text = DilCevir(CacheHelper.EventTypeGetir().EVENTTYPE.FindByRECID(
                    Convert.ToInt32(dsAktiviteler.Rows[e.Row.RowIndex]["EVENTTYPE"])).DESCRIPTION);

                Literal ltApproved = (Literal)e.Row.FindControl("exltApproved");
                if (dsAktiviteler.Rows[e.Row.RowIndex]["APPROVED"].ToString() == "True")
                {
                    ltApproved.Text = DilCevirGetir(UserSession.SeciliDil, "Approved");
                    lbSec.Visible = false;
                    lbSil.Visible = false;
                }
                else
                {
                    if (dsAktiviteler.Rows[e.Row.RowIndex]["ATTENDEDRECID"] != DBNull.Value)
                        ltApproved.Text = DilCevirGetir(UserSession.SeciliDil, "Approving");
                }

                HtmlTableRow trNAME = (HtmlTableRow)e.Row.FindControl("trNAME");
                HtmlTableRow trNAMEENG = (HtmlTableRow)e.Row.FindControl("trNAMEENG");
                HtmlTableRow trDESCRIPTION = (HtmlTableRow)e.Row.FindControl("trDESCRIPTION");
                HtmlTableRow trDESCRIPTIONENG = (HtmlTableRow)e.Row.FindControl("trDESCRIPTIONENG");
                if (UserSession.SeciliDil == Dil.Turkish)
                {
                    trNAME.Visible = true;
                    trNAMEENG.Visible = false;
                    trDESCRIPTION.Visible = true;
                    trDESCRIPTIONENG.Visible = false;
                }
                else
                {
                    trNAME.Visible = false;
                    trNAMEENG.Visible = true;
                    trDESCRIPTION.Visible = false;
                    trDESCRIPTIONENG.Visible = true;
                }

                Web.ASCX.File file = (Web.ASCX.File)e.Row.FindControl("File1");
                file.RelationID = Convert.ToInt32(dsAktiviteler.Rows[e.Row.RowIndex]["RECID"]);
                file.TaskName = "Guest";
                file.Listele();
            }
        }

        public string DilCevir(string deyim)
        {
            return DilCevirGetir(UserSession.SeciliDil, deyim);
        }

    }
}
