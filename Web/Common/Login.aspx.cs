using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using Business.Member;
using Types.TypeDataSets;
using Web.Library;
using System.Configuration;
using Types.Enums;

namespace Web
{
    public partial class Login : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected override void OnInit(EventArgs e)
        {
            tdLogin.Attributes.Remove("class");
            if (UserSession.SeciliDil == Dil.Turkish)
            {
                tdLogin.Attributes.Add("class", "LoginBG_tr");
                btnLogin.ImageUrl = "~/images/giris.jpg";
            }
            else
            {
                tdLogin.Attributes.Add("class", "LoginBG_en");
                btnLogin.ImageUrl = "~/images/login.jpg";
            }

            lbForgotPassword.Click += new EventHandler(lbForgotPassword_Click);
            lbRegister.Click += new EventHandler(lbRegister_Click);

            base.OnInit(e);
        }

        void lbRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        void lbForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgottenPassword.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string KullAdi = "";
                string Sifre = "";
                if (!string.IsNullOrEmpty(Request.Form["u"]) && !string.IsNullOrEmpty(Request.Form["p"]))
                {
                    KullAdi = Request.Form["u"];
                    Sifre = Request.Form["p"];
                }
                else
                {
                    KullAdi = CerezleriOku("mban_KullaniciAdi");
                    Sifre = CerezleriOku("mban_Sifre");
                }


                if (KullAdi != "" & Sifre != "")
                {
                    txtUserName.Text = KullAdi;
                    txtPassword.Text = Sifre;
                    btnLogin_Click(null, null);
                }

                Araclar arc = new Araclar();
                arc.SayfaDilAyari(this.Page);
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

        protected void BeniHatirla()
        {
            FormsAuthenticationTicket authTicket_user = new FormsAuthenticationTicket(1,
                    txtUserName.Text, DateTime.Now, DateTime.Now.AddMonths(1), true, txtUserName.Text);

            string encryptedTicket_user = FormsAuthentication.Encrypt(authTicket_user);

            FormsAuthenticationTicket authTicket_pass = new FormsAuthenticationTicket(1,
                            txtPassword.Text, DateTime.Now, DateTime.Now.AddMonths(1), true, txtPassword.Text);

            string encryptedTicket_pass = FormsAuthentication.Encrypt(authTicket_pass);

            HttpCookie authCookie_user = new HttpCookie("mban_KullaniciAdi", encryptedTicket_user);
            HttpCookie authCookie_pass = new HttpCookie("mban_Sifre", encryptedTicket_pass);

            authCookie_user.Expires = authTicket_user.Expiration;
            authCookie_pass.Expires = authTicket_pass.Expiration;

            Response.Cookies.Add(authCookie_user);
            Response.Cookies.Add(authCookie_pass);
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();
            ds = bs.KullaniciGetir(txtUserName.Text);

            if (ds.MEMBER.Rows.Count > 0)
            {
                SHA1 oSHA1 = SHA1CryptoServiceProvider.Create();
                string pass = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(txtPassword.Text)));
                if (ds.MEMBER[0].PASSWORD == pass)
                {
                    if (!ds.MEMBER[0].IsMEMBERAPPROVEDNull() && ds.MEMBER[0].MEMBERAPPROVED == false)
                    {
                        Araclar.MesajGoster(this.Page, "mailnotactivated", Araclar.MesajTipiEnum.Hata);
                        return;
                    }
                    UserSession.Adi = ds.MEMBER[0].NAME;
                    UserSession.Soyadi = ds.MEMBER[0].SURNAME;
                    UserSession.UserMemberShipType = ds.MEMBER[0].MEMBERSHIPTYPE;
                    UserSession.KullaniciID = ds.MEMBER[0].RECID;
                    UserSession.Title = ds.MEMBER[0].TITLE;

                    if (cbRememberMe.Checked)
                        BeniHatirla();

                    if (UserSession.UserMemberShipType == MemberShipType.Entrepreneur.GetHashCode())
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Entrepreneur/Default.aspx");
                    }
                    else if (UserSession.UserMemberShipType == MemberShipType.Investor.GetHashCode())
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Investor/Default.aspx");
                    }
                    else if (UserSession.UserMemberShipType == MemberShipType.Professional.GetHashCode())
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Professional/Default.aspx");
                    }
                    else if (UserSession.UserMemberShipType == MemberShipType.Admin.GetHashCode())
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Admin/Default.aspx");
                    }
                    else if (UserSession.UserMemberShipType == MemberShipType.Supervisor.GetHashCode())
                    {
                        Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Supervisor/Default.aspx");
                    }
                }
                else
                {
                    Araclar.MesajGoster(this.Page, "loginfailure", Araclar.MesajTipiEnum.Hata);
                }
            }
            else
            {
                Araclar.MesajGoster(this.Page, "loginfailure", Araclar.MesajTipiEnum.Hata);
            }
        }
    }
}
