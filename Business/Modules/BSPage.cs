using System;
using System.Collections.Generic;
using System.Text;
using DataService;
using Types.TypeDataSets;

namespace Business
{
    public class BSPage
    {
        public void Kaydet(DSPage ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSPage Getir_Search(string search)
        {
            Data dc = new Data();

            StringBuilder sb = new StringBuilder();
            string[] str = search.Split(' ');

            foreach (string s in str)
            {
                if (sb.Length != 0)
                    sb.Append(" and ");
                else
                    sb.Append(" WHERE ");
                sb.Append(" (TITLE like '%" + s + "%'");
                sb.Append(" OR TITLEENG like '%" + s + "%'");
                sb.Append(" OR BODY like '%" + s + "%'");
                sb.Append(" OR BODYENG like '%" + s + "%' )");
            }

            string sql = @"Select * from PAGE " + sb.ToString();
            DSPage ds = new DSPage();
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }

        public DSPage Getir_Tumu()
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE ";
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }

        public DSPage Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE where RECID=" + param;
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }
        public DSPage Getir_byPAGETYPE(System.Int32 param)
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE where PAGETYPE=" + param + " ORDER BY RECID DESC";
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }
        public DSPage Getir_byTITLE(System.String param)
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE where TITLE='" + param + "'";
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }
        public DSPage Getir_byBODY(System.String param)
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE where BODY='" + param + "'";
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }
        public DSPage Getir_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE where CREATEDBY=" + param;
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }
        public DSPage Getir_byCREATIONDATE(System.DateTime param)
        {
            Data dc = new Data();
            DSPage ds = new DSPage(); string sql = @"Select * from PAGE where CREATIONDATE=" + param;
            dc.VeriGetir<DSPage>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PAGE where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byPAGETYPE(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PAGE where PAGETYPE=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byTITLE(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from PAGE where TITLE=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byBODY(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from PAGE where BODY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from PAGE where CREATEDBY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATIONDATE(System.DateTime param)
        {
            Data dc = new Data(); string sql = @"Delete from PAGE where CREATIONDATE=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}