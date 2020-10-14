using System;
using System.Collections.Generic;
using System.Text;
using DataService;
using System.Data;

namespace Types.TypeDataSets
{
    public class BSProfessional_Feedback
    {
        public void Kaydet(DSProfessional_Feedback ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DataSet Getir_byPROFESSIONALWithName(System.Int32 param)
        {
            Data dc = new Data();
            DataSet ds = new DataSet(); string sql = @"Select f.*,m.NAME + ' ' + m.SURNAME NAMESURNAME from PROFFESIONAL_FEEDBACK f, MEMBER m where m.RECID = f.CREATEDBY and f.PROFESSIONAL=" + param;
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DSProfessional_Feedback Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessional_Feedback ds = new DSProfessional_Feedback(); string sql = @"Select * from PROFFESIONAL_FEEDBACK where RECID=" + param;
            dc.VeriGetir<DSProfessional_Feedback>(ref ds, sql);
            return ds;
        }
        public DSProfessional_Feedback Getir_byPROFESSIONAL(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessional_Feedback ds = new DSProfessional_Feedback(); string sql = @"Select * from PROFFESIONAL_FEEDBACK where PROFESSIONAL=" + param;
            dc.VeriGetir<DSProfessional_Feedback>(ref ds, sql);
            return ds;
        }
        public DSProfessional_Feedback Getir_byPOINT(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessional_Feedback ds = new DSProfessional_Feedback(); string sql = @"Select * from PROFFESIONAL_FEEDBACK where POINT=" + param;
            dc.VeriGetir<DSProfessional_Feedback>(ref ds, sql);
            return ds;
        }
        public DSProfessional_Feedback Getir_byFEEDBACK(System.String param)
        {
            Data dc = new Data();
            DSProfessional_Feedback ds = new DSProfessional_Feedback(); string sql = @"Select * from PROFFESIONAL_FEEDBACK where FEEDBACK='" + param + "'";
            dc.VeriGetir<DSProfessional_Feedback>(ref ds, sql);
            return ds;
        }
        public DSProfessional_Feedback Getir_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data();
            DSProfessional_Feedback ds = new DSProfessional_Feedback(); string sql = @"Select * from PROFFESIONAL_FEEDBACK where CREATEDBY=" + param;
            dc.VeriGetir<DSProfessional_Feedback>(ref ds, sql);
            return ds;
        }
        public DSProfessional_Feedback Getir_byCREATIONDATE(System.DateTime param)
        {
            Data dc = new Data();
            DSProfessional_Feedback ds = new DSProfessional_Feedback(); string sql = @"Select * from PROFFESIONAL_FEEDBACK where CREATIONDATE=" + param;
            dc.VeriGetir<DSProfessional_Feedback>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFFESIONAL_FEEDBACK where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byPROFESSIONAL(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFFESIONAL_FEEDBACK where PROFESSIONAL=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byPOINT(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFFESIONAL_FEEDBACK where POINT=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byFEEDBACK(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFFESIONAL_FEEDBACK where FEEDBACK=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFFESIONAL_FEEDBACK where CREATEDBY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATIONDATE(System.DateTime param)
        {
            Data dc = new Data(); string sql = @"Delete from PROFFESIONAL_FEEDBACK where CREATIONDATE=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}