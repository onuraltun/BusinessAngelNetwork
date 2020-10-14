using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;

namespace Web.Common
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();

            HttpCookie authCookie_user = new HttpCookie("mban_KullaniciAdi", "");
            HttpCookie authCookie_pass = new HttpCookie("mban_Sifre", "");

            Response.Cookies.Add(authCookie_user);
            Response.Cookies.Add(authCookie_pass);
            Response.Redirect("login.aspx");
        }
    }
}
