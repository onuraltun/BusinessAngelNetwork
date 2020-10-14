using System;
using System.Collections.Generic;
using System.Text;
using DataService;
using Types.TypeDataSets;

namespace Business
{
    public class BSMaillist
    {
        public void Kaydet(DSMaillist ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSMaillist Getir_AmaHicBiriEksikKalmasinHa()
        {
            Data dc = new Data();
            DSMaillist ds = new DSMaillist(); string sql = @"Select * from MAILLIST";
            dc.VeriGetir<DSMaillist>(ref ds, sql);
            return ds;
        }

        public DSMaillist Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSMaillist ds = new DSMaillist(); string sql = @"Select * from MAILLIST where RECID=" + param;
            dc.VeriGetir<DSMaillist>(ref ds, sql);
            return ds;
        }
        public DSMaillist Getir_byNAME(System.String param)
        {
            Data dc = new Data();
            DSMaillist ds = new DSMaillist(); string sql = @"Select * from MAILLIST where NAME='" + param + "'";
            dc.VeriGetir<DSMaillist>(ref ds, sql);
            return ds;
        }
        public DSMaillist Getir_byEMAIL(System.String param)
        {
            Data dc = new Data();
            DSMaillist ds = new DSMaillist(); string sql = @"Select * from MAILLIST where EMAIL='" + param + "'";
            dc.VeriGetir<DSMaillist>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from MAILLIST where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byNAME(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from MAILLIST where NAME=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byEMAIL(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from MAILLIST where EMAIL=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}