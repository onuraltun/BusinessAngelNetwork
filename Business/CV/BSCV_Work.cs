using System;
using System.Collections.Generic;
using System.Text;
using DataService;

namespace Types.TypeDataSets
{
    public class BSCV_Work
    {
        public void Kaydet(DSCV_Work ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSCV_Work Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where RECID=" + param;
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public DSCV_Work Getir_byMEMBER(System.Int32 param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where MEMBER=" + param;
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public DSCV_Work Getir_byDates(System.String param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where Dates='" + param + "'";
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public DSCV_Work Getir_byOccupation(System.String param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where Occupation='" + param + "'";
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public DSCV_Work Getir_byMainActivities(System.String param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where MainActivities='" + param + "'";
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public DSCV_Work Getir_byNameAndAddress(System.String param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where NameAndAddress='" + param + "'";
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public DSCV_Work Getir_byTypeOfBusiness(System.String param)
        {
            Data dc = new Data();
            DSCV_Work ds = new DSCV_Work(); string sql = @"Select * from CV_WORK where TypeOfBusiness='" + param + "'";
            dc.VeriGetir<DSCV_Work>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMEMBER(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where MEMBER=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byDates(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where Dates=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byOccupation(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where Occupation=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMainActivities(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where MainActivities=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byNameAndAddress(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where NameAndAddress=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byTypeOfBusiness(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_WORK where TypeOfBusiness=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}