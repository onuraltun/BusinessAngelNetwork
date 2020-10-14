using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;
using System.Data;
using Types.Enums;

namespace Business.Messages
{
    public class BSMessages
    {
        /// <summary>
        /// Gelen mesajlar ve taslakları görüntüler
        /// </summary>
        /// <param name="MemberID">Kullanıcı</param>
        /// <param name="Status">Mesajın durumu Mesaj_Status enum.</param>
        public DSMessage MesajlarimiGetir(int MemberID)
        {
            Data oData = new Data();
            DSMessage ds = new DSMessage();
            string sSQL = @"SELECT * FROM MESSAGE WHERE (TO_USER = " + MemberID.ToString() + ") AND (RECEIVER_DELETED = 0) order by SENDDATE desc";
            oData.VeriGetir<DSMessage>(ref ds, sSQL);
            return ds;
        }

        public DSMessage MesajlarimiGetir(int MemberID, int Status)
        {
            Data oData = new Data();
            DSMessage ds = new DSMessage();
            string sSQL = @"SELECT * FROM MESSAGE WHERE (TO_USER = " + MemberID.ToString() + ") AND (RECEIVER_DELETED = 0) AND Status=" + Status.ToString() + "  order by SENDDATE desc";
            oData.VeriGetir<DSMessage>(ref ds, sSQL);
            return ds;
        }

        public DSMessage GonderdigimMesajlariGetir(int MemberID, string Status)
        {
            Data oData = new Data();
            DSMessage ds = new DSMessage();
            string sSQL = @"SELECT * FROM MESSAGE WHERE (FROM_USER = " + MemberID.ToString() + ") AND (SENDER_DELETED = 0) AND STATUS in(" + Status.ToString() + ") order by SENDDATE desc";
            oData.VeriGetir<DSMessage>(ref ds, sSQL);
            return ds;
        }

        public DSMessage SilinenMesajlar(int MemberID)
        {
            Data oData = new Data();
            DSMessage ds = new DSMessage();
            string sSQL = @"SELECT * FROM MESSAGE WHERE ((TO_USER = " + MemberID.ToString() + ") AND (RECEIVER_DELETED = 1)) OR ((FROM_USER = " + MemberID.ToString() + ") AND (SENDER_DELETED = 1))  order by SENDDATE desc";
            oData.VeriGetir<DSMessage>(ref ds, sSQL);
            return ds;
        }

        public void MesajGonder(DSMessage ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DataSet GonderilecekleriGetir(int MemberID)
        {
            Data oData = new Data();
            DataSet ds = new DataSet();
            string sSQL = @" SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID
                            FROM         PROJECT_PROFESSIONAL INNER JOIN
                                                  PROJECT ON PROJECT_PROFESSIONAL.PROJECT = PROJECT.RECID INNER JOIN
                                                  MEMBER ON PROJECT.CREATEDBY = MEMBER.RECID
                            WHERE     (PROJECT_PROFESSIONAL.MEMBER = " + MemberID.ToString() + @")
                            union
                            SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID
                            FROM         MEMBER INNER JOIN
                                                  PROJECT_PROFESSIONAL ON MEMBER.RECID = PROJECT_PROFESSIONAL.MEMBER INNER JOIN
                                                  PROJECT ON PROJECT_PROFESSIONAL.PROJECT = PROJECT.RECID
                            WHERE     (PROJECT.CREATEDBY = " + MemberID.ToString() + @")
                            UNION
                            SELECT     NAME + ' ' + SURNAME AS AdiSoyadi, RECID
                            FROM         MEMBER AS MEMBERAdmin
                            WHERE     (MEMBERSHIPTYPE in(" + MemberShipType.Admin.GetHashCode().ToString() + "," + MemberShipType.Supervisor.GetHashCode().ToString() + @"))
                            UNION
                            SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID
                            FROM         MESSAGE INNER JOIN
                                                  MEMBER ON MESSAGE.FROM_USER = MEMBER.RECID
                            WHERE     (MESSAGE.TO_USER = " + MemberID.ToString() + @")

                            union

                            SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID
                            FROM         MESSAGE INNER JOIN
                                                  MEMBER ON MESSAGE.TO_USER = MEMBER.RECID
                            WHERE     (MESSAGE.FROM_USER = " + MemberID.ToString() + ")";
            oData.VeriGetir(ref ds, sSQL);
            return ds;
        }
    }
}
