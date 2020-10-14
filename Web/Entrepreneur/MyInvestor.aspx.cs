using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Member;
using Types.TypeDataSets;
using Types.Enums;
using System.Configuration;
using Business.Project;
using System.Data;

namespace Web.Common
{
    public partial class MyInvestor : MasterOfMaster
    {
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

        protected override Types.Enums.MemberShipType PageMemberShip
        {
            get { return Types.Enums.MemberShipType.Entrepreneur; }
        }

        protected DataSet dsUyeler
        {
            get
            {
                return (DataSet)Session["__Uyeler"];
            }
            set
            {
                Session["__Uyeler"] = value;
            }
        }

        protected DSProject dsProjeler
        {
            get
            {
                return (DSProject)Session["__Projeler"];
            }
            set
            {
                Session["__Projeler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSProject bs = new BSProject();
                DSProject ds = new DSProject();
                ds = bs.Getir_byCREATEDBY(UserSession.KullaniciID);

                Araclar.GridDoldur(ds, gvProject);
                dsProjeler = ds;
            }
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ibViewMember = (ImageButton)e.Row.FindControl("ibViewMember");
                ibViewMember.ToolTip = " <iframe height=\"240\" width=\"250\" src=\"" +
                    ConfigurationManager.AppSettings["RootDirectory"] + "Common/ViewMemberShort.aspx?m=" +
                    dsUyeler.Tables[0].Rows[e.Row.RowIndex]["INV"] + "\"/>";
                if (gvListe.DataKeys[e.Row.RowIndex]["ENTREAPPROVED"]==DBNull.Value ||
                    !Convert.ToBoolean(gvListe.DataKeys[e.Row.RowIndex]["ENTREAPPROVED"]))
                    e.Row.FindControl("tdAccept").Visible = true;
                else
                    e.Row.FindControl("tdRemoveAccept").Visible = true;
            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            BSInvestor_Project bs = new BSInvestor_Project();
            DSInvestor_Project ds = new DSInvestor_Project();
            ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument.ToString()));

            if (e.CommandName == "Message")
            {
                WriteMessage1.ToUser = Convert.ToInt32(ds.INVESTOR_PROJECT[0].INVESTOR);
                WriteMessage1.DanismanAdiSoyadi = dsUyeler.Tables[0].Select("INV=" + ds.INVESTOR_PROJECT[0].INVESTOR.ToString())[0]["AdiSoyadi"].ToString();

                mpFiltre2.Show();
            }
            else if (e.CommandName == "View")
            {
                //if (dsUyeler.Tables[0].Select("INV=" + dr.MEMBER.ToString())[0]["PROAPPROVED"].ToString() == "True")
                Response.Redirect("/Common/ViewMember.aspx?m=" + ds.INVESTOR_PROJECT[0].INVESTOR.ToString());
                //else
                //    Araclar.MesajGoster(this.Page, "notapproved", Araclar.MesajTipiEnum.Uyari);

            }
            else if (e.CommandName == "Accept")
            {

                ds.INVESTOR_PROJECT[0].ENTREAPPROVED = true;
                bs.Kaydet(ds);
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

                BSProject bsProject = new BSProject();
                DataSet dsxx = new DataSet();
                dsxx = bsProject.MyInvestor(this.MasterID);
                Araclar.GridDoldur(dsxx, gvListe);
                dsUyeler = dsxx;
            }
            else if (e.CommandName == "RemoveAccept")
            {

                ds.INVESTOR_PROJECT[0].ENTREAPPROVED = false;
                bs.Kaydet(ds);
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

                BSProject bsProject = new BSProject();
                DataSet dsxx = new DataSet();
                dsxx = bsProject.MyInvestor(this.MasterID);
                Araclar.GridDoldur(dsxx, gvListe);
                dsUyeler = dsxx;
            }
        }

        protected void gvProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ListInvestors")
            {
                BSProject bs = new BSProject();
                DataSet ds = new DataSet();
                ds = bs.MyInvestor(Convert.ToInt32(e.CommandArgument));
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                dsUyeler = ds;
                Araclar.GridDoldur(ds, gvListe);

            }
        }
    }
}
