using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Types.Enums
{
    public class Enums
    {
        public static string TrainingIds = "13,14,15";
        public static string EventIds = "3,4,5,6,7,9,10,11";
    }

    public enum Dil
    {
        Turkish = 1,
        English = 2
    }

    public enum MemberShipType
    {
        Guest = 7,
        Entrepreneur = 6,
        Investor = 1,
        Professional = 5,
        Supervisor = 8,
        Admin = 9,
        NotGuest = 9999
    }

    public enum GuestUserID
    {
        UserID = 7
    }

    public enum FileTypeEnums
    {
        CV = 1,
        LEGAL_DOCUMENT = 9,
        CERTIFICATE = 10,
        USED_ON_PAGE = 11,
        USED_ON_EVENT = 12
    }

    public enum Log_Yapilan_Islem_Turu
    {
        Yeni_Kayit = 1,
        Kayit_Guncelleme = 2,
        Kayit_Silme = 3,
        Diger = 4
    }

    public enum EventTypes
    {
        Event = 1,
        Training = 2
    }

    public enum PageTypes
    {
        Page = 1,
        News = 2,
        Article = 3,
        Press = 4
    }

    public enum MembershipPages
    {
        Entrepreneur = 539,
        Professional = 540,
        Investor = 541
    }


}
