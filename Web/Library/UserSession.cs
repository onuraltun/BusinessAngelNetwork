using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types.Enums;

namespace Web.Library
{

    public class UserSession
    {
        public static Dil SeciliDil
        {
            get
            {
                if (HttpContext.Current.Session["__SeciliDil"] != null)
                    return (Dil)HttpContext.Current.Session["__SeciliDil"];
                else
                    return Dil.Turkish;
            }
            set
            {
                HttpContext.Current.Session["__SeciliDil"] = value;
            }
        }

        public static int KullaniciID
        {
            get
            {
                if (HttpContext.Current.Session["__KullaniciID"] != null)
                    return Convert.ToInt32(HttpContext.Current.Session["__KullaniciID"]);
                else
                    return GuestUserID.UserID.GetHashCode();
            }
            set
            {
                HttpContext.Current.Session["__KullaniciID"] = value;
            }
        }

        public static int UserMemberShipType
        {
            get
            {
                if (HttpContext.Current.Session["__MemberShipType"] != null)
                    return Convert.ToInt32(HttpContext.Current.Session["__MemberShipType"]);
                else
                    return MemberShipType.Guest.GetHashCode();
            }
            set
            {
                HttpContext.Current.Session["__MemberShipType"] = value;
            }
        }

        public static string Adi
        {
            get
            {
                if (HttpContext.Current.Session["Adi"] != null)
                    return HttpContext.Current.Session["Adi"].ToString();
                else
                    return "";
            }
            set
            {
                HttpContext.Current.Session["Adi"] = value;
            }
        }

        public static string Soyadi
        {
            get
            {
                if (HttpContext.Current.Session["Soyadi"] != null)
                    return HttpContext.Current.Session["Soyadi"].ToString();
                else
                    return "";
            }
            set
            {
                HttpContext.Current.Session["Soyadi"] = value;
            }
        }

        public static int Title
        {
            get
            {
                if (HttpContext.Current.Session["Title"] != null)
                    return Convert.ToInt32(HttpContext.Current.Session["Title"]);
                else
                    return 0;
            }
            set
            {
                HttpContext.Current.Session["Title"] = value;
            }
        }

        public static string Menu
        {
            get
            {
                if (HttpContext.Current.Session["menum"] != null)
                    return HttpContext.Current.Session["menum"].ToString();
                else
                    return "";
            }
            set
            {
                HttpContext.Current.Session["menum"] = value;
            }
        }
    }
}
