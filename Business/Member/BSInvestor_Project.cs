using System;
using System.Collections.Generic;
using System.Text;
using DataService;

namespace Types.TypeDataSets
{
    public class BSInvestor_Project
    {
        public void Kaydet(DSInvestor_Project ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSInvestor_Project Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSInvestor_Project ds = new DSInvestor_Project(); string sql = @"Select * from INVESTOR_PROJECT where RECID=" + param;
            dc.VeriGetir<DSInvestor_Project>(ref ds, sql);
            return ds;
        }
        public DSInvestor_Project Getir_byPROJECT(System.Int32 param)
        {
            Data dc = new Data();
            DSInvestor_Project ds = new DSInvestor_Project(); string sql = @"Select * from INVESTOR_PROJECT where PROJECT=" + param;
            dc.VeriGetir<DSInvestor_Project>(ref ds, sql);
            return ds;
        }
        public DSInvestor_Project Getir_byINVESTOR(System.Int32 param)
        {
            Data dc = new Data();
            DSInvestor_Project ds = new DSInvestor_Project(); string sql = @"Select * from INVESTOR_PROJECT where INVESTOR=" + param;
            dc.VeriGetir<DSInvestor_Project>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from INVESTOR_PROJECT where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byPROJECT(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from INVESTOR_PROJECT where PROJECT=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byINVESTOR(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from INVESTOR_PROJECT where INVESTOR=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}