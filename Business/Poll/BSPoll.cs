using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;
using Types.Enums;

namespace Business.Poll
{
    public class BSPoll
    {
        public DSPoll AnketleriGetir()
        {
            Data oData = new Data();
            DSPoll ds = new DSPoll();
            oData.VeriGetir<DSPoll>(ref ds, "select * from " + ds.POLL.TableName);
            return ds;
        }

        public DSPoll_Options Anket_Secenekleri_Getir()
        {
            Data oData = new Data();
            DSPoll_Options ds = new DSPoll_Options();
            oData.VeriGetir<DSPoll_Options>(ref ds, "select * from POLL_OPTIONS");
            return ds;
        }

        public void AnketKayit(DSPoll dsPoll, DSPoll_Options dsOptions)
        {
            Data odata = new Data(true);

            try
            {
                odata.TopluVeriIslemeID(dsPoll);
                foreach (DSPoll_Options.POLL_OPTIONSRow dr in dsOptions.POLL_OPTIONS.Rows)
                    dr.POLLID = dsPoll.POLL[0].RECID;

                odata.TopluVeriIsleme(dsOptions);
                odata.CommitTransaction();
            }
            catch (Exception ex)
            {
                odata.RollbackTransaction();
                throw ex;
            }
        }

        public void AnketSil(DSPoll dsPoll, DSPoll_Options dsOptions)
        {
            Data odata = new Data(true);

            try
            {
                odata.TopluVeriIsleme(dsPoll);
                odata.TopluVeriIsleme(dsOptions);
                odata.CommitTransaction();
            }
            catch (Exception ex)
            {
                odata.RollbackTransaction();
                throw ex;
            }
        }

        public DSPoll AnketleriGetir(int MemberShipTypeID)
        {
            Data oData = new Data();
            DSPoll ds = new DSPoll();
            string sql = "select * from POLL where (CONVERT(DATETIME, '" + DateTime.Now.ToShortDateString() + " 00:00:00', 103) BETWEEN STARTDATE AND ENDDATE) AND ";

            if (MemberShipType.Entrepreneur.GetHashCode() == MemberShipTypeID)
                sql += " ISFORE=1";

            if (MemberShipType.Guest.GetHashCode() == MemberShipTypeID)
                sql += " ISFORGUEST=1";

            if (MemberShipType.Investor.GetHashCode() == MemberShipTypeID)
                sql += " ISFORINVESTOR=1";

            if (MemberShipType.Professional.GetHashCode() == MemberShipTypeID)
                sql += " ISFORPROFESSIONAL=1";

            if (MemberShipType.Admin.GetHashCode() == MemberShipTypeID || MemberShipType.Supervisor.GetHashCode() == MemberShipTypeID)
                sql += " 1=0";

            oData.VeriGetir<DSPoll>(ref ds, sql);
            return ds;
        }

        public DSPoll_Options Anket_Secenekleri_Getir(int PollID)
        {
            Data oData = new Data();
            DSPoll_Options ds = new DSPoll_Options();
            oData.VeriGetir<DSPoll_Options>(ref ds, "select * from POLL_OPTIONS where POLLID=" + PollID.ToString());
            return ds;
        }

        public bool OylayabilirMi(int MemberID, int PollID)
        {
            Data oData = new Data();
            DSPoll_Answers ds = new DSPoll_Answers();
            string sql = @"SELECT * FROM POLL_ANSWERS WHERE (POLLID = " + PollID.ToString() + ") AND (USERID = " + MemberID.ToString() + ")";
            oData.VeriGetir<DSPoll_Answers>(ref ds, sql);
            if (ds.POLL_ANSWERS.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public void AnketCevapKayit(DSPoll_Answers dsAnswer)
        {
            Data odata = new Data();
            odata.TopluVeriIsleme(dsAnswer);
        }

        public DSPoll_Answers Anket_Cevaplari_Getir(int PollID)
        {
            Data oData = new Data();
            DSPoll_Answers ds = new DSPoll_Answers();
            oData.VeriGetir<DSPoll_Answers>(ref ds, "select * from POLL_ANSWERS where POLLID=" + PollID.ToString());
            return ds;
        }
    }
}
