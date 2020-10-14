using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace HTWeb.ASCX
{
    public partial class Takvim : System.Web.UI.UserControl
    {
        public DateTime Tarih
        {
            get
            {
                if (txtTarih.Text != "")
                    return Convert.ToDateTime(txtTarih.Text);
                else
                    return new DateTime();

            }
            set
            {
                txtTarih.Text = value.ToShortDateString();
            }
        }

        public void Clear()
        {
            txtTarih.Text = "";
        }

        public string Text
        {
            get
            {
                return txtTarih.Text;
            }
            set
            {
                txtTarih.Text = value;
            }
        }

        public TextBox txtTarihKontrolu
        {
            get
            {
                return txtTarih;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }
    }
}