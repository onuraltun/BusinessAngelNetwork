using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Types.Enums;
using System.Data;
using Types.TypeDataSets;
using Business.Messages;

namespace Web.Library
{
    public abstract class MasterOfMaster : Master
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (UserSession.UserMemberShipType != MemberShipType.Admin.GetHashCode())
            {
                if (PageMemberShip == MemberShipType.NotGuest && UserSession.UserMemberShipType == MemberShipType.Guest.GetHashCode())
                    Response.Redirect(ConfigurationManager.AppSettings["LoginPage"].ToString());
                else if (PageMemberShip != MemberShipType.Guest &&
                    UserSession.UserMemberShipType != PageMemberShip.GetHashCode() && PageMemberShip != MemberShipType.NotGuest)
                    Response.Redirect(ConfigurationManager.AppSettings["LoginPage"].ToString());
            }
            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnError(EventArgs e)
        {
#if DEBUG
            base.OnError(e);
#else
            System.Exception appException = Server.GetLastError();

            if (appException == null)
                appException = new Exception("Tanımsız Hata!");

            string HataMEsaji = "KullaniciID: " + UserSession.KullaniciID + "-" + UserSession.Adi;
            HataMEsaji += Convert.ToChar(13) + "Kullanici IP: " + Request.UserHostAddress + Convert.ToChar(13) + " Hata Sayfası: " + Request.FilePath + Convert.ToChar(13) + appException.ToString() + appException.StackTrace;
            HataMEsaji += Convert.ToChar(13) + "Tarayıcı : " + Request.Browser.Type + " OS: " + Request.UserAgent;

            if (appException.InnerException != null)
            {
                HataMEsaji += "Inner Exception : ";
                HataMEsaji += Convert.ToChar(13) + appException.InnerException.Message.ToString();
            }
            HataMEsaji += Convert.ToChar(13) + " Sayfa Kontrol Bilgileri: " + KontrolBilgileri(base.Page);

            if (appException is DBConcurrencyException)
            {
                Session["HataMesaji"] = "Bu kayıt sizden önce başkası tarafından değiştirilmiştir. Lütfen sayfaya yeniden giriniz! <a href=\"" + Request.FilePath + "\">Geri Dön</a>"; ;
            }
            else
            {
                Session["HataMesaji"] = "Beklenmedik bir sistem hatası oluştu! Hata ilgili birimlere aktarıldı!<br />Hata Detayı:" + HataMEsaji.Replace("\n", "<br />");
                //Hata loglanacak
                BeniMailAt(HataMEsaji);
            }

            Server.ClearError();
            Response.Redirect(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Hata.aspx");
#endif
        }

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            SayfaDilAyari(base.Page);
            base.OnLoadComplete(e);
        }

        //protected void HataLoglama(DSHatalar dsHata)
        //{
        //    try
        //    {
        //        ISistem oSistem = IsKuraliYarat.GenericIsKuraliYarat<ISistem>();
        //        oSistem.HataKaydet(dsHata);
        //    }
        //    catch
        //    {
        //        string HataMesaji = string.Empty;
        //        DSHatalar.HatalarRow drHata = dsHata.Hatalar[0];
        //        HataMesaji = "Açıklama:" + drHata.Aciklama;
        //        HataMesaji += "<br />Hata Sayfası:" + drHata.HataSayfasi;
        //        HataMesaji += "<br />KullanıcıID:" + drHata.KullaniciID.ToString();
        //        HataMesaji += "<br />Tarih:" + drHata.Tarih.ToString();
        //        BeniMailAt(HataMesaji);
        //    }
        //}

        /// <summary>
        /// Gönderilen kontrol içinde bulunan Textbox,dropdownlist ve checkbox'ların isim ve değerlerini döndürür
        /// </summary>
        /// <param name="ctrl">Kontrol, Page,View vb...</param>
        public string KontrolBilgileri(Control ctrl)
        {
            try
            {
                string Bilgiler = "";
                if (ctrl.Controls.Count > 0)
                {
                    foreach (Control ctrTemizlik in ctrl.Controls)
                    {
                        Bilgiler += KontrolBilgileri(ctrTemizlik);
                    }
                }
                else
                {
                    if (ctrl is TextBox)
                    {
                        Bilgiler += ((TextBox)ctrl).ID + "= " + ((TextBox)ctrl).Text + "<br />";
                    }
                    if (ctrl is DropDownList)
                    {
                        Bilgiler += ((DropDownList)ctrl).ID + "= Selected Value = ";
                        if (((DropDownList)ctrl).SelectedValue != null & ((DropDownList)ctrl).SelectedItem != null)
                            Bilgiler += ((DropDownList)ctrl).SelectedValue + " Secilen= " + ((DropDownList)ctrl).SelectedItem.Text;
                        Bilgiler += "<br />";
                    }
                    if (ctrl is CheckBox)
                    {
                        Bilgiler += ((CheckBox)ctrl).ID + " = " + ((CheckBox)ctrl).Checked.ToString() + "<br />";
                    }
                    if (ctrl is ListBox)
                    {
                        Bilgiler += ((ListBox)ctrl).ID + "= Selected Value = ";
                        if (((ListBox)ctrl).SelectedValue != null & ((ListBox)ctrl).SelectedItem != null)
                            Bilgiler += ((ListBox)ctrl).SelectedValue + " Secilen= " + ((ListBox)ctrl).SelectedItem.Text;
                        Bilgiler += "<br />";
                    }
                }
                return Bilgiler;
            }
            catch (Exception ex)
            {
                return "?";
            }
        }

        protected void BeniMailAt(string HataMesaji)
        {
            MailGonder mail = new MailGonder();
            mail.Konu = "Sistem Hata Mesajı";
            mail.Mesaj = HataMesaji;
            mail.To = ConfigurationManager.AppSettings["HataGonderimAdresler"].ToString();
            mail.Gonder();
            if (mail.Hata != null)
            {
                Araclar.MesajGoster(this.Page, mail.Hata.Message, Web.Library.Araclar.MesajTipiEnum.Hata);
            }
        }
    }
}
