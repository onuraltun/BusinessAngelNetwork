using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Project;
using Types.TypeDataSets;
using Web.Library;
using System.Configuration;

namespace Web.ASCX
{
    public partial class ViewProject : System.Web.UI.UserControl
    {
        public int ProjectID
        {
            get
            {
                return Convert.ToInt32(ViewState["__ProjectID"]);
            }
            set
            {
                ViewState["__ProjectID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Goster()
        {
            BSProject bs = new BSProject();
            DSProject ds = new DSProject();
            ds = bs.Getir_byRECID(this.ProjectID);
            DSProject.PROJECTRow dr = ds.PROJECT.FindByRECID(this.ProjectID);
            extxtAcronym.Text = dr.ACRONYM;
            exltBusinessModelType.Text = CacheHelper.BusinessModelTypes().BUSINESSMODELTYPE.FindByRECID(dr.BUSINESSMODELTYPE).DESCRIPTION;
            extxtBusinessSummary.Text = dr.BUSINESSSUMMARY;
            extxtComptetitiveAdvange.Text = dr.COMPETITIVEADVANGE;
            extxtComptetitors.Text = dr.COMPETITORS;
            extxtCustomerProblem.Text = dr.CUSTOMERPROBLEM;
            extxtCustomers.Text = dr.CUSTOMERS;
            exltInvestmenAmount.Text = dr.INVESTMENTAMOUNT;
            extxtManagement.Text = dr.MANAGEMENT;
            extxtName.Text = dr.NAME;
            extxtProjectOneLinePitch.Text = dr.ONELINEPITCH;
            extxtProductorServices.Text = dr.PRODUCTORSERVICES;
            exltSektor.Text = CacheHelper.SektorGetir().SECTOR.FindByRECID(dr.SECTOR).DESCRIPTION;
            extxtStrategy.Text = dr.STRATEGY;
            extxtTargetMarket.Text = dr.TARGETMARKET;
            Session["__Projelerim"] = ds;
            exltLogo.Text = "<img src=\"" + ConfigurationManager.AppSettings["RootDirectory"] + "common/ShowPicture.aspx?id=" + this.ProjectID.ToString() + "\"/>";
        }
    }
}