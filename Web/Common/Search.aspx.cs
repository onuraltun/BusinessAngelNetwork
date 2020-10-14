using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Management;
using Types.TypeDataSets;
using System.IO;
using System.Drawing;
using Business.Event;
using System.Data;
using Types.Enums;
using Business;

namespace Web.Common
{
    public partial class Search : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                Listele();
        }

        protected void Listele()
        {
            if (Request.Form["ctl00$txtSearch"] == null)
                return;

            BSPage bs = new BSPage();
            DSPage ds = new DSPage();

            ds = bs.Getir_Search(Request.Form["ctl00$txtSearch"].ToString());

            Araclar.GridDoldur(ds, gvListe);

            if (UserSession.SeciliDil == Dil.Turkish)
            {
                gvListe.Columns[1].Visible = false;
            }
            else
            {
                gvListe.Columns[0].Visible = false;
            }
        }

    }
}
