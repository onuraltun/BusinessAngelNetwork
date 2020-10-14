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
    public partial class ViewPage : MasterOfMaster
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["p"] != null)
            {
                BSPage bs = new BSPage();
                DSPage ds = new DSPage();
                ds = bs.Getir_byRECID(Convert.ToInt32(Request.QueryString["p"].ToString()));
                if (ds.PAGE.Count > 0)
                {
                    if (UserSession.SeciliDil == Dil.English)
                    {
                        exlblPage.Text = ds.PAGE[0].BODYENG;
                        exlblTitle.Text = ds.PAGE[0].TITLEENG;
                        //Page.Title = ds.PAGE[0].TITLEENG;
                    }
                    else
                    {
                        exlblPage.Text = ds.PAGE[0].BODY;
                        exlblTitle.Text = ds.PAGE[0].TITLE;
                        //Page.Title = ds.PAGE[0].TITLE;
                    }
                    
                }
            }
        }


    }
}
