using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ASCX
{
    public partial class Aciklama : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
                return txtAciklama.Text;
            }
            set
            {
                txtAciklama.Text = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return txtAciklama.Enabled;
            }
            set
            {
                txtAciklama.Enabled = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}