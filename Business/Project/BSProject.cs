using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;
using System.Data;

namespace Business.Project
{
    public class BSProject
    {
        #region Auto Code
        public void Kaydet(DSProject ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSProject Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where RECID=" + param;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }
        public DSProject Getir_bySECTOR(System.Int32 param)
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where SECTOR=" + param;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }
        public DSProject Getir_byBUSINESSMODELTYPE(System.Int32 param)
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where BUSINESSMODELTYPE=" + param;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public DSProject Getir_byLOGOAPPROVED(System.Boolean param)
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where LOGOAPPROVED=" + param;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }
        public DSProject Getir_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where CREATEDBY=" + param;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }
        public DSProject Getir_byMODIFIEDBY(System.Int32 param)
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where MODIFIEDBY=" + param;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_bySECTOR(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where SECTOR=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byBUSINESSMODELTYPE(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where BUSINESSMODELTYPE=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byAPPROVED(System.Boolean param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where APPROVED=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byLOGOAPPROVED(System.Boolean param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where LOGOAPPROVED=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where CREATEDBY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMODIFIEDBY(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROJECT where MODIFIEDBY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        #endregion

        public DataSet ProjeDanismanlariniGetir(int ProjectID, int APPROVED, int AdminAPPROVED)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID
                            FROM         PROJECT_PROFESSIONAL INNER JOIN
                                                  MEMBER ON PROJECT_PROFESSIONAL.MEMBER = MEMBER.RECID
                            WHERE     (PROJECT_PROFESSIONAL.PROJECT = " + ProjectID.ToString() + ") AND APPROVED=" + APPROVED.ToString() + " AND ADMINAPPROVED=" + AdminAPPROVED.ToString();
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DataSet ProjeDanismanlariniGetir(int ProjectID)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID,APPROVED,PROAPPROVED
                            FROM         PROJECT_PROFESSIONAL INNER JOIN
                                                  MEMBER ON PROJECT_PROFESSIONAL.MEMBER = MEMBER.RECID
                            WHERE     (PROJECT_PROFESSIONAL.PROJECT = " + ProjectID.ToString() + ")";
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DataSet MyAdvisor(int ProjectID)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT    PROJECT_PROFESSIONAL.RECID, MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID PRO,APPROVED,PROAPPROVED
                            FROM         PROJECT_PROFESSIONAL INNER JOIN
                                                  MEMBER ON PROJECT_PROFESSIONAL.MEMBER = MEMBER.RECID
                            WHERE     (PROJECT_PROFESSIONAL.PROJECT = " + ProjectID.ToString() + ")";
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DataSet DanismanSorgula(int SectorID, int ProjectID)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sSQL = @"SELECT     MEMBER.NAME + ' ' + MEMBER.SURNAME AS NAMESURNAME, MEMBER.RECID, MEMBER.COMPANYNAME,PROFESSIONAL_SECTORS.SECTORID
                            FROM         PROFESSIONAL_SECTORS INNER JOIN
                                                  MEMBER ON PROFESSIONAL_SECTORS.MEMBERID = MEMBER.RECID
                            WHERE     (MEMBER.RECID NOT IN
                          (SELECT     MEMBER
                            FROM          PROJECT_PROFESSIONAL
                            WHERE      (PROJECT = " + ProjectID.ToString() + "))) AND (PROFESSIONAL_SECTORS.SECTORID = " + SectorID.ToString() + ")";
            dc.VeriGetir(ref ds, sSQL);
            return ds;
        }

        public void ProjeDanismaniSil(int ProfessionalID, int ProjectID)
        {
            Data dc = new Data();
            string sSQL = @"DELETE FROM PROJECT_PROFESSIONAL WHERE (MEMBER = " + ProfessionalID.ToString() + ") AND PROJECT=" + ProjectID.ToString();
            dc.SQLKomutCalistir(sSQL);
        }

        public void DanismanKaydet(DSProjectProfessionals ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public void BusinessPlanKaydet(DSProjectBusinessPlan ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSProjectBusinessPlan BusinessPlanSorgula(int ProjectID)
        {
            Data dc = new Data();
            DSProjectBusinessPlan ds = new DSProjectBusinessPlan();
            string sSQL = @"Select * from " + ds.PROJECT_BUSINESS_PLAN.TableName + " where ProjectID=" + ProjectID.ToString();
            dc.VeriGetir(ref ds, sSQL);
            return ds;
        }

        public DSProject Getir_byNOTAPPROVED()
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select * from PROJECT where APPROVED is null or APPROVED=0";
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public DSProject Getir(string WhereCondition)
        {
            Data dc = new Data();
            DSProject ds = new DSProject();
            string sql = @"SELECT * FROM PROJECT WHERE " + WhereCondition;
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public DataSet Getir_OnayBekleyenDanismalar(int MemberID)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT PROJECT.NAME AS PROJECTNAME, MEMBER.NAME + ' ' + MEMBER.SURNAME AS NAMESURNAME, PROJECT_PROFESSIONAL.RECID
                           FROM PROJECT INNER JOIN
                           PROJECT_PROFESSIONAL ON PROJECT.RECID = PROJECT_PROFESSIONAL.PROJECT INNER JOIN
                           MEMBER ON PROJECT_PROFESSIONAL.MEMBER = MEMBER.RECID
                           WHERE (PROJECT.CREATEDBY = " + MemberID.ToString() + ") AND (PROJECT_PROFESSIONAL.APPROVED = 0)";
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DSProjectProfessionals DanismanKaydiniGetir(int RECID)
        {
            Data dc = new Data();
            DSProjectProfessionals ds = new DSProjectProfessionals();
            string sSQL = @"Select * from " + ds.PROJECT_PROFESSIONAL.TableName + " where RECID=" + RECID.ToString();
            dc.VeriGetir<DSProjectProfessionals>(ref ds, sSQL);
            return ds;
        }

        public DSProjectProfessionals DanismanKaydiniGetir(int DanismanID, int ProjectID)
        {
            Data dc = new Data();
            DSProjectProfessionals ds = new DSProjectProfessionals();
            string sSQL = @"Select * from " + ds.PROJECT_PROFESSIONAL.TableName + " where Member=" + DanismanID.ToString() + " AND Project=" + ProjectID.ToString();
            dc.VeriGetir<DSProjectProfessionals>(ref ds, sSQL);
            return ds;
        }

        public DSProject Getir_byAPPROVED()
        {
            Data dc = new Data();
            DSProject ds = new DSProject();
            string sql = @"Select * from PROJECT where APPROVED=1";
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public DSProject NewBusinessIdeas()
        {
            Data dc = new Data();
            DSProject ds = new DSProject(); string sql = @"Select top 5 * from PROJECT Order By CREATIONDATE DESC";
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public DSProject Getir_byPROAPPROVED(int durum, int DanismanID)
        {
            Data dc = new Data();
            DSProject ds = new DSProject();
            string sql = @"SELECT *
                    FROM         PROJECT
WHERE     (RECID IN
                          (SELECT     PROJECT
                            FROM          PROJECT_PROFESSIONAL
                            WHERE      (PROAPPROVED = " + durum.ToString() + ") AND (MEMBER = " + DanismanID.ToString() + ")))";
            dc.VeriGetir<DSProject>(ref ds, sql);
            return ds;
        }

        public DataSet Getir_byAdmin_Not_APPROVED()
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT     PROJECT.RECID AS ProjectID, PROJECT.ACRONYM, PROJECT.SECTOR, PROJECT.NAME AS ProjectName, PROJECT.MODIFICATIONDATE, 
                      PROJECT.PPT, MEMBER.RECID AS MemberID, MEMBER.NAME + ' ' + MEMBER.SURNAME AS MemberNameSurname, 
                      PROJECT_PROFESSIONAL.RECID as MasterID
FROM         PROJECT INNER JOIN
                      PROJECT_PROFESSIONAL ON PROJECT.RECID = PROJECT_PROFESSIONAL.PROJECT INNER JOIN
                      MEMBER ON PROJECT_PROFESSIONAL.MEMBER = MEMBER.RECID
WHERE     (PROJECT_PROFESSIONAL.ADMINAPPROVED = 0)";
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DataSet GetirMyInvestments(string investor)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT PROJECT.*,m.RECID as ENTREPRENEUR, m.NAME + ' ' + m.SURNAME AS NAMESURNAME, i.ENTREAPPROVED
                FROM  INVESTOR_PROJECT i
                INNER JOIN PROJECT ON PROJECT.RECID = i.PROJECT 
                INNER JOIN MEMBER m ON PROJECT.CREATEDBY = m.RECID 
                WHERE  i.INVESTOR =  " + investor;
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DataSet MyInvestor(int ProjectID)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = @"SELECT    INVESTOR_PROJECT.RECID, MEMBER.NAME + ' ' + MEMBER.SURNAME AS AdiSoyadi, MEMBER.RECID INV,ENTREAPPROVED
                            FROM         INVESTOR_PROJECT INNER JOIN
                            MEMBER ON INVESTOR_PROJECT.INVESTOR = MEMBER.RECID
                            WHERE     (INVESTOR_PROJECT.PROJECT = " + ProjectID.ToString() + ")";
            dc.VeriGetir(ref ds, sql);
            return ds;
        }
    }
}
