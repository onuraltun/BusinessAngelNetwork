using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.TypeDataSets;
using Business.Event;
using System.Configuration;
using Types.Enums;
using Web.Library;

namespace Web.ASCX
{
    public partial class Events : System.Web.UI.UserControl
    {
        protected DSEvent dsEvents
        {
            get
            {
                return (DSEvent)Session["Events"];
            }
            set
            {
                Session["Events"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BSEvent bs = new BSEvent();
                DSEvent ds = new DSEvent();
                //DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                //DateTime date2 = date.AddMonths(1);
                ds = bs.EventlerinTumunuTopladaGetir(EventTypes.Event);
                this.dsEvents = ds;
            }
        }

        protected void clAktiviteler_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Cell.Style[HtmlTextWriterStyle.BackgroundImage] = "/Images/Template/Day.png";
            if (!e.Day.IsOtherMonth)
            {
                foreach (DSEvent.EVENTRow dr in dsEvents.EVENT.Rows)
                {

                    if (dr.DATE.ToShortDateString() == e.Day.Date.ToShortDateString())
                    {
                        e.Cell.CssClass = "tip";
                        string toolTip = "";
                        if (UserSession.SeciliDil == Dil.English)
                            toolTip = dr.NAMEENG + "<br />" + dr.LOCATION + "<br />" + dr.DESCRIPTIONENG;
                        else
                            toolTip = dr.NAME + "<br />" + dr.LOCATION + "<br />" + dr.DESCRIPTION;
                        if (toolTip.Length > 250)
                            toolTip = toolTip.Substring(0, 250);

                        e.Cell.ToolTip = toolTip;
                        e.Cell.ForeColor = System.Drawing.Color.Green;
                        e.Cell.Style["Cursor"] = "hand";
                        e.Cell.Font.Size = FontUnit.Small;
                        return;
                    }
                }
                e.Day.IsSelectable = false;
            }
            else
                e.Cell.Text = "";


        }

        protected void clAktiviteler_SelectionChanged(object sender, EventArgs e)
        {
            Response.Redirect(string.Format(ConfigurationManager.AppSettings["RootDirectory"].ToString() + "Common/AttendedEvent.aspx?e={0}", clAktiviteler.SelectedDate.Ticks));
        }
    }
}