using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types.TypeDataSets;
using Business.Management;
using Business.Parameters;
using System.Data;
using Types.Enums;

namespace Web.Library
{
    public class CacheHelper
    {
        public static DSDictionary SozlukGetir()
        {
            DSDictionary ds;
            ds = (DSDictionary)HttpContext.Current.Cache["cache_DSDictionary"];

            if (ds == null)
            {
                BSDictionary bs = new BSDictionary();
                ds = bs.Getir();
                HttpContext.Current.Cache.Add("cache_DSDictionary", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void SozlukTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSDictionary");
        }

        public static DSBusinessModelType BusinessModelTypes()
        {
            DSBusinessModelType ds;
            ds = (DSBusinessModelType)HttpContext.Current.Cache["cache_DSBusinessModelType"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.BusinessModelTypeGetir();
                HttpContext.Current.Cache.Add("cache_DSBusinessModelType", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void BusinessModelTypeTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSBusinessModelType");
        }

        public static DSSektor SektorGetir()
        {
            DSSektor ds;
            ds = (DSSektor)HttpContext.Current.Cache["cache_DSSektor"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.SektorGetir();
                HttpContext.Current.Cache.Add("cache_DSSektor", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void SektorTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSSektor");
        }

        public static DSEventType EventTypeGetir()
        {
            DSEventType ds;
            ds = (DSEventType)HttpContext.Current.Cache["cache_DSEventType"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.EventTypeGetir();
                HttpContext.Current.Cache.Add("cache_DSEventType", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void EventTypeTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSEventType");
        }

        public static DSMemberShipType KullaniciTipiGetir()
        {
            DSMemberShipType ds;
            ds = (DSMemberShipType)HttpContext.Current.Cache["cache_DSMemberShipType"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.KullaniciTipleriniGetir();
                HttpContext.Current.Cache.Add("cache_DSMemberShipType", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void KullaniciTipiTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSMemberShipType");
        }

        public static DSPageType PageTypeGetir()
        {
            DSPageType ds;
            ds = (DSPageType)HttpContext.Current.Cache["cache_DSPageType"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.PageTypeGetir();
                HttpContext.Current.Cache.Add("cache_DSPageType", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void PageTypeTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSPageType");
        }

        public static DSTitle TitleGetir()
        {
            DSTitle ds;
            ds = (DSTitle)HttpContext.Current.Cache["cache_DSTitle"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.TitleGetir();
                HttpContext.Current.Cache.Add("cache_DSTitle", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void TitleTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSTitle");
        }

        public static DSInvestorType InvestorTypeGetir()
        {
            DSInvestorType ds;
            ds = (DSInvestorType)HttpContext.Current.Cache["cache_DSInvestorType"];

            if (ds == null)
            {
                BSParameters bs = new BSParameters();
                ds = bs.InvestorTypeGetir();
                HttpContext.Current.Cache.Add("cache_DSInvestorType", ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void InvestorTypeTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSInvestorType");
        }

        public static DataSet MenuGetir()
        {
            DataSet ds = (DataSet)HttpContext.Current.Cache["cache_DSMenu" + UserSession.SeciliDil.ToString()];

            if (ds == null)
            {
                BSMenu bs = new BSMenu();
                ds = bs.TumunuGetir(UserSession.SeciliDil);
                HttpContext.Current.Cache.Add("cache_DSMenu" + UserSession.SeciliDil.ToString(), ds, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return ds;
        }

        public static void MenuTemizle()
        {
            HttpContext.Current.Cache.Remove("cache_DSMenu" + Dil.English.ToString());
            HttpContext.Current.Cache.Remove("cache_DSMenu" + Dil.Turkish.ToString());
        }
    }
}
