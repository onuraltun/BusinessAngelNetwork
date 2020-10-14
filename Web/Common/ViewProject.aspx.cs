using System;
using Web.Library;
using System.Web.UI.WebControls;
using Types.Enums;

namespace Web
{
    public partial class ViewProject : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.NotGuest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            ViewProject1.ProjectID = Convert.ToInt32(Request.QueryString["p"]);
            ViewProject1.Goster();
            base.OnInit(e);
        }
    }
}
