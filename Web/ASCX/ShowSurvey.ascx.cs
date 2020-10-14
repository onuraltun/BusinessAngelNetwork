using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Survey;
using Types.TypeDataSets;
using Web.Library;
using Types.Enums;
using System.Data;
using System.Collections;

namespace Web.ASCX
{
    public partial class ShowSurvey : System.Web.UI.UserControl
    {
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

        public int MemberShipTypeID
        {
            get
            {
                return Convert.ToInt32(ViewState["__MemberShipTypeID"]);
            }
            set
            {
                ViewState["__MemberShipTypeID"] = value;
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

        public string SessionID
        {
            get
            {
                return Session["__SessionID"].ToString();
            }
            set
            {
                Session["__SessionID"] = value;
            }
        }

        public Literal ltHeader
        {
            get
            {
                return exltTest;
            }
        }

        protected DSSurveyQuestionAnswer dsSurveyQuestionAnswer
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

            #region Cevaplarimi Getir
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            if (this.MemberShipTypeID != MemberShipType.Guest.GetHashCode())
            {
                ds = bs.TestCevaplariniGetir(SurveyID.ToString(), MemberID);
            }
            else
            {
                ds = bs.TestCevaplarini_Getir(SessionID);
            }

            this.dsSurveyQuestionAnswer = ds;
            #endregion

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

                        foreach (ListItem li in exrblOptions.Items)
                        {
                            DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[] drAnswer = (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsSurveyQuestionAnswer.SURVEY_QUESTION_ANSWER.Select("MemberID=" + MemberID.ToString() + " AND SurveyQuestionOptionID='" + li.Value + "'");
                            if (drAnswer.Length == 1)
                                li.Selected = true;
                        }
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

                        foreach (ListItem li in excbOptions.Items)
                        {
                            DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[] drAnswer = (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsSurveyQuestionAnswer.SURVEY_QUESTION_ANSWER.Select("MemberID=" + MemberID.ToString() + " AND SurveyQuestionOptionID='" + li.Value + "'");
                            if (drAnswer.Length == 1)
                                li.Selected = true;
                        }
                        #endregion
                    }
                    else if (Input_Type.Yazi.GetHashCode().ToString() == exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString())
                    {
                        #region Yazı ise
                        TextBox txtOption = (TextBox)e.Row.FindControl("txtOption");
                        txtOption.Visible = true;
                        DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[] drAnswer = (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsSurveyQuestionAnswer.SURVEY_QUESTION_ANSWER.Select("MemberID=" + MemberID.ToString() + " AND SurveyQuestionOptionID='" + exgvSiklar.DataKeys[e.Row.RowIndex]["SurveyOptionID"].ToString() + "'");
                        if (drAnswer.Length > 0)
                        {
                            txtOption.Text = drAnswer[0].Answer;
                        }
                        #endregion
                    }
                }
            }
        }

        protected void ibExcel_Click(object sender, ImageClickEventArgs e)
        {
            Araclar.Ctrl2Word(ltHeader.Text, exgvSorular, "Report");
        }
    }
}