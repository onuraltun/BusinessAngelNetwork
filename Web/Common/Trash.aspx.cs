using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;

namespace Web.Common
{
    public partial class Trash : MasterOfMaster
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
