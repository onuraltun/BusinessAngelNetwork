using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Types.TypeDataSets;
using Business.Survey;
using Web.Library;
using System.Data;
using System.Collections;
using Types.Enums;
using Business.Member;

namespace Web.ASCX
{
    public partial class AssesSurvey : System.Web.UI.UserControl
    {
        public delegate void TestDegerlendirildi();
        public event TestDegerlendirildi TestBitti;

        public int MemberID
        {
            get
            {
                return Convert.ToInt32(ViewState["__MemberID"]);
            }
            set
            {
                ViewState["__MemberID"] = value;
            }
        }

        public Guid SurveyID
        {
            get
            {
                return (Guid)Session["SurveyID"];
            }
            set
            {
                Session["SurveyID"] = value;
            }
        }

        public Literal ltHeader
        {
            get
            {
                return exltTest;
            }
        }

        protected DSSurveyQuestions dsSurveyQuestions
        {
            get
            {
                return (DSSurveyQuestions)Session["DSSurveyQuestions"];
            }
            set
            {
                Session["DSSurveyQuestions"] = value;
            }
        }

        protected DSSurveyQuestionOptions dsSurveyQuestionOptions
        {
            get
            {
                return (DSSurveyQuestionOptions)Session["DSSurveyQuestionOptions"];
            }
            set
            {
                Session["DSSurveyQuestionOptions"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void Goster()
        {
            BSSurvey bs = new BSSurvey();

            #region Şıklarımı Getir
            DSSurveyQuestionOptions dsOptions = new DSSurveyQuestionOptions();
            dsOptions = bs.TestSorulariSecenekleriniGetir(SurveyID.ToString());
            this.dsSurveyQuestionOptions = dsOptions;
            #endregion

            #region Soruları Getir
            DSSurveyQuestions dsSorular = new DSSurveyQuestions();
            dsSorular = bs.TestSorulariniGetir(SurveyID.ToString());
            this.dsSurveyQuestions = dsSorular;
            #endregion

            exgvSorular.DataSource = dsSurveyQuestions;
            exgvSorular.DataBind();
        }

        /// <summary>
        /// Cookie kontrol
        /// </summary>
        public bool DolduraBilirMi(string _SurveyID)
        {
            if (Request.Cookies["survey_" + _SurveyID] != null)
            {
                return false;
            }
            else
                return true;
        }

        protected void exgvSorular_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView exgvSiklar = (GridView)e.Row.FindControl("exgvSiklar");

                if (UserSession.SeciliDil == Dil.English)
                    exgvSiklar.Columns[0].HeaderText = dsSurveyQuestions.SURVEY_QUESTIONS.FindBySurveyQuestionID((new Guid(exgvSorular.DataKeys[e.Row.RowIndex]["SurveyQuestionID"].ToString()))).Question_EN;
                else
                    exgvSiklar.Columns[0].HeaderText = dsSurveyQuestions.SURVEY_QUESTIONS.FindBySurveyQuestionID((new Guid(exgvSorular.DataKeys[e.Row.RowIndex]["SurveyQuestionID"].ToString()))).Question_TR;

                DataTable dt = new DataTable();
                dt.Columns.Add("inputtypeid");
                dt.Columns.Add("SurveyQuestionID");
                dt.Columns.Add("SurveyOptionID");
                ArrayList al = new ArrayList();

                DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow[] drArr = (DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow[])dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.Select("SurveyQuestionID='" + exgvSorular.DataKeys[e.Row.RowIndex]["SurveyQuestionID"].ToString() + "'");
                foreach (DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow dr in drArr)
                {
                    if (!al.Contains(dr.InputTypeID))
                    {
                        DataRow drNew = dt.NewRow();
                        drNew["inputtypeid"] = dr.InputTypeID;
                        drNew["SurveyQuestionID"] = dr.SurveyQuestionID.ToString();
                        drNew["SurveyOptionID"] = dr.SurveyOptionID.ToString();
                        dt.Rows.Add(drNew);
                        al.Add(dr.InputTypeID);
                    }
                }
                Araclar.GridDoldur(dt, exgvSiklar);
            }
        }

        protected void exgvSiklar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView exgvSiklar = (GridView)sender;
                DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow[] drArr = (DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow[])dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.Select("SurveyQuestionID='" + exgvSiklar.DataKeys[e.Row.RowIndex]["SurveyQuestionID"].ToString() + "' AND InputTypeID=" + exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString());

                if (drArr.Length > 0)
                {
                    if (Input_Type.CoktanSecmeli.GetHashCode().ToString() == exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString())
                    {
                        #region Çoktan Seçmeli İse
                        RadioButtonList exrblOptions = (RadioButtonList)e.Row.FindControl("exrblOptions");
                        exrblOptions.Visible = true;
                        if (UserSession.SeciliDil == Dil.Turkish)
                            Araclar.Kombo_Doldur(exrblOptions, drArr, "SurveyOption_TR", "SurveyOptionID", Araclar.KomboTip.Normal);
                        else
                            Araclar.Kombo_Doldur(exrblOptions, drArr, "SurveyOption_EN", "SurveyOptionID", Araclar.KomboTip.Normal);
                        #endregion
                    }
                    else if (Input_Type.Secmeli.GetHashCode().ToString() == exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString())
                    {
                        #region Seçmeli İse
                        CheckBoxList excbOptions = (CheckBoxList)e.Row.FindControl("excbOptions");
                        excbOptions.Visible = true;
                        if (UserSession.SeciliDil == Dil.Turkish)
                            Araclar.Kombo_Doldur(excbOptions, drArr, "SurveyOption_TR", "SurveyOptionID", Araclar.KomboTip.Normal);
                        else
                            Araclar.Kombo_Doldur(excbOptions, drArr, "SurveyOption_EN", "SurveyOptionID", Araclar.KomboTip.Normal);
                        #endregion
                    }
                    else if (Input_Type.Yazi.GetHashCode().ToString() == exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString())
                    {
                        #region Yazı ise
                        TextBox txtOption = (TextBox)e.Row.FindControl("txtOption");
                        txtOption.Visible = true;
                        #endregion
                    }
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            DSSurveyQuestionAnswer dsAnswer = new DSSurveyQuestionAnswer();
            Guid gd = new Guid();

            foreach (GridViewRow grow in exgvSorular.Rows)
            {
                GridView gvOptions = (GridView)grow.FindControl("exgvSiklar");

                foreach (GridViewRow growOption in gvOptions.Rows)
                {
                    string inputypeid = gvOptions.DataKeys[growOption.RowIndex]["inputtypeid"].ToString();

                    if (Input_Type.CoktanSecmeli.GetHashCode().ToString() == inputypeid)
                    {
                        #region çoktan seçmeli
                        RadioButtonList exrblOptions = (RadioButtonList)growOption.FindControl("exrblOptions");
                        DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow dr = dsAnswer.SURVEY_QUESTION_ANSWER.NewSURVEY_QUESTION_ANSWERRow();
                        dr.Answer = "1";
                        dr.MemberID = UserSession.KullaniciID;
                        if (UserSession.KullaniciID == GuestUserID.UserID.GetHashCode())
                            dr.GuestID = gd.ToString();
                        dr.SurveyID = SurveyID;
                        dr.SurveyAnswerID = Guid.NewGuid();
                        dr.SurveyQuestionOptionID = (new Guid(exrblOptions.SelectedValue));
                        dsAnswer.SURVEY_QUESTION_ANSWER.AddSURVEY_QUESTION_ANSWERRow(dr);
                        #endregion
                    }
                    else if (Input_Type.Secmeli.GetHashCode().ToString() == inputypeid)
                    {
                        #region Seçmeli
                        CheckBoxList excbOptions = (CheckBoxList)growOption.FindControl("excbOptions");
                        foreach (ListItem li in excbOptions.Items)
                        {
                            if (li.Selected)
                            {
                                DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow dr = dsAnswer.SURVEY_QUESTION_ANSWER.NewSURVEY_QUESTION_ANSWERRow();
                                dr.Answer = "1";
                                dr.MemberID = UserSession.KullaniciID;
                                if (UserSession.KullaniciID == GuestUserID.UserID.GetHashCode())
                                    dr.GuestID = gd.ToString();
                                dr.SurveyID = SurveyID;
                                dr.SurveyAnswerID = Guid.NewGuid();
                                dr.SurveyQuestionOptionID = (new Guid(li.Value));
                                dsAnswer.SURVEY_QUESTION_ANSWER.AddSURVEY_QUESTION_ANSWERRow(dr);
                            }
                        }
                        #endregion
                    }
                    else if (Input_Type.Yazi.GetHashCode().ToString() == inputypeid)
                    {
                        #region Yazı
                        TextBox txtOption = (TextBox)growOption.FindControl("txtOption");
                        DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow dr = dsAnswer.SURVEY_QUESTION_ANSWER.NewSURVEY_QUESTION_ANSWERRow();
                        dr.Answer = txtOption.Text;
                        dr.MemberID = UserSession.KullaniciID;
                        if (UserSession.KullaniciID == GuestUserID.UserID.GetHashCode())
                            dr.GuestID = gd.ToString();
                        dr.SurveyID = SurveyID;
                        dr.SurveyQuestionOptionID = (new Guid(gvOptions.DataKeys[growOption.RowIndex]["SurveyOptionID"].ToString()));
                        dr.SurveyAnswerID = Guid.NewGuid();
                        dsAnswer.SURVEY_QUESTION_ANSWER.AddSURVEY_QUESTION_ANSWERRow(dr);
                        #endregion
                    }
                }
            }
            BSSurvey bs = new BSSurvey();
            bs.CevaplariKaydet(dsAnswer);
            Response.SetCookie(new HttpCookie("survey_" + SurveyID.ToString(), "1"));

            DSMember dsMembers = new DSMember();
            BSMember bsMembers = new BSMember();
            dsMembers = bsMembers.KullanicilariGetirRecId(MemberID.ToString() + "," + UserSession.KullaniciID.ToString());

            MailGonder mGonder = new MailGonder();
            mGonder.From = dsMembers.MEMBER.FindByRECID(UserSession.KullaniciID).EMAIL;
            if (UserSession.SeciliDil == Dil.Turkish)
            {
                mGonder.Konu = UserSession.Adi + " " + UserSession.Soyadi + " Size Yeni Mesaj Gönderdi.";
                mGonder.Mesaj = "Yeni mesajınızı görmek için http://www.mersinban.com adresini ziyaret ediniz.";
            }
            else
            {
                mGonder.Konu = UserSession.Adi + " " + UserSession.Soyadi + " sent you new message.";
                mGonder.Mesaj = "In order to read you new message, please visit http://www.mersinban.com";
            }
            mGonder.To = dsMembers.MEMBER.FindByRECID(MemberID).EMAIL;
            mGonder.Gonder();
            if (mGonder.Hata != null)
            {
                Araclar.MesajGoster(this.Page, mGonder.Hata.Message, Araclar.MesajTipiEnum.Hata, 0);
            }

            if (TestBitti != null)
                TestBitti();
        }
    }
}