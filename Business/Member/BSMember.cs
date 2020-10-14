using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;
using Types.Enums;
using System.Data;

namespace Business.Member
{
    public class BSMember
    {
        public DSMember Kaydet(DSMember ds)
        {
            Data oData = new Data();
            oData.TopluVeriIslemeID(ds);
            return ds;
        }

        public DSMember KullaniciGetir(string eMail)
        {
            Data oData = new Data();
            DSMember dsKullanicilar = new DSMember();

            string sSQL = @"SELECT * FROM MEMBER WHERE (EMAIL = '" + eMail.Replace("'", "") + "')";
            oData.VeriGetir<DSMember>(ref dsKullanicilar, sSQL);
            return dsKullanicilar;
        }

        public DSMember KullaniciGetirRecId(int recId)
        {
            Data oData = new Data();
            DSMember dsKullanicilar = new DSMember();

            string sSQL = @"SELECT * FROM MEMBER WHERE (RECID = '" + recId.ToString() + "')";
            oData.VeriGetir<DSMember>(ref dsKullanicilar, sSQL);
            return dsKullanicilar;
        }

        public DSMember KullanicilariGetirRecId(string recIdler)
        {
            Data oData = new Data();
            DSMember dsKullanicilar = new DSMember();

            string sSQL = @"SELECT * FROM MEMBER WHERE (RECID in(" + recIdler + "))";
            oData.VeriGetir<DSMember>(ref dsKullanicilar, sSQL);
            return dsKullanicilar;
        }

        public DSMember KullanicilariGetir(MemberShipType userMemberShipType)
        {
            Data oData = new Data();
            DSMember dsKullanicilar = new DSMember();

            string sSQL = "";
            if (userMemberShipType == MemberShipType.Admin)
                sSQL = string.Format("SELECT * FROM MEMBER where MEMBERSHIPTYPE not in ({0},{1})",
               MemberShipType.Admin.GetHashCode(), MemberShipType.Guest.GetHashCode());
            else if (userMemberShipType == MemberShipType.Supervisor)
                sSQL = string.Format("SELECT * FROM MEMBER where MEMBERSHIPTYPE not in ({0},{1},{2})",
               MemberShipType.Admin.GetHashCode(), MemberShipType.Supervisor.GetHashCode(), MemberShipType.Guest.GetHashCode());


            oData.VeriGetir<DSMember>(ref dsKullanicilar, sSQL);
            return dsKullanicilar;
        }

        public DataSet GirisimcilerimiGetir(int DanismanId)
        {
            Data oData = new Data();
            DataSet dsKullanicilar = new DataSet();

            string sSQL = @"SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS adisoyadi, PROJECT.NAME AS projectname, PROJECT.CREATEDBY AS MemberID, 
                      PROJECT.RECID AS PROJEID, PROJECT.LOGO, PROJECT.ACRONYM, PROJECT.MODIFICATIONDATE, PROJECT.APPROVED
FROM         PROJECT_PROFESSIONAL INNER JOIN
                      PROJECT ON PROJECT_PROFESSIONAL.PROJECT = PROJECT.RECID INNER JOIN
                      MEMBER ON PROJECT.CREATEDBY = MEMBER.RECID
                            WHERE  (PROJECT_PROFESSIONAL.APPROVED = 1) AND (PROJECT_PROFESSIONAL.ADMINAPPROVED = 1) AND (PROJECT_PROFESSIONAL.MEMBER = " + DanismanId.ToString() + ")";
            oData.VeriGetir(ref dsKullanicilar, sSQL);
            return dsKullanicilar;
        }
    }
}