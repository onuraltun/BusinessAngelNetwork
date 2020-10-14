using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.TypeDataSets;
using System.Configuration;

namespace Web
{
    public partial class ShowPicture : System.Web.UI.Page
    {
        protected DSProject dsProjelerim
        {
            get
            {
                return (DSProject)Session["__Projelerim"];
            }
            set
            {
                Session["__Projelerim"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DSProject.PROJECTRow dr = dsProjelerim.PROJECT.FindByRECID(Convert.ToInt32(Request.QueryString["id"]));
            if (!dr.IsLOGONull())
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=logo");
                Response.AddHeader("Content-Length", dr.LOGO.Length.ToString());
                Response.ContentType = "image/bmp";
                Response.BinaryWrite(dr.LOGO);
            }
            else
            {
                Response.TransmitFile(ConfigurationManager.AppSettings["RootDirectory"] + "images/nologo.jpg");
            }
        }
    }
}
