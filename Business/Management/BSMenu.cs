using System;
using System.Collections.Generic;
using System.Text;
using DataService;
using Types.TypeDataSets;
using System.Data;
using Types.Enums;

namespace Business.Management
{
    public class BSMenu
    {

        public DataSet TumunuGetir(Dil? dil)
        {
            Data dc = new Data();
            DataSet ds = new DataSet();
            string sql = "";
            if (dil.Value == Dil.Turkish)
                sql = @"Select [MenuID] ,[TextTR] as Text,[Description],[ParentID],[Link],[OrderValue] from Menu order by OrderValue";
            else if (dil.Value == Dil.English)
                sql = @"Select [MenuID],[TextEng] as Text,[Description],[ParentID],[Link],[OrderValue] from Menu order by OrderValue";
            else
                sql = @"Select [MenuID],[TextTR],[TextEng],[Description],[ParentID],[Link],[OrderValue] from Menu order by OrderValue";
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public void Kaydet(DSMenu ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSMenu Getir()
        {
            Data dc = new Data();
            DSMenu ds = new DSMenu();
            string sql = @"Select * from Menu order by ParentId, OrderValue";
            dc.VeriGetir<DSMenu>(ref ds, sql);
            return ds;
        }
    }

}