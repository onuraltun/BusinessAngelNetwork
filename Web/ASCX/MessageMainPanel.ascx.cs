using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Messages;
using Types.TypeDataSets;
using Web.Library;
using Types.Enums;

namespace Web.ASCX
{
    public partial class MessageMainPanel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.UserMemberShipType == MemberShipType.Guest.GetHashCode())
            {
                this.Visible = false;
                return;
            }
            else
                this.Visible = true;

            BSMessages bs = new BSMessages();
            DSMessage ds = new DSMessage();
            ds = bs.MesajlarimiGetir(UserSession.KullaniciID, Mesaj_Status.Okunmadi.GetHashCode());

            if (ds.MESSAGE.Rows.Count > 0)
            {
                trNewMail.Visible = true;
                exltNewMail.Text = "<a href=\"/common/inbox.aspx\">";
                if (UserSession.SeciliDil == Dil.English)
                {
                    exltNewMail.Text += "You have " + ds.MESSAGE.Rows.Count.ToString() + " new mail.</a>";
                }
                else
                {
                    exltNewMail.Text += ds.MESSAGE.Rows.Count.ToString() + " yeni mesajınız var.</a>";
                }
            }
            else
                trNewMail.Visible = false;
        }
    }
}