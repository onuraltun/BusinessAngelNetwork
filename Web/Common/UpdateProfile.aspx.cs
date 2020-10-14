using System;
using Web.Library;
using System.Web.UI.WebControls;
using Types.Enums;

namespace Web
{
    public partial class UpdateProfile : MasterOfMaster
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
            Member1.MemberShipTypeProperty = (MemberShipType)UserSession.UserMemberShipType;
            base.OnInit(e);
        }

    }
}
