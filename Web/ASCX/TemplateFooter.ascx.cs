using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Types.TypeDataSets;
using Types.Enums;
using Web.Library;

namespace Web.ASCX
{
    public partial class TemplateFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                BSPage bs = new BSPage();
                DSPage ds = new DSPage();
                ds = bs.Getir_byRECID(549);
                if (ds.PAGE.Count > 0)
                {
                    if (UserSession.SeciliDil == Dil.English)
                    {
                        exlblPage.Text = ds.PAGE[0].BODYENG;
                    }
                    else
                    {
                        exlblPage.Text = ds.PAGE[0].BODY;
                    }
                    
                }

        }
    }
}