using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Member;
using Types.TypeDataSets;
using Types.Enums;
using System.Configuration;
using Business.Project;
using System.Data;

namespace Web.Common
{
    public partial class MyAdvisor : MasterOfMaster
    {
        protected int MasterID
        {
            get
            {
                return Convert.ToInt32(ViewState["__MasterID"]);
            }
            set
            {
                ViewState["__MasterID"] = value;
            }
        }

        protected override Types.Enums.MemberShipType PageMemberShip
        {
            get { return Types.Enums.MemberShipType.Entrepreneur; }
        }

        protected DataSet dsUyeler
        {
            get
            {
                return (DataSet)Session["__Uyeler"];
            }
            set
            {
                Session["__Uyeler"] = value;
            }
        }

        protected DSProject dsProjeler
        {
            get
            {
                return (DSProject)Session["__Projeler"];
            }
            set
            {
                Session["__Projeler"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSProject bs = new BSProject();
                DSProject ds = new DSProject();
                ds = bs.Getir_byCREATEDBY(UserSession.KullaniciID);

                Araclar.GridDoldur(ds, gvProject);
                dsProjeler = ds;
            }
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ibViewMember = (ImageButton)e.Row.FindControl("ibViewMember");
                ibViewMember.ToolTip = " <iframe height=\"240\" width=\"250\" src=\"" +
                    ConfigurationManager.AppSettings["RootDirectory"] + "Common/ViewMemberShort.aspx?m=" +
                    dsUyeler.Tables[0].Rows[e.Row.RowIndex]["PRO"] + "\"/>";
                if (Convert.ToBoolean(gvListe.DataKeys[e.Row.RowIndex]["APPROVED"]) == false)
                    e.Row.FindControl("tdAccept").Visible = true;
                else
                    e.Row.FindControl("tdRemoveAccept").Visible = true;
            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            BSProject bs = new BSProject();
            DSProjectProfessionals ds = new DSProjectProfessionals();
            ds = bs.DanismanKaydiniGetir(Convert.ToInt32(e.CommandArgument));
            DSProjectProfessionals.PROJECT_PROFESSIONALRow dr = ds.PROJECT_PROFESSIONAL.FindByRECID(Convert.ToInt32(e.CommandArgument));
            
            if (e.CommandName == "Message")
            {
                WriteMessage1.ToUser = Convert.ToInt32(dr.MEMBER);
                WriteMessage1.DanismanAdiSoyadi = dsUyeler.Tables[0].Select("PRO=" + dr.MEMBER.ToString())[0]["AdiSoyadi"].ToString();

                mpFiltre2.Show();
            }
            else if (e.CommandName == "Feedback")
            {
                AddProfessionalFeedback1.MemberID = Convert.ToInt32(dr.MEMBER);
                AddProfessionalFeedback1.Listele();
                AddProfessionalFeedback1.Visible = true;
            }
            else if (e.CommandName == "View")
            {
                if (dsUyeler.Tables[0].Select("PRO=" + dr.MEMBER.ToString())[0]["PROAPPROVED"].ToString() == "True")
                    Response.Redirect("/Common/ViewMember.aspx?m=" + dr.MEMBER.ToString());
                else
                    Araclar.MesajGoster(this.Page, "notapproved", Araclar.MesajTipiEnum.Uyari);

            }
            else if (e.CommandName == "AddPro")
            {
                DataSet dt = bs.ProjeDanismanlariniGetir(ds.PROJECT_PROFESSIONAL.FindByRECID(Convert.ToInt32(e.CommandArgument)).PROJECT);

                if (dt != null && dt.Tables[0].Rows.Count > 9)
                {
                    Araclar.MesajGoster(this.Page, "max10ProfessionalPerProject", Araclar.MesajTipiEnum.Hata, 0);
                    return;
                }
                else
                {
                    
                    dr.APPROVED = true;
                    bs.DanismanKaydet(ds);
                    Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

                    DSMember dsMembers = new DSMember();
                    BSMember bsMembers = new BSMember();
                    dsMembers = bsMembers.KullanicilariGetirRecId(dr.MEMBER + "," + UserSession.KullaniciID.ToString());

                    MailGonder mGonder = new MailGonder();
                    mGonder.From = dsMembers.MEMBER.FindByRECID(UserSession.KullaniciID).EMAIL;
                    if (UserSession.SeciliDil == Dil.Turkish)
                    {
                        mGonder.Konu = UserSession.Adi + " " + UserSession.Soyadi + " danışmanlık isteğinizi onayladı.";
                        mGonder.Mesaj = "Proje listenizi http://www.mersinban.com adresine girerek görebilirsiniz.";
                    }
                    else
                    {
                        mGonder.Konu = UserSession.Adi + " " + UserSession.Soyadi + " accepted you as consultant.";
                        mGonder.Mesaj = "In order to see your new project, please visit http://www.mersinban.com";
                    }
                    mGonder.To = dsMembers.MEMBER.FindByRECID(dr.MEMBER).EMAIL;
                    mGonder.Gonder();
                    if (mGonder.Hata != null)
                    {
                        Araclar.MesajGoster(this.Page, mGonder.Hata.Message, Araclar.MesajTipiEnum.Hata, 0);
                    }

                    DataSet dsxx = new DataSet();
                    dsxx = bs.MyAdvisor(this.MasterID);
                    Araclar.GridDoldur(dsxx, gvListe);
                    dsUyeler = dsxx;
                }
            }
            else if (e.CommandName == "RemoveAccept")
            {

                ds.PROJECT_PROFESSIONAL[0].APPROVED = false;
                bs.DanismanKaydet(ds);
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);

                BSProject bsProject = new BSProject();
                DataSet dsxx = new DataSet();
                dsxx = bsProject.MyAdvisor(this.MasterID);
                Araclar.GridDoldur(dsxx, gvListe);
                dsUyeler = dsxx;
            }
        }

        protected void gvProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ListPro")
            {
                BSProject bs = new BSProject();
                DataSet ds = new DataSet();
                ds = bs.MyAdvisor(Convert.ToInt32(e.CommandArgument));
                this.MasterID = Convert.ToInt32(e.CommandArgument);
                dsUyeler = ds;
                Araclar.GridDoldur(ds, gvListe);
                
            }
        }
    }
}
