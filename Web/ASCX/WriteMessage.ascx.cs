using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.TypeDataSets;
using Web.Library;
using Business.Messages;

namespace Web.ASCX
{
    public partial class WriteMessage : System.Web.UI.UserControl
    {
        public delegate void Gonder();
        public event Gonder Gonderildi;

        public int ToUser
        {
            get
            {
                return Convert.ToInt32(ViewState["__ToUser"]);
            }
            set
            {
                ViewState["__ToUser"] = value;
            }
        }

        public string DanismanAdiSoyadi
        {
            set
            {
                exlblTo.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMesajGonder_Click(object sender, EventArgs e)
        {
            MesajGonder(Mesaj_Status.Okunmadi.GetHashCode());
        }

        protected void btnMesajKaydet_Click(object sender, EventArgs e)
        {
            MesajGonder(Mesaj_Status.Taslak.GetHashCode());
        }

        protected void MesajGonder(int Status)
        {
            DSMessage ds = new DSMessage();
            DSMessage.MESSAGERow dr = ds.MESSAGE.NewMESSAGERow();
            dr.BODY = txtMesaj.Text.Trim();
            dr.FROM_USER = UserSession.KullaniciID;
            dr.RECEIVER_DELETED = false;
            dr.SENDDATE = DateTime.Now;
            dr.SENDER_DELETED = false;
            dr.STATUS = Status;
            dr.SUBJECT = txtKonu.Text.Trim();
            dr.TO_USER = ToUser;
            ds.MESSAGE.AddMESSAGERow(dr);
            BSMessages bs = new BSMessages();
            bs.MesajGonder(ds);
            if (Mesaj_Status.Okunmadi.GetHashCode() == Status)
                Araclar.MesajGoster(this.Page, "mesajSent", Araclar.MesajTipiEnum.Bilgi);
            else
                Araclar.MesajGoster(this.Page, "DraftMessageSaved", Araclar.MesajTipiEnum.Bilgi);

            btnMesajGonder.Enabled = false;
            btnMesajKaydet.Enabled = false;
            if (Gonderildi != null)
                Gonderildi();
        }
    }
}