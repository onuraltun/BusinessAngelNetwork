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
    public partial class Activation : MasterOfMaster
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

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            BSMember bs = new BSMember();
            DSMember ds = new DSMember();

            ds = bs.KullaniciGetirRecId(Convert.ToInt32(Request.QueryString["a"]));

            if (ds.MEMBER.Rows.Count > 0)
            {
                SHA1 oSHA1 = SHA1CryptoServiceProvider.Create();
                string emailDB = Convert.ToBase64String(oSHA1.ComputeHash(Encoding.Unicode.GetBytes(ds.MEMBER[0].EMAIL)));
                if (txtActivationCode.Text == emailDB)
                {
                    //UserSession.Adi = ds.MEMBER[0].NAME;
                    //UserSession.Soyadi = ds.MEMBER[0].SURNAME;
                    //UserSession.UserMemberShipType = ds.MEMBER[0].MEMBERSHIPTYPE;
                    //UserSession.KullaniciID = ds.MEMBER[0].RECID;
                    //UserSession.Title = ds.MEMBER[0].TITLE;

                    ds.MEMBER[0].MEMBERAPPROVED = true;
                    bs.Kaydet(ds);

                    Response.Redirect("/" + ((MemberShipType)ds.MEMBER[0].MEMBERSHIPTYPE) + "/Default.aspx?task=activated");

                }
                else
                {
                    Araclar.MesajGoster(this.Page, "activationfailure", Araclar.MesajTipiEnum.Hata);
                }
            }
            else
            {
                Araclar.MesajGoster(this.Page, "activationfailure", Araclar.MesajTipiEnum.Hata);
            }
        }
    }
}
