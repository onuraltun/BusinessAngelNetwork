using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace Web.Library
{
    public class MailGonder
    {
        string _strKonu;
        string _strMesaj;
        string _To;
        string _From;
        Exception _Hata;

        /// <summary>
        /// Mail Gönderme
        /// </summary>
        /// <param name="strKonu">Gönderilecek mailin konusu.</param>
        /// <param name="strMesaj">Gönderilecek mesaj.</param>
        /// <param name="strTo">Mailin gönderileceği kişiler. Araya virgül koyarak sıralayınız. abc@trt.net.tr,def@trt.net.tr gibi...</param>
        public MailGonder(string strKonu, string strMesaj, string strTo)
        {
            this._strKonu = strKonu;
            this._strMesaj = strMesaj;
            this._To = strTo;
            this._Hata = null;
        }

        public MailGonder()
        {
            this._Hata = null;
        }

        /// <summary>
        /// Gönderilecek mailin konusu.
        /// </summary>
        public string Konu
        {
            get
            {
                return this._strKonu;
            }
            set
            {
                this._strKonu = value;
            }
        }

        /// <summary>
        /// Gönderilecek mesaj.
        /// </summary>
        public string Mesaj
        {
            get
            {
                return this._strMesaj;
            }
            set
            {
                this._strMesaj = value;
            }
        }

        /// <summary>
        /// Mailin gönderileceği kişiler. Araya virgül koyarak sıralayınız. abc@trt.net.tr,def@trt.net.tr gibi...
        /// </summary>
        public string To
        {
            get
            {
                return this._To;
            }
            set
            {
                this._To = value;
            }
        }

        /// <summary>
        /// Maili gönderen kişi.
        /// </summary>
        public string From
        {
            get
            {
                return this._From;
            }
            set
            {
                this._From = value;
            }
        }

        /// <summary>
        /// Maili gönderir.
        /// </summary>
        public void Gonder()
        {
#if DEBUG
#else
            if (this._strKonu == string.Empty)
            {
                Exception exKonu = new Exception("Konu boş olamaz!");
                this._Hata = exKonu;
                return;
            }
            if (this._strMesaj == string.Empty)
            {
                Exception exMesaj = new Exception("Mesaj boş olamaz!");
                this._Hata = exMesaj;
                return;
            }
            if (this._To == string.Empty)
            {
                Exception exTo = new Exception("Gönderilecek adres boş olamaz!");
                this._Hata = exTo;
                return;
            }

            try
            {
                MailAddress fromAddress;
                if (string.IsNullOrEmpty(this._From))
                    fromAddress = new MailAddress("info@mersinban.com", "MersinBAN");
                else
                    fromAddress = new MailAddress(this._From, this._From);
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                smtpClient.Host = ConfigurationManager.AppSettings["SMTPAdres"].ToString();
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPAccount"].ToString(), ConfigurationManager.AppSettings["SMTPAccountPass"].ToString());
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                message.From = fromAddress;
                message.Subject = this._strKonu;
                message.IsBodyHtml = false;
                message.Body = this._strMesaj;
                foreach (string strAdres in this._To.Split(','))
                {
                    message.To.Add(strAdres);
                }
                smtpClient.Send(message);
            }
            catch (Exception exHata)
            {
                this._Hata = exHata;
            }
#endif
        }

        public Exception Hata
        {
            get
            {
                return _Hata;
            }
        }
    }
}
