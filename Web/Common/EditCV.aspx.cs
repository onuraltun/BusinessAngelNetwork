using System;
using Web.Library;
using System.Web.UI.WebControls;
using Types.Enums;

namespace Web
{
    public partial class EditCV : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.NotGuest; }
        }

        protected override void OnInit(EventArgs e)
        {
            CV1.MemberID = UserSession.KullaniciID;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


    }
}
