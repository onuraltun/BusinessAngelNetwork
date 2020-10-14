using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Management;
using Types.TypeDataSets;
using System.Data;
using Web.Library;
using Types.Enums;

namespace Web.ASCX
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected override void OnInit(EventArgs e)
        {
            string j = Request.ServerVariables["http_user_agent"].ToLower();

            if (j.Contains("safari") || j.Contains("chrome"))
                Page.ClientTarget = "uplevel";



            DataSet ds;
            ds = CacheHelper.MenuGetir();

            try
            {
                if (UserSession.UserMemberShipType != MemberShipType.Guest.GetHashCode())
                {
                    DataRow[] dr = ds.Tables[0].Select("Link='/Common/Register.aspx'");

                    if (dr.Length > 0)
                    {
                        Araclar arc = new Araclar();
                        dr[0]["Text"] = arc.DilCevirGetir(UserSession.SeciliDil, "Logout");
                        dr[0]["Link"] = "/Common/Logout.aspx";
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select("Link='/Common/Logout.aspx'");

                    if (dr.Length > 0)
                    {
                        Araclar arc = new Araclar();
                        dr[0]["Text"] = arc.DilCevirGetir(UserSession.SeciliDil, "Register");
                        dr[0]["Link"] = "/Common/Register.aspx";
                    }
                }
            }
            catch { }

            if (ds.DataSetName != "Menus")
            {
                ds.DataSetName = "Menus";
                ds.Tables[0].TableName = "Menu";
                DataRelation relation = new DataRelation("ParentChild",
                        ds.Tables["Menu"].Columns["MenuID"],
                        ds.Tables["Menu"].Columns["ParentID"],
                        true);

                relation.Nested = true;
                ds.Relations.Add(relation);
            }
            xmlDataSource.Data = ds.GetXml();
            Menu1.DataBind();




            base.OnInit(e);
        }

    }
}