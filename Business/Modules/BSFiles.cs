using System;
using System.Collections.Generic;
using System.Text;
using DataService;
using Types.TypeDataSets;

namespace Business
{
    public class BSFiles
    {
        public void Kaydet(DSFiles ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSFiles Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSFiles ds = new DSFiles(); string sql = @"Select * from FILES where RECID=" + param;
            dc.VeriGetir<DSFiles>(ref ds, sql);
            return ds;
        }

        public DSFiles Getir_MukkemmelBirSorguDaha(System.Int32 createdBy, System.String tableName, System.Int32 fileType)
        {
            Data dc = new Data();
            DSFiles ds = new DSFiles();
            string sql = string.Format("Select * from FILES where RELATIONID={0} and TABLENAME=\'{1}\' and FILETYPE={2}",
                 createdBy, tableName, fileType);
            dc.VeriGetir<DSFiles>(ref ds, sql);
            return ds;
        }

    }
}