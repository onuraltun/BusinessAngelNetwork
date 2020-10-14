using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Management;
using Types.TypeDataSets;
using Business.Project;
using System.IO;
using System.Drawing;
using Business;
using Types.Enums;

namespace Web
{
    public partial class ListPages : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected DSPage dsSayfalar
        {
            get
            {
                return (DSPage)Session["__Sayfalar"];
            }
            set
            {
                Session["__Sayfalar"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["p"] != null)
            {
                BSPage bs = new BSPage();
                DSPage ds = new DSPage();
                ds = bs.Getir_byRECID(Convert.ToInt32(Request.QueryString["p"]));
                if (ds.PAGE.Count > 0)
                {
                    if (UserSession.SeciliDil == Dil.English)
                    {
                        exlblPage.Text = ds.PAGE[0].BODYENG;
                        exlblTitle.Text = ds.PAGE[0].TITLEENG;
                        gvListe.Columns[0].Visible = false;
                        //Page.Title = ds.PAGE[0].TITLEENG;
                    }
                    else
                    {
                        exlblPage.Text = ds.PAGE[0].BODY;
                        exlblTitle.Text = ds.PAGE[0].TITLE;
                        gvListe.Columns[1].Visible = false;
                        //Page.Title = ds.PAGE[0].TITLE;
                    }
                    
                }

                ds = bs.Getir_byPAGETYPE(Convert.ToInt32(Request.QueryString["type"]));
                Araclar.GridDoldur(ds, gvListe);
                dsSayfalar = ds;

            }
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect("/Common/ViewPage.aspx?p=" + e.CommandArgument.ToString());

            }
        }


    }
}
