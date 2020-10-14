using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.TypeDataSets;
using System.Data;
using Web.Library;
using Types.Enums;

namespace Web.Supervisor
{
    public partial class ShowPollOptions : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Supervisor; }
        }

        protected DSPoll_Options dsPollOptions
        {
            get
            {
                return (DSPoll_Options)Session["poll_options"];
            }
            set
            {
                Session["poll_options"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataView dv = new DataView(dsPollOptions.POLL_OPTIONS);
                dv.RowFilter = "POLLID=" + Request.QueryString["ID"].ToString();
                Araclar.GridDoldur(dv, exgvSecenekGir);
            }
        }
    }
}
