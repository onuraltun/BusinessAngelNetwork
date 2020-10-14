using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Types.TypeDataSets;
using Web.Library;
using Types.Enums;

namespace Web.ASCX
{
    public partial class Maillist : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.SeciliDil == Dil.Turkish)
            {
                ibMaillist.ImageUrl = "/images/template/1t.png";
            }
            else
            {
                ibMaillist.ImageUrl = "/images/template/1e.png";
            }
        }
        protected void ibMaillist_Click(object sender, ImageClickEventArgs e)
        {
            pnlMaillist.Visible = true;
            ibMaillist.Visible = false;
        }

        protected void btnMaillist_Click(object sender, EventArgs e)
        {
            BSMaillist bs = new BSMaillist();
            DSMaillist ds = new DSMaillist();
            DSMaillist.MAILLISTRow dr = ds.MAILLIST.NewMAILLISTRow();
            dr.EMAIL = txtEmail.Text;
            dr.NAME = txtNameSurname.Text;
            ds.MAILLIST.AddMAILLISTRow(dr);
            bs.Kaydet(ds);

            pnlMaillist.Visible = false;
            lblMaillistInfo.Visible = true;
        }
    }
}