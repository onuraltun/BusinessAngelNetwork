using System;
using Web.Library;
using System.Web.UI.WebControls;
using Types.Enums;
using Business;
using Types.TypeDataSets;

namespace Web
{
    public partial class Register : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //sonra isteyebilirler
            //BSPage bs = new BSPage();
            //DSPage ds = new DSPage();
            //ds = bs.Getir_byRECID(551);
            //if (ds.PAGE.Count > 0)
            //{
            //    if (UserSession.SeciliDil == Dil.English)
            //    {
            //        exlblPage.Text = ds.PAGE[0].BODYENG;
            //    }
            //    else
            //    {
            //        exlblPage.Text = ds.PAGE[0].BODY;
            //    }

            //}

            if (UserSession.SeciliDil == Dil.English)
            {
                pnlMemberShipTR.Visible = false;
            }
            else
            {
                pnlMemberShipEng.Visible = false;
            }
        }

        protected void Click(Object sender, EventArgs e)
        {
            Member1.MemberShipTypeProperty = (MemberShipType)Convert.ToInt32(((ImageButton)sender).CommandArgument);
            Member1.Visible = true;
            Member1.Prepare();
            pnlMemberShipTR.Visible = false;
            pnlMemberShipEng.Visible = false;
        }

    }
}
