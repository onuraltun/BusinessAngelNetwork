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
    public partial class Contact : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            MailGonder mail = new MailGonder();

            mail.Konu = txtSubject.Text;
            mail.Mesaj = txtMessage.Text + "" + txtNameSurname.Text + " " + txtTelephone.Text;
            mail.From = txtEmail.Text;
            mail.To = "info@mersinban.com";

            mail.Gonder();
            Araclar araclar = new Araclar();
            exLtResult.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "Mesajınız bize ulaştı. En kısa sürede size geri döneceğiz.");
        }
    }
}
