using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.Enums;
using Business.Event;
using Types.TypeDataSets;
using Business.Project;
using System.Data;
using Business;

namespace Web.Entrepreneur
{
    public partial class Default : MasterOfMaster
    {
        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["task"] != null && Request.QueryString["task"] == "activated")
                    Araclar.MesajGoster(this.Page, "activated", Araclar.MesajTipiEnum.Bilgi);

                if (UserSession.UserMemberShipType != MemberShipType.Entrepreneur.GetHashCode())
                {
                    pnlMemberLeft.Visible = false;
                    pnlGuestLeft.Visible = true;
                    pnlMemberMiddle.Visible = false;
                    pnlGuestMiddle.Visible = true;

                    BSPage bs = new BSPage();
                    DSPage ds = new DSPage();
                    ds = bs.Getir_byRECID(MembershipPages.Entrepreneur.GetHashCode());
                    if (ds.PAGE.Count > 0)
                    {
                        if (UserSession.SeciliDil == Dil.English)
                        {
                            exltPage.Text = ds.PAGE[0].BODYENG;
                        }
                        else
                        {
                            exltPage.Text = ds.PAGE[0].BODY;
                        }

                    }

                }
                else
                {
                    pnlMemberLeft.Visible = true;
                    pnlGuestLeft.Visible = false;
                    pnlMemberMiddle.Visible = true;
                    pnlGuestMiddle.Visible = false;
                }


            }
        }


    }
}
