using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;

namespace Web.ASCX
{
    public partial class TellAFriend : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.SeciliDil == Dil.Turkish)
            {
                ibTellAFriend.ImageUrl = "/images/template/3t.png";
            }
            else
            {
                ibTellAFriend.ImageUrl = "/images/template/3e.png";
            }
        }
        protected void btnTellAFriend_Click(object sender, EventArgs e)
        {
            MailGonder mail = new MailGonder();
            mail.Konu = string.Format("Arkadaşınız {0} dan site tavsiyesi. www.mersinban.com", txtNameSurnameTell.Text);
            mail.Mesaj = string.Format("Arkadaşınız {0}, size sitemizi tavsiye etti. Adresimiz www.mersinban.com", txtNameSurnameTell.Text);
            mail.To = txtEmailTell.Text;
            mail.Gonder();
            pnlTellAFriend.Visible = false;
            lblTellAFriendInfo.Visible = true;

        }

        protected void ibTellAFriend_Click(object sender, ImageClickEventArgs e)
        {
            pnlTellAFriend.Visible = true;
            ibTellAFriend.Visible = false;
        }
    }
}