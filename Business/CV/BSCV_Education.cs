using System;
using System.Collections.Generic;
using System.Text;
using DataService;

namespace Types.TypeDataSets
{
    public class BSCV_Education
    {
        public void Kaydet(DSCV_Education ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSCV_Education Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where RECID=" + param;
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byMEMBER(System.Int32 param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where MEMBER=" + param;
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byDates(System.String param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where Dates='" + param + "'";
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byTitleOfQualification(System.String param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where TitleOfQualification='" + param + "'";
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byMainActivities(System.String param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where MainActivities='" + param + "'";
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byPrincipalSubjects(System.String param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where PrincipalSubjects='" + param + "'";
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byNameAndTypeOfOrganisation(System.String param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where NameAndTypeOfOrganisation='" + param + "'";
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public DSCV_Education Getir_byLevelInNational(System.String param)
        {
            Data dc = new Data();
            DSCV_Education ds = new DSCV_Education(); string sql = @"Select * from CV_EDUCATION where LevelInNational='" + param + "'";
            dc.VeriGetir<DSCV_Education>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMEMBER(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where MEMBER=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byDates(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where Dates=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byTitleOfQualification(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where TitleOfQualification=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMainActivities(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where MainActivities=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byPrincipalSubjects(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where PrincipalSubjects=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byNameAndTypeOfOrganisation(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where NameAndTypeOfOrganisation=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byLevelInNational(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_EDUCATION where LevelInNational=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}