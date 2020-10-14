using System;
using System.Collections.Generic;
using System.Text;
using DataService;

namespace Types.TypeDataSets
{
    public class BSCV_Language
    {
        public void Kaydet(DSCV_Language ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSCV_Language Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where RECID=" + param;
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_byMEMBER(System.Int32 param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where MEMBER=" + param;
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_byLANGUAGE(System.String param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where LANGUAGE='" + param + "'";
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_byListening(System.String param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where Listening='" + param + "'";
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_byReading(System.String param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where Reading='" + param + "'";
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_bySpokenInteraction(System.String param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where SpokenInteraction='" + param + "'";
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_bySpokenProduction(System.String param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where SpokenProduction='" + param + "'";
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public DSCV_Language Getir_byWriting(System.String param)
        {
            Data dc = new Data();
            DSCV_Language ds = new DSCV_Language(); string sql = @"Select * from CV_LANGUAGE where Writing='" + param + "'";
            dc.VeriGetir<DSCV_Language>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMEMBER(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where MEMBER=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byLANGUAGE(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where LANGUAGE=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byListening(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where Listening=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byReading(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where Reading=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_bySpokenInteraction(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where SpokenInteraction=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_bySpokenProduction(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where SpokenProduction=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byWriting(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV_LANGUAGE where Writing=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}