using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataService;

namespace Business.Log
{
    public class BSLog
    {
        public DataSet LogGetir(string whereCondition)
        {
            Data db = new Data();
            DataSet ds = new DataSet();
            string ssq = @"SELECT     [LOG].DETAIL, [LOG].TABLENAME, [LOG].OPDATE, [LOG].IPADDRESS, [LOG].OPERATIONTYPE, 
                           MEMBER.NAME + ' ' + MEMBER.SURNAME AS USERNAMEUSRNAME
                           FROM         [LOG] INNER JOIN
                           MEMBER ON [LOG].MEMBERID = MEMBER.RECID INNER JOIN
                           MEMBERSHIPTYPE ON MEMBER.MEMBERSHIPTYPE = MEMBERSHIPTYPE.RECID
                           Where " + whereCondition;
            db.VeriGetir(ref ds, ssq);
            return ds;
        }
    }
}
