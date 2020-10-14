using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.TypeDataSets;
using DataService;

namespace Business.Survey
{
    public class BSSurvey
    {
        public void TestKayit(DSSurvey dsSurvey, DSSurveyMemberShiptType dsSurveyMemberShiptType, DSSurveyQuestions dsQuestions, DSSurveyQuestionOptions dsOptions)
        {
            Data oData = new Data(true);
            try
            {
                oData.TopluVeriIsleme(dsSurvey);
                oData.TopluVeriIsleme(dsSurveyMemberShiptType);
                oData.TopluVeriIsleme(dsQuestions);
                oData.TopluVeriIsleme(dsOptions);
                oData.CommitTransaction();
            }
            catch (Exception ex)
            {
                oData.RollbackTransaction();
                throw ex;
            }

        }

        public void CevaplariKaydet(DSSurveyQuestionAnswer ds)
        {
            Data oData = new Data();
            oData.TopluVeriIsleme(ds);
        }

        public DSSurvey TestleriGetir()
        {
            Data oData = new Data();
            DSSurvey ds = new DSSurvey();
            string sSQL = @"SELECT * FROM SURVEY ORDER BY DateEnd DESC";
            oData.VeriGetir<DSSurvey>(ref ds, sSQL);
            return ds;
        }

        public DSSurvey TestleriGetir(int MemberShiptTypeID)
        {
            Data oData = new Data();
            DSSurvey ds = new DSSurvey();
            string sSQL = @"SELECT SURVEY.*
                            FROM SURVEY INNER JOIN
                            SURVEY_MEMBERSHIPTYPE ON SURVEY.SurveyID = SURVEY_MEMBERSHIPTYPE.SurveyID
                            WHERE (SURVEY_MEMBERSHIPTYPE.MemberShipTypeID = " + MemberShiptTypeID.ToString() + @" AND (GETDATE() < SURVEY.DateEnd))
                            ORDER BY SURVEY.DateEnd DESC";
            oData.VeriGetir<DSSurvey>(ref ds, sSQL);
            return ds;
        }

        public DSSurveyMemberShiptType TestKullaniciTipiGetir(string SurveyID)
        {
            Data oData = new Data();
            DSSurveyMemberShiptType ds = new DSSurveyMemberShiptType();
            oData.VeriGetir<DSSurveyMemberShiptType>(ref ds, "SELECT * FROM SURVEY_MEMBERSHIPTYPE WHERE (SurveyID = '" + SurveyID + "')");
            return ds;
        }

        public DSSurveyQuestions TestSorulariniGetir(string SurveyID)
        {
            Data oData = new Data();
            DSSurveyQuestions ds = new DSSurveyQuestions();
            oData.VeriGetir<DSSurveyQuestions>(ref ds, "SELECT * FROM SURVEY_QUESTIONS WHERE (SurveyID = '" + SurveyID + "')");
            return ds;
        }

        public DSSurveyQuestionOptions TestSorulariSecenekleriniGetir(string SurveyID)
        {
            Data oData = new Data();
            DSSurveyQuestionOptions ds = new DSSurveyQuestionOptions();
            oData.VeriGetir<DSSurveyQuestionOptions>(ref ds, "SELECT * FROM SURVEY_QUESTION_OPTIONS WHERE (SurveyID='" + SurveyID + "')");
            return ds;
        }

        public DSSurveyQuestionAnswer TestCevaplariniGetir(string SurveyID)
        {
            Data oData = new Data();
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            oData.VeriGetir<DSSurveyQuestionAnswer>(ref ds, "SELECT * FROM SURVEY_QUESTION_ANSWER WHERE (SurveyID='" + SurveyID + "')");
            return ds;
        }

        public DSSurveyQuestionAnswer TestCevaplarimiGetir(string MemberShipTypeID, int MemberID)
        {
            Data oData = new Data();
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            oData.VeriGetir<DSSurveyQuestionAnswer>(ref ds, "SELECT SURVEY_QUESTION_ANSWER.* FROM SURVEY_QUESTION_ANSWER INNER JOIN MEMBER ON SURVEY_QUESTION_ANSWER.MemberID = MEMBER.RECID WHERE (MEMBER.MEMBERSHIPTYPE = " + MemberShipTypeID + ") AND (SURVEY_QUESTION_ANSWER.MemberID = " + MemberID.ToString() + ")");
            return ds;
        }

        public DSSurveyQuestionAnswer TestCevaplariniGetir(string SurveyID, int MemberID)
        {
            Data oData = new Data();
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            oData.VeriGetir<DSSurveyQuestionAnswer>(ref ds, "SELECT * FROM SURVEY_QUESTION_ANSWER WHERE (SurveyID = '" + SurveyID + "') AND (MemberID = " + MemberID.ToString() + ")");
            return ds;
        }

        public DSSurveyQuestionAnswer TestCevaplarini_Getir(string GuestID)
        {
            Data oData = new Data();
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            oData.VeriGetir<DSSurveyQuestionAnswer>(ref ds, "SELECT * FROM SURVEY_QUESTION_ANSWER WHERE (GuestID= '" + GuestID + "')");
            return ds;
        }

        public void TestSil(DSSurvey dsSurvey, DSSurveyMemberShiptType dsMember, DSSurveyQuestionAnswer dsAnswer, DSSurveyQuestionOptions dsOptions, DSSurveyQuestions dsQuestion)
        {
            Data oData = new Data(true);
            try
            {
                oData.TopluVeriIsleme(dsAnswer);
                oData.TopluVeriIsleme(dsOptions);
                oData.TopluVeriIsleme(dsQuestion);
                oData.TopluVeriIsleme(dsMember);
                oData.TopluVeriIsleme(dsSurvey);
                oData.CommitTransaction();
            }
            catch (Exception ex)
            {
                oData.RollbackTransaction();
                throw ex;
            }
        }
    }
}
