using System;
using System.Collections.Generic;
using System.Text;
using DataService;
using Types.TypeDataSets;
using System.Data;

namespace Business.Event
{
    public class BSAttendedEvent
    {
        public void Kaydet(DSAttendedEvent ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DataTable Getir_Katilanlar(System.Int32 param)
        {
            Data dc = new Data();
            DataTable ds = new DataTable(); string sql = @"Select * from ATTENDEDEVENT e,MEMBER m where e.MEMBER = m.RECID and EVENT=" + param;
            dc.VeriGetir(ref ds, sql);
            return ds;
        }

        public DSAttendedEvent Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSAttendedEvent ds = new DSAttendedEvent(); string sql = @"Select * from ATTENDEDEVENT where RECID=" + param;
            dc.VeriGetir<DSAttendedEvent>(ref ds, sql);
            return ds;
        }
        public DSAttendedEvent Getir_byMEMBER(System.Int32 param)
        {
            Data dc = new Data();
            DSAttendedEvent ds = new DSAttendedEvent(); string sql = @"Select * from ATTENDEDEVENT where MEMBER=" + param;
            dc.VeriGetir<DSAttendedEvent>(ref ds, sql);
            return ds;
        }
        public DSAttendedEvent Getir_byEVENT(System.Int32 param)
        {
            Data dc = new Data();
            DSAttendedEvent ds = new DSAttendedEvent(); string sql = @"Select * from ATTENDEDEVENT where EVENT=" + param;
            dc.VeriGetir<DSAttendedEvent>(ref ds, sql);
            return ds;
        }
        public DSAttendedEvent Getir_byATTENDDATE(System.DateTime param)
        {
            Data dc = new Data();
            DSAttendedEvent ds = new DSAttendedEvent(); string sql = @"Select * from ATTENDEDEVENT where ATTENDDATE=" + param;
            dc.VeriGetir<DSAttendedEvent>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from ATTENDEDEVENT where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMEMBER(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from ATTENDEDEVENT where MEMBER=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byEVENT(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from ATTENDEDEVENT where EVENT=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byATTENDDATE(System.DateTime param)
        {
            Data dc = new Data(); string sql = @"Delete from ATTENDEDEVENT where ATTENDDATE=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}