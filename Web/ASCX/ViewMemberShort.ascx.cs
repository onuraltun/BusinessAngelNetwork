using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Member;
using Types.TypeDataSets;
using Web.Library;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Drawing;
using Types.Enums;

namespace Web.ASCX
{
    public partial class ViewMemberShort : System.Web.UI.UserControl
    {
        #region properties


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSMember bs = new BSMember();
                DSMember ds = new DSMember();

                ds = bs.KullaniciGetirRecId(Convert.ToInt32(Request.QueryString["m"]));
                imgMember.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=p&r={0}", Request.QueryString["m"]);

                DSMember.MEMBERRow dr = ds.MEMBER[0];

                trInvestorType.Visible = trAmount.Visible = (dr.MEMBERSHIPTYPE == MemberShipType.Investor.GetHashCode());

                if (!dr.IsAMOUNTSPERINVESTMENTNull())
                    exltAMOUNTSPERINVESTMENT.Text = dr.AMOUNTSPERINVESTMENT.ToString();
                if (!dr.IsCOMPANYNAMENull())
                    exltCOMPANYNAME.Text = dr.COMPANYNAME;
                exltNAME.Text = dr.NAME;
                if (!dr.IsPOSITIONNull())
                    exltPOSITION.Text = dr.POSITION;
                exltSURNAME.Text = dr.SURNAME;



                Araclar araclar = new Araclar();

                if (!dr.IsINVESTORTYPENull())
                    exltInvestorType.Text = araclar.DilCevirGetir(UserSession.SeciliDil, CacheHelper.InvestorTypeGetir().INVESTORTYPE.FindByRECID(dr.INVESTORTYPE).DESCRIPTION);

                exltTitle.Text = araclar.DilCevirGetir(UserSession.SeciliDil, CacheHelper.TitleGetir().TITLE.FindByRECID(dr.TITLE).DESCRIPTION);

                mvListe.SetActiveView(vKayitGoster);
                mvListe.Visible = true;


            }
        }
    }
}