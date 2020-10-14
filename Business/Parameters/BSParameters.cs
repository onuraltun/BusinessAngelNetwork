using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;

namespace Business.Parameters
{
    public class BSParameters
    {
        public void Kaydet(DSBusinessModelType ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSBusinessModelType BusinessModelTypeGetir()
        {
            Data dc = new Data();
            DSBusinessModelType ds = new DSBusinessModelType();
            string sql = @"Select * from " + ds.BUSINESSMODELTYPE.TableName;
            dc.VeriGetir<DSBusinessModelType>(ref ds, sql);
            return ds;
        }

        public DSSektor SektorGetir()
        {
            Data dc = new Data();
            DSSektor ds = new DSSektor();
            string sql = @"Select * from " + ds.SECTOR.TableName;
            dc.VeriGetir<DSSektor>(ref ds, sql);
            return ds;
        }

        public DSEventType EventTypeGetir()
        {
            Data dc = new Data();
            DSEventType ds = new DSEventType();
            string sql = @"Select * from " + ds.EVENTTYPE.TableName;
            dc.VeriGetir<DSEventType>(ref ds, sql);
            return ds;
        }

        public DSPageType PageTypeGetir()
        {
            Data dc = new Data();
            DSPageType ds = new DSPageType();
            string sql = @"Select * from " + ds.PAGETYPE.TableName;
            dc.VeriGetir<DSPageType>(ref ds, sql);
            return ds;
        }


        public DSMemberShipType KullaniciTipleriniGetir()
        {
            Data dc = new Data();
            DSMemberShipType ds = new DSMemberShipType();
            string sql = @"Select * from " + ds.MEMBERSHIPTYPE.TableName;
            dc.VeriGetir<DSMemberShipType>(ref ds, sql);
            return ds;
        }

        public DSTitle TitleGetir()
        {
            Data dc = new Data();
            DSTitle ds = new DSTitle();
            string sql = @"Select * from " + ds.TITLE.TableName;
            dc.VeriGetir<DSTitle>(ref ds, sql);
            return ds;
        }

        public DSInvestorType InvestorTypeGetir()
        {
            Data dc = new Data();
            DSInvestorType ds = new DSInvestorType();
            string sql = @"Select * from " + ds.INVESTORTYPE.TableName;
            dc.VeriGetir<DSInvestorType>(ref ds, sql);
            return ds;
        }
    }
}
