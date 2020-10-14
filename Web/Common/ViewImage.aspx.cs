using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using System.Configuration;
using Business.Member;
using Types.TypeDataSets;

namespace Web.Common
{
    public partial class ViewImage : System.Web.UI.Page
    {
        public void ShowImage(int memberId, string task)
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();
            DSMember.MEMBERRow dr = bs.KullaniciGetirRecId(memberId).MEMBER[0];

            if (task == "p")
            {
                if (!dr.IsPICTURENull())
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=logo");
                    Response.AddHeader("Content-Length", dr.PICTURE.Length.ToString());
                    Response.ContentType = "image/bmp";
                    Response.BinaryWrite(dr.PICTURE);
                }
                else
                {
                    Response.TransmitFile(ConfigurationManager.AppSettings["RootDirectory"] + "images/nologo.jpg");
                }
            }
            else if (task == "l")
            {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowImage(Convert.ToInt32(Request.QueryString["r"]), Request.QueryString["t"]);
        }
    }
}
