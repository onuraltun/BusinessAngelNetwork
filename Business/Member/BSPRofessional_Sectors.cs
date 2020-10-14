using System;
using System.Collections.Generic;
using System.Text;
using DataService;

namespace Types.TypeDataSets
{
    public class BSProfessional_Sectors
    {
        public void Kaydet(DSProfessionalSectors ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSProfessionalSectors Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessionalSectors ds = new DSProfessionalSectors(); string sql = @"Select * from PROFESSIONAL_SECTORS where RECID=" + param;
            dc.VeriGetir<DSProfessionalSectors>(ref ds, sql);
            return ds;
        }
        public DSProfessionalSectors Getir_byMEMBERID(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessionalSectors ds = new DSProfessionalSectors(); string sql = @"Select * from PROFESSIONAL_SECTORS where MEMBERID=" + param;
            dc.VeriGetir<DSProfessionalSectors>(ref ds, sql);
            return ds;
        }
        public DSProfessionalSectors Getir_bySECTORID(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessionalSectors ds = new DSProfessionalSectors(); string sql = @"Select * from PROFESSIONAL_SECTORS where SECTORID=" + param;
            dc.VeriGetir<DSProfessionalSectors>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFESSIONAL_SECTORS where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMEMBERID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFESSIONAL_SECTORS where MEMBERID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_bySECTORID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFESSIONAL_SECTORS where SECTORID=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}