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
    public partial class TemplateHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();
            string memberWelcome = "";

            if (UserSession.UserMemberShipType == MemberShipType.Guest.GetHashCode())
            {
                if (Request.FilePath.ToLower() == "/default.aspx")
                {
                    imgGuest.InnerHtml = @"<script language='JavaScript' type='text/javascript'>
	                    AC_FL_RunContent(
		                    'codebase', 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0',
		                    'width', '960',
		                    'height', '345',
		                    'src', '/Images/underwater" + (UserSession.SeciliDil == Dil.Turkish ? "_tr" : "") + @"',
		                    'quality', 'high',
		                    'pluginspage', 'http://www.adobe.com/go/getflashplayer',
		                    'align', 'middle',
		                    'play', 'true',
		                    'loop', 'true',
		                    'scale', 'showall',
		                    'wmode', 'opaque',
		                    'devicefont', 'false',
		                    'id', 'underwater',
		                    'bgcolor', '#4aa3f5',
		                    'name', 'underwater" + (UserSession.SeciliDil == Dil.Turkish ? "_tr" : "") + @"',
		                    'menu', 'true',
		                    'allowFullScreen', 'false',
		                    'allowScriptAccess','sameDomain',
		                    'movie', '/Images/underwater" + (UserSession.SeciliDil == Dil.Turkish ? "_tr" : "") + @"',
		                    'salign', ''
		                    ); //end AC code
                    </script>";
                }
                else
                    imgGuest.Visible = false;
            }
            else
            {
                memberWelcome = araclar.DilCevirGetir(UserSession.SeciliDil, "welcome") + " " +
                    araclar.DilCevirGetir(UserSession.SeciliDil, CacheHelper.TitleGetir().TITLE.FindByRECID(UserSession.Title).DESCRIPTION) + " " +
                    UserSession.Adi + " " + UserSession.Soyadi;
            }


            if (UserSession.UserMemberShipType == MemberShipType.Entrepreneur.GetHashCode()
                || Request.FilePath.ToLower() == "/entrepreneur/default.aspx")
            {
                pnlMember.Visible = true;
                if (UserSession.SeciliDil == Dil.English)
                {
                    exltEnt_eng_lo.Text = memberWelcome;
                    if (UserSession.UserMemberShipType == MemberShipType.Entrepreneur.GetHashCode())
                        ent_eng_lo.Visible = true;
                    else
                        ent_eng_guest.Visible = true;
                }
                else
                {
                    exltEnt_tr_lo.Text = memberWelcome;
                    if (UserSession.UserMemberShipType == MemberShipType.Entrepreneur.GetHashCode())
                        ent_tr_lo.Visible = true;
                    else
                        ent_tr_guest.Visible = true;
                }

            }
            else if (UserSession.UserMemberShipType == MemberShipType.Professional.GetHashCode()
                || Request.FilePath.ToLower() == "/professional/default.aspx")
            {
                pnlMember.Visible = true;
                if (UserSession.SeciliDil == Dil.English)
                {
                    exltPro_eng_lo.Text = memberWelcome;
                    if (UserSession.UserMemberShipType == MemberShipType.Professional.GetHashCode())
                        pro_eng_lo.Visible = true;
                    else
                        pro_eng_guest.Visible = true;
                }
                else
                {
                    exltPro_tr_lo.Text = memberWelcome;
                    if (UserSession.UserMemberShipType == MemberShipType.Professional.GetHashCode())
                        pro_tr_lo.Visible = true;
                    else
                        pro_tr_guest.Visible = true;
                }

            }
            else if (UserSession.UserMemberShipType == MemberShipType.Investor.GetHashCode()
                || Request.FilePath.ToLower() == "/ınvestor/default.aspx")
            {
                pnlMember.Visible = true;
                if (UserSession.SeciliDil == Dil.English)
                {
                    exltInv_eng_lo.Text = memberWelcome;
                    if (UserSession.UserMemberShipType == MemberShipType.Investor.GetHashCode())
                        inv_eng_lo.Visible = true;
                    else
                        inv_eng_guest.Visible = true;
                }
                else
                {
                    exltInv_tr_lo.Text = memberWelcome;
                    if (UserSession.UserMemberShipType == MemberShipType.Investor.GetHashCode())
                        inv_tr_lo.Visible = true;
                    else
                        inv_tr_guest.Visible = true;
                }
            }

            lbAdminPanel.Visible = ((UserSession.UserMemberShipType == MemberShipType.Supervisor.GetHashCode())
            || (UserSession.UserMemberShipType == MemberShipType.Admin.GetHashCode()));
        }

        protected void lbAdminPanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/");
        }
    }
}