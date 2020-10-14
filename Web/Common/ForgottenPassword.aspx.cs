using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Member;
using Types.TypeDataSets;
using System.Security.Cryptography;
using System.Text;
using Web.Library;
using Types.Enums;

namespace Web
{
    public partial class ForgottenPassword : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Araclar arc = new Araclar();
                arc.SayfaDilAyari(this.Page);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();
            ds = bs.KullaniciGetir(txtUserName.Text);
            Araclar arc = new Araclar();

            if (ds.MEMBER.Rows.Count > 0)
            {
                Random rnd = new Random();
                string pass = string.Empty;

                for (int i = 0; i < 6; i++)
                {
                    pass += rnd.Next(1, 9).ToString();
                }

                SHA1 oSHA1 = SHA1CryptoServiceProvider.Create();
                string passencrypt = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(pass)));

                ds.MEMBER[0].PASSWORD = passencrypt;

                string body = string.Format(arc.DilCevirGetir(UserSession.SeciliDil, "Forgotten_Password_Send_Message"), pass);
                MailGonder mesaj = new MailGonder(arc.DilCevirGetir(UserSession.SeciliDil, "new_password_reminder"), body, ds.MEMBER[0].EMAIL);
                mesaj.Gonder();
                if (mesaj.Hata == null)
                {
                    bs.Kaydet(ds);
                    Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
                    btnSend.Enabled = false;
                }
            }
            else
            {
                Araclar.MesajGoster(this.Page, "usernotfoundfailure", Araclar.MesajTipiEnum.Hata);
            }
        }
    }
}
