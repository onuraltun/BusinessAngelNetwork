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
    public partial class ChangePassword : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.NotGuest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();

            ds = bs.KullaniciGetirRecId(UserSession.KullaniciID);

            if (ds.MEMBER.Rows.Count > 0)
            {
                SHA1 oSHA1 = SHA1CryptoServiceProvider.Create();
                string pass = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(txtPASSWORD.Text)));
                string oldPass = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(txtOldPassword.Text)));
                if (oldPass == ds.MEMBER[0].PASSWORD)
                {
                    ds.MEMBER[0].PASSWORD = pass;
                    bs.Kaydet(ds);

                    if (UserSession.UserMemberShipType == MemberShipType.Entrepreneur.GetHashCode())
                    {
                        Araclar.MesajGoster(this.Page, "passwordchanged", Araclar.MesajTipiEnum.Bilgi);
                    }

                }
                else
                {
                    Araclar.MesajGoster(this.Page, "oldpassiswrong", Araclar.MesajTipiEnum.Hata);
                }
            }
            else
            {
                Araclar.MesajGoster(this.Page, "error", Araclar.MesajTipiEnum.Hata);
            }
        }
    }
}
