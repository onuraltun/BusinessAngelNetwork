using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;

namespace Web
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (UserSession.SeciliDil == Dil.Turkish)
                iBanner.Src = "/images/banner/tr-1.png";
            else
                iBanner.Src = "/images/banner/eng-1.png";

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();
            txtSearch.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "Search");

            if (!Page.IsPostBack)
            {
                ddlLanguage.SelectedValue = "0";
            }
            if (Session["Test"] == null)
            {
                Araclar.MesajGoster(this.Page, "This site is for test only", Araclar.MesajTipiEnum.Bilgi);
                Session["Test"] = "...";
            }

            Page.Title = araclar.DilCevirGetir(UserSession.SeciliDil, "PageTitle");

        }

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSession.SeciliDil = (Dil)Convert.ToInt32(ddlLanguage.SelectedValue);
            Response.Redirect(Request.FilePath);
        }
    }
}
