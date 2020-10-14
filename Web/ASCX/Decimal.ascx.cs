using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ASCX
{
    public partial class Decimal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Text
        {
            get
            {
                return txtDecimal.Text;
            }
            set
            {
                txtDecimal.Text = value;
            }
        }
    }
}