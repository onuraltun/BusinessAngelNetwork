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
using Business;
using Types.Enums;

namespace Web
{
    public partial class _Default : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (UserSession.SeciliDil == Dil.Turkish)
            {
                imgContact.Src = "/images/template/2t.png";
                imgSurvey.Src = "./images/template/4t.png";
            }
            else
            {
                imgContact.Src = "/images/template/2e.png";
                imgSurvey.Src = "./images/template/4e.png";
            }
            base.OnLoad(e);
        }
    }
}
