using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;
using System.Data;
using Types.Enums;

namespace Business.Event
{
    public class BSEvent
    {
        public void Kaydet(DSEvent ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSEvent Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSEvent ds = new DSEvent(); string sql = @"Select * from EVENT where RECID=" + param;
            dc.VeriGetir<DSEvent>(ref ds, sql);
            return ds;
        }

        public DSEvent EventleriGetir()
        {
            Data dc = new Data();
            DSEvent ds = new DSEvent(); string sql = @"Select * from EVENT where EVENTTYPE in (" + Enums.EventIds + ")";
            dc.VeriGetir<DSEvent>(ref ds, sql);
            return ds;
        }

        public DSEvent EgitimleriGetir()
        {
            Data dc = new Data();
            DSEvent ds = new DSEvent(); string sql = @"Select * from EVENT where EVENTTYPE in (" + Enums.TrainingIds + ")";
            dc.VeriGetir<DSEvent>(ref ds, sql);
            return ds;
        }

        public DSEvent Getir_byEVENTTYPE(System.Int32 param)
        {
            Data dc = new Data();
            DSEvent ds = new DSEvent();
            string sql = @"Select * from EVENT where 1=1 ";

            if (param == EventTypes.Training.GetHashCode())
                sql = string.Concat(sql, " and EVENTTYPE in (", Enums.TrainingIds, ")");
            else
                sql = string.Concat(sql, " and EVENTTYPE in (", Enums.EventIds, ")");

            dc.VeriGetir<DSEvent>(ref ds, sql);
            return ds;
        }

        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from EVENT where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }

        public DSEvent EventleriGetir(DateTime basTarih, DateTime BitTarih, EventTypes? eventType)
        {
            Data oData = new Data();
            DSEvent ds = new DSEvent();
            string sql = @"Select * from " + ds.EVENT.TableName + " where Date Between  CONVERT(DATETIME, '" + basTarih.ToShortDateString() + " 00:00:00', 103) and  CONVERT(DATETIME, '" + BitTarih.ToShortDateString() + " 23:59:59', 103)";

            if (eventType != null)
                if (eventType == EventTypes.Training)
                    sql = string.Concat(sql, " and EVENTTYPE in (", Enums.TrainingIds, ")");
                else
                    sql = string.Concat(sql, " and EVENTTYPE in (", Enums.EventIds, ")");

            oData.VeriGetir<DSEvent>(ref ds, sql);
            return ds;
        }

        public DSEvent EventlerinTumunuTopladaGetir(EventTypes? eventType)
        {
            Data oData = new Data();
            DSEvent ds = new DSEvent();
            string sql = @"Select * from " + ds.EVENT.TableName + " where 1 = 1 ";

            if (eventType != null)
                if (eventType == EventTypes.Training)
                    sql = string.Concat(sql, " and EVENTTYPE in (", Enums.TrainingIds, ")");
                else
                    sql = string.Concat(sql, " and EVENTTYPE in (", Enums.EventIds, ")");

            oData.VeriGetir<DSEvent>(ref ds, sql);
            return ds;
        }

        public DataTable BenimkileriGetir(int userId, DateTime? date, int? recId, EventTypes? eventType)
        {
            Data oData = new Data();
            DataTable ds = new DataTable();
            string sql = string.Format(@"Select e.*,a.RECID as AttendedRecId, a.APPROVED from event as e 
left outer join (select event,RECID,APPROVED from attendedevent where member={0}) as a on a.event=e.RECID where 1=1 ", userId);

            if (date != null)
                sql = string.Concat(sql, " and Date Between  CONVERT(DATETIME, '",
                    date.Value.ToShortDateString(), " 00:00:00', 103) and  CONVERT(DATETIME, '",
                    date.Value.ToShortDateString(), " 23:59:59', 103)");

            if (recId != null)
                sql = string.Concat(sql, " and e.RECID=", recId);

            if (eventType == EventTypes.Event)
                sql = string.Concat(sql, " and e.EVENTTYPE in (", Enums.EventIds, ")");
            else if (eventType == EventTypes.Training)
                sql = string.Concat(sql, " and e.EVENTTYPE in (", Enums.TrainingIds, ")");
            else if (eventType != null)
                sql = string.Concat(sql, " and e.EVENTTYPE=", eventType.GetHashCode());

            oData.VeriGetir(ref ds, sql);
            return ds;
        }
    }
}
