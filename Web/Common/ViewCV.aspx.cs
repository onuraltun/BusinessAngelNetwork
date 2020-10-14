using System;
using Web.Library;
using System.Web.UI.WebControls;
using Types.Enums;

namespace Web
{
    public partial class ViewCV : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.NotGuest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


    }
}
