using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Business.Survey;
using Types.TypeDataSets;
using Types.Enums;

namespace Web.Common
{
    public partial class Survey : MasterOfMaster
    {
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Guest; }
        }

        protected DSSurvey dsSurvey
        {
            get
            {
                return (DSSurvey)Session["DSSurvey"];
            }
            set
            {
                Session["DSSurvey"] = value;
            }
        }

        protected DSSurveyQuestionAnswer dsSurveyAnswer
        {
            get
            {
                return (DSSurveyQuestionAnswer)Session["DSSurveyQuestionAnswer"];
            }
            set
            {
                Session["DSSurveyQuestionAnswer"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ucTestYap.TestBitti += new Web.ASCX.AssesSurvey.TestDegerlendirildi(ucTestYap_TestBitti);
            if (!IsPostBack)
            {
                Listele();
                if (Request.QueryString["t"] != null)
                {
                    if (UserSession.UserMemberShipType == MemberShipType.Guest.GetHashCode())
                        return;

                    Guid param = new Guid(Request.QueryString["t"].Replace("'", ""));
                    if (dsSurveyAnswer.SURVEY_QUESTION_ANSWER.Select("SurveyID='" + Request.QueryString["t"] + "'").Length > 0)
                    {
                        GridViewCommandEventArgs comArg = new GridViewCommandEventArgs(null, new CommandEventArgs("Sonuc", param.ToString()));
                        exgvSurvey_RowCommand(null, comArg);
                    }
                    else
                    {
                        if (ucTestYap.DolduraBilirMi(param.ToString()))
                        {
                            GridViewCommandEventArgs comArg = new GridViewCommandEventArgs(null, new CommandEventArgs("Sec", param.ToString()));
                            exgvSurvey_RowCommand(null, comArg);
                        }
                        else
                        {
                            GridViewCommandEventArgs comArg = new GridViewCommandEventArgs(null, new CommandEventArgs("Sonuc", param.ToString()));
                            exgvSurvey_RowCommand(null, comArg);
                        }
                    }
                }
            }
        }

        protected void Listele()
        {
            BSSurvey bs = new BSSurvey();
            DSSurvey ds = new DSSurvey();
            ds = bs.TestleriGetir(UserSession.UserMemberShipType);
            dsSurvey = ds;
            DSSurveyQuestionAnswer dsAnswer = new DSSurveyQuestionAnswer();
            dsAnswer = bs.TestCevaplarimiGetir(UserSession.UserMemberShipType.ToString(), UserSession.KullaniciID);
            this.dsSurveyAnswer = dsAnswer;
            Araclar.GridDoldur(ds, gvSurvey);
        }

        protected void exgvSurvey_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sec")
            {
                if (ucTestYap.DolduraBilirMi(e.CommandArgument.ToString()))
                {
                    mvSurvey.SetActiveView(vDegerlendirme);
                    if (UserSession.SeciliDil == Dil.Turkish)
                        ucTestYap.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID((new Guid(e.CommandArgument.ToString()))).Subject_TR;
                    else
                        ucTestYap.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID((new Guid(e.CommandArgument.ToString()))).Subject_EN;
                    ucTestYap.SurveyID = (new Guid(e.CommandArgument.ToString()));
                    ucTestYap.MemberID = UserSession.KullaniciID;
                    ucTestYap.Goster();
                    if (UserSession.SeciliDil == Dil.English)
                        ucTestYap.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID((new Guid(e.CommandArgument.ToString()))).Subject_EN;
                    else
                        ucTestYap.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID((new Guid(e.CommandArgument.ToString()))).Subject_TR;
                }
                else
                    Araclar.MesajGoster(this.Page, "answeredBefore", Araclar.MesajTipiEnum.Uyari);
            }
            else if (e.CommandName == "Sonuc")
            {
                mvSurvey.SetActiveView(vGoruntuleme);
                ucTestiGor.SurveyID = (new Guid(e.CommandArgument.ToString()));
                ucTestiGor.MemberID = UserSession.KullaniciID;
                ucTestiGor.Goster();
                if (UserSession.SeciliDil == Dil.English)
                    ucTestiGor.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID((new Guid(e.CommandArgument.ToString()))).Subject_EN;
                else
                    ucTestiGor.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID((new Guid(e.CommandArgument.ToString()))).Subject_TR;
            }
        }

        void ucTestYap_TestBitti()
        {
            Listele();
            mvSurvey.SetActiveView(vListe);
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
        }

        protected void exgvSurvey_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (UserSession.SeciliDil == Dil.English)
                    e.Row.Cells[0].Text = gvSurvey.DataKeys[e.Row.RowIndex]["Subject_EN"].ToString();

                if (UserSession.UserMemberShipType != MemberShipType.Guest.GetHashCode())
                {
                    if (dsSurveyAnswer.SURVEY_QUESTION_ANSWER.Select("SurveyID='" + gvSurvey.DataKeys[e.Row.RowIndex]["SurveyID"].ToString() + "'").Length > 0)
                    {
                        e.Row.FindControl("tdGoster").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("tdDegerlendir").Visible = true;
                    }
                }
                else
                    e.Row.FindControl("tdDegerlendir").Visible = true;
            }
        }

        protected void btnReturnSurveyList_Click(object sender, EventArgs e)
        {
            mvSurvey.SetActiveView(vListe);
        }
    }
}
