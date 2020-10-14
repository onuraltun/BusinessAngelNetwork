using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types.TypeDataSets;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Management;
using Types.Enums;
using System.Web.Security;

namespace Web.Library
{
    public abstract class Master : System.Web.UI.Page
    {
        protected abstract MemberShipType PageMemberShip
        {
            get;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (UserSession.UserMemberShipType == MemberShipType.Guest.GetHashCode())
            {
                string KullAdi = CerezleriOku("mban_KullaniciAdi");
                string Sifre = CerezleriOku("mban_Sifre");
                if (KullAdi != "" & Sifre != "")
                {
                    Response.Redirect("/common/login.aspx");
                }
            }
            ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery",
                Page.ResolveUrl("~/js/jquery.js"));

            ClientScript.RegisterClientScriptInclude(this.GetType(), "tooltip",
                Page.ResolveUrl("~/js/tooltip.js"));

            ClientScript.RegisterClientScriptInclude(this.GetType(), "jqueryui",
                Page.ResolveUrl("~/js/jquery.ui.js"));

            ClientScript.RegisterClientScriptInclude(this.GetType(), "JQuerycookie",
                Page.ResolveUrl("~/js/jquery.cookie.js"));

            ClientScript.RegisterClientScriptInclude(this.GetType(), "genel",
                Page.ResolveUrl("~/js/genel.js"));

            ClientScript.RegisterClientScriptInclude(this.GetType(), "flash",
                Page.ResolveUrl("~/js/flash.js"));

            base.OnPreRender(e);
        }

        public void SayfaDilAyari(Control ctrl)
        {
            if (IsPostBack)
            {
                return;
            }
            try
            {
                if (ctrl is GridView)
                {
                    if (ctrl.ID != null)
                    {
                        if (ctrl.ID.StartsWith("ex"))
                            return;
                    }

                    for (int i = 0; i < ((GridView)ctrl).Columns.Count; i++)
                    {
                        if (((GridView)ctrl).Columns[i].HeaderText != string.Empty)
                            ((GridView)ctrl).Columns[i].HeaderText = DilCevirGetir(UserSession.SeciliDil, ((GridView)ctrl).Columns[i].HeaderText.ToLower());
                    }

                    ((GridView)ctrl).EmptyDataText = DilCevirGetir(UserSession.SeciliDil, "kayityok");
                    ((GridView)ctrl).DataBind();

                    foreach (GridViewRow grow in ((GridView)ctrl).Rows)
                    {
                        SayfaDilAyari(grow);
                    }
                    return;
                }

                if (ctrl.Controls.Count > 0)
                {
                    foreach (Control ctrDil in ctrl.Controls)
                    {
                        SayfaDilAyari(ctrDil);
                    }
                }
                else
                {
                    if (ctrl.ID != null)
                    {
                        if (ctrl.ID.StartsWith("ex"))
                            return;
                    }

                    if (ctrl is Label)
                    {
                        if (((Label)ctrl).ID.StartsWith("ref") | ((Label)ctrl).ID.StartsWith("cvdrp"))
                            return;
                        ((Label)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((Label)ctrl).ID);
                    }
                    else if (ctrl is Button)
                    {
                        ((Button)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((Button)ctrl).ID);
                    }
                    else if (ctrl is DropDownList)
                    {
                        DropDownList drp = (DropDownList)ctrl;
                        for (int i = 0; i < drp.Items.Count; i++)
                        {
                            drp.Items[i].Text = DilCevirGetir(UserSession.SeciliDil, drp.Items[i].Text);
                        }
                    }
                    else if (ctrl is Literal)
                    {
                        ((Literal)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((Literal)ctrl).ID);
                    }
                    else if (ctrl is HyperLink)
                    {
                        ((HyperLink)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((HyperLink)ctrl).ID);
                    }
                    else if (ctrl is CheckBox)
                    {
                        ((CheckBox)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((CheckBox)ctrl).ID);
                    }
                    else if (ctrl is LinkButton)
                    {
                        ((LinkButton)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((LinkButton)ctrl).ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OlmayanKelimeyiKaydet(string Deyim)
        {
            DSDictionary ds = new DSDictionary();
            DSDictionary.DICTIONARYRow dr = ds.DICTIONARY.NewDICTIONARYRow();
            dr.CONTROLNAME = Deyim;
            dr.CREATEDBY = UserSession.KullaniciID;
            dr.CREATIONDATE = DateTime.Now;
            dr.ENGLISH = Deyim;
            dr.TURKISH = Deyim;
            ds.DICTIONARY.AddDICTIONARYRow(dr);
            BSDictionary bs = new BSDictionary();
            bs.Kaydet(ds);
            CacheHelper.SozlukTemizle();
        }

        public string DilCevirGetir(Dil Cevrilecekdili, string Deyim)
        {
            if (Deyim == null)
                return "";
            Deyim = Deyim.ToLower();
            if (Cevrilecekdili == Dil.Turkish)
            {
                if (CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'").Length > 0)
                {
                    return ((DSDictionary.DICTIONARYRow[])CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'"))[0].TURKISH;
                }
                else
                {
                    OlmayanKelimeyiKaydet(Deyim);
                    return Deyim;
                }
            }
            else
            {
                if (CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'").Length > 0)
                {
                    return ((DSDictionary.DICTIONARYRow[])CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'"))[0].ENGLISH;
                }
                else
                {
                    OlmayanKelimeyiKaydet(Deyim);
                    return Deyim;
                }
            }
        }

        protected string CerezleriOku(string cerezAdi)
        {
            HttpCookie authCookie = Context.Request.Cookies[cerezAdi];

            if (null == authCookie)
            {
                return "";
            }

            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                return "";
            }
            if (null == authTicket)
            {
                return "";
            }
            return authTicket.UserData;
        }
    }
}
