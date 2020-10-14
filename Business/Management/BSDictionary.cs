using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService;
using Types.TypeDataSets;

namespace Business.Management
{
    public class BSDictionary
    {
        public void Kaydet(DSDictionary ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSDictionary Getir()
        {
            Data dc = new Data();
            DSDictionary ds = new DSDictionary(); 
            string sql = @"Select * from DICTIONARY";
            dc.VeriGetir<DSDictionary>(ref ds, sql);
            return ds;
        }
    }
}
 