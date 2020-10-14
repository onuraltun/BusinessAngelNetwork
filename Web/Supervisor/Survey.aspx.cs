using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Library;
using Types.TypeDataSets;
using Business.Survey;
using System.Data;
using Business.Member;
using Types.Enums;
using System.Collections;

namespace Web.Supervisor
{
    public partial class Survey : MasterOfMaster
    {
        GridView exgvSorular;
        bool wordd;
        bool excell;

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

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected override MemberShipType PageMemberShip
        {
            get { return MemberShipType.Supervisor; }
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

        protected DSSurveyMemberShiptType dsSurveyMemberShiptType
        {
            get
            {
                return (DSSurveyMemberShiptType)Session["DSSurveyMemberShiptType"];
            }
            set
            {
                Session["DSSurveyMemberShiptType"] = value;
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

        protected DSMember dsMember
        {
            get
            {
                return (DSMember)Session["DSMember"];
            }
            set
            {
                Session["DSMember"] = value;
            }
        }

        protected Guid SurveyQuestionID
        {
            get
            {
                if (Session["SurveyQuestionID"] == null)
                {
                    Session["SurveyQuestionID"] = Guid.NewGuid();
                }
                if (((Guid)Session["SurveyQuestionID"]) == Guid.Empty)
                    Session["SurveyQuestionID"] = Guid.NewGuid();

                return (Guid)Session["SurveyQuestionID"];
            }
            set
            {
                Session["SurveyQuestionID"] = value;
            }
        }

        protected Guid SurveyID
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

        protected bool YeniKayitMi
        {
            get
            {
                return Convert.ToBoolean(ViewState["__YeniKayitMi"]);
            }
            set
            {
                ViewState["__YeniKayitMi"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listele();
            }
        }

        protected void Listele()
        {
            BSSurvey bs = new BSSurvey();
            DSSurvey ds = new DSSurvey();
            ds = bs.TestleriGetir();
            dsSurvey = ds;
            Araclar.GridDoldur(ds, exgvSurvey);
        }

        protected void exbtnYeniKayit_Click(object sender, EventArgs e)
        {
            this.YeniKayitMi = true;
            Araclar.Kombo_Doldur(cbMemberShiptType, CacheHelper.KullaniciTipiGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Normal);
            drpInputType.Items.Clear();
            drpInputType.Items.Add(new ListItem("Seçiniz", "0"));
            drpInputType.Items.Add(new ListItem("Çoktan Seçmeli", Input_Type.CoktanSecmeli.GetHashCode().ToString()));
            drpInputType.Items.Add(new ListItem("Yazmalı", Input_Type.Yazi.GetHashCode().ToString()));
            drpInputType.Items.Add(new ListItem("Seçmeli", Input_Type.Secmeli.GetHashCode().ToString()));
            SurveyID = Guid.NewGuid();
            SurveyQuestionID = Guid.Empty;
            Araclar.Temizle(vKayit);
            DSSurveyQuestions ds = new DSSurveyQuestions();
            dsSurveyQuestions = ds;
            DSSurveyQuestionOptions dsOptions = new DSSurveyQuestionOptions();
            dsSurveyQuestionOptions = dsOptions;
            SurveyQuestionID = Guid.Empty;
            Araclar.GridDoldur(null, exgvSIKLAR);
            Araclar.GridDoldur(null, exgvSoruGir);
            mvListe.SetActiveView(vKayit);
        }

        protected void exgvSurvey_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sec")
            {
                #region Düzeltme
                SurveyID = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].SurveyID;
                SurveyQuestionID = Guid.Empty;
                txtKonuEN.Text = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].Subject_EN;
                txtKonuTR.Text = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].Subject_TR;
                tvBas.Text = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].DateStart.ToShortDateString();
                tvBit.Text = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].DateEnd.ToShortDateString();

                BSSurvey bs = new BSSurvey();
                DSSurveyQuestions dsQuestions = new DSSurveyQuestions();
                dsQuestions = bs.TestSorulariniGetir(SurveyID.ToString());
                this.dsSurveyQuestions = dsQuestions;
                Araclar.GridDoldur(dsQuestions, exgvSoruGir);

                DSSurveyQuestionOptions dsOptions = new DSSurveyQuestionOptions();
                dsOptions = bs.TestSorulariSecenekleriniGetir(SurveyID.ToString());
                this.dsSurveyQuestionOptions = dsOptions;

                DSSurveyMemberShiptType dsMember = new DSSurveyMemberShiptType();
                dsMember = bs.TestKullaniciTipiGetir(SurveyID.ToString());
                this.dsSurveyMemberShiptType = dsMember;
                Araclar.Kombo_Doldur(cbMemberShiptType, CacheHelper.KullaniciTipiGetir(), "DESCRIPTION", "RECID", Araclar.KomboTip.Normal);
                foreach (ListItem li in cbMemberShiptType.Items)
                {
                    if (dsMember.SURVEY_MEMBERSHIPTYPE.Select("MemberShipTypeID=" + li.Value).Length > 0)
                        li.Selected = true;
                }
                foreach (DSSurveyMemberShiptType.SURVEY_MEMBERSHIPTYPERow drMember in dsMember.SURVEY_MEMBERSHIPTYPE.Rows)
                    drMember.Delete();

                this.YeniKayitMi = false;
                drpInputType.Items.Clear();
                drpInputType.Items.Add(new ListItem("Seçiniz", "0"));
                drpInputType.Items.Add(new ListItem("Çoktan Seçmeli", Input_Type.CoktanSecmeli.GetHashCode().ToString()));
                drpInputType.Items.Add(new ListItem("Yazmalı", Input_Type.Yazi.GetHashCode().ToString()));
                drpInputType.Items.Add(new ListItem("Seçmeli", Input_Type.Secmeli.GetHashCode().ToString()));
                mvListe.SetActiveView(vKayit);
                #endregion
            }
            else if (e.CommandName == "Sil")
            {
                #region silme
                BSSurvey bs = new BSSurvey();
                SurveyID = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].SurveyID;
                ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + e.CommandArgument.ToString() + "'"))[0].Delete();
                DSSurveyQuestions dsQuestions = new DSSurveyQuestions();
                dsQuestions = bs.TestSorulariniGetir(SurveyID.ToString());
                foreach (DSSurveyQuestions.SURVEY_QUESTIONSRow drQuestion in dsQuestions.SURVEY_QUESTIONS.Rows)
                {
                    drQuestion.Delete();
                }

                DSSurveyQuestionOptions dsOptions = new DSSurveyQuestionOptions();
                dsOptions = bs.TestSorulariSecenekleriniGetir(SurveyID.ToString());
                foreach (DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow drOption in dsOptions.SURVEY_QUESTION_OPTIONS.Rows)
                {
                    drOption.Delete();
                }

                DSSurveyMemberShiptType dsMember = new DSSurveyMemberShiptType();
                dsMember = bs.TestKullaniciTipiGetir(SurveyID.ToString());
                foreach (DSSurveyMemberShiptType.SURVEY_MEMBERSHIPTYPERow drMember in dsMember.SURVEY_MEMBERSHIPTYPE.Rows)
                    drMember.Delete();

                DSSurveyQuestionAnswer dsAnswers = new DSSurveyQuestionAnswer();
                dsAnswers = bs.TestCevaplariniGetir(SurveyID.ToString());
                foreach (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow drAnswer in dsAnswers.SURVEY_QUESTION_ANSWER.Rows)
                    drAnswer.Delete();

                bs.TestSil(dsSurvey, dsMember, dsAnswers, dsOptions, dsQuestions);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
                #endregion
            }
            else if (e.CommandName == "Oylayanlar")
            {
                SurveyID = (new Guid(e.CommandArgument.ToString()));
                BSSurvey bs = new BSSurvey();
                DSSurveyQuestionAnswer dsAnswers = new DSSurveyQuestionAnswer();
                dsAnswers = bs.TestCevaplariniGetir(e.CommandArgument.ToString());
                this.dsSurveyQuestionAnswer = dsAnswers;

                string memberIDler = string.Empty;
                int Guestler = 0;
                ArrayList al = new ArrayList();

                foreach (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow dr in dsAnswers.SURVEY_QUESTION_ANSWER.Rows)
                {
                    if (dr.MemberID == GuestUserID.UserID.GetHashCode())
                    {
                        if (!al.Contains(dr.GuestID))
                        {
                            Guestler++;
                            al.Add(dr.GuestID);
                        }
                    }
                    else
                        memberIDler += dr.MemberID.ToString() + ",";
                }
                memberIDler += "-1";

                BSMember bsmem = new BSMember();
                DSMember dsMem = new DSMember();
                dsMem = bsmem.KullanicilariGetirRecId(memberIDler);

                for (int i = 0; i < Guestler; i++)
                {
                    DSMember.MEMBERRow drGuest = dsMem.MEMBER.NewMEMBERRow();
                    if (UserSession.SeciliDil == Dil.English)
                        drGuest.NAME = "Guest";
                    else
                        drGuest.NAME = "Ziyaretçi";
                    drGuest.SURNAME = "";
                    drGuest.MEMBERSHIPTYPE = MemberShipType.Guest.GetHashCode();
                    drGuest.PASSWORD = "1";
                    drGuest.EMAIL = "1";
                    drGuest.TITLE = 1;
                    drGuest.ADDRESS = ((DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsAnswers.SURVEY_QUESTION_ANSWER.Select("MemberID =" + GuestUserID.UserID.GetHashCode().ToString()))[i].GuestID;
                    dsMem.MEMBER.AddMEMBERRow(drGuest);
                }

                this.dsMember = dsMem;
                Araclar.GridDoldur(dsMem, exgvMembers);
                mvListe.SetActiveView(vOylayanlar);
            }
        }

        protected void exbtnVazgec_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
        }

        protected void exbtnOptionEkle_Click(object sender, EventArgs e)
        {
            exltOptionUyari.Text = string.Empty;
            if (drpInputType.SelectedValue == "0")
            {
                exltOptionUyari.Text = "Lütfen soru tipi giriniz!";
                return;
            }
            if (dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.Select("InputTypeID=" + Input_Type.Yazi.GetHashCode().ToString()).Length > 0)
            {
                if (drpInputType.SelectedValue == Input_Type.Yazi.GetHashCode().ToString())
                {
                    exltOptionUyari.Text = "Bir soru için sadece bir tane yazı şıkkı girebilirsiniz!";
                    return;
                }
            }
            DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow dr = dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.NewSURVEY_QUESTION_OPTIONSRow();
            dr.SurveyOption_EN = txtOptionEn.Text;
            dr.SurveyOption_TR = txtOptionTR.Text;
            dr.InputTypeID = Convert.ToInt32(drpInputType.SelectedValue);
            dr.SurveyOptionID = Guid.NewGuid();
            dr.SurveyQuestionID = SurveyQuestionID;
            dr.SurveyID = SurveyID;
            dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.AddSURVEY_QUESTION_OPTIONSRow(dr);

            DataView dvOptions = new DataView(dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS);
            dvOptions.RowFilter = "SurveyQuestionID='" + SurveyQuestionID.ToString() + "'";
            Araclar.GridDoldur(dvOptions, exgvSIKLAR);
            txtOptionTR.Text = string.Empty;
            txtOptionEn.Text = string.Empty;
            drpInputType.SelectedValue = "0";
        }

        protected void exbtnSoruKayit_Click(object sender, EventArgs e)
        {
            if (drpInputType.SelectedValue == Input_Type.Yazi.GetHashCode().ToString())
            {
                DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow dr = dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.NewSURVEY_QUESTION_OPTIONSRow();
                dr.SurveyOption_EN = txtOptionEn.Text;
                dr.SurveyOption_TR = txtOptionTR.Text;
                dr.InputTypeID = Input_Type.Yazi.GetHashCode();
                dr.SurveyOptionID = Guid.NewGuid();
                dr.SurveyQuestionID = SurveyQuestionID;
                dr.SurveyID = SurveyID;
                dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.AddSURVEY_QUESTION_OPTIONSRow(dr);
            }

            if (dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.Rows.Count == 0)
            {
                Araclar.MesajGoster(this.Page, "Lütfen soru için şık giriniz!", Araclar.MesajTipiEnum.Hata, 0);
                mpOption.Show();
                return;
            }

            DSSurveyQuestions.SURVEY_QUESTIONSRow drQuestion = dsSurveyQuestions.SURVEY_QUESTIONS.NewSURVEY_QUESTIONSRow();
            drQuestion.Question_EN = txtSoruEN.Text;
            drQuestion.Question_TR = txtSoruTR.Text;
            drQuestion.SurveyQuestionID = SurveyQuestionID;
            drQuestion.SurveyID = SurveyID;
            dsSurveyQuestions.SURVEY_QUESTIONS.AddSURVEY_QUESTIONSRow(drQuestion);
            Araclar.GridDoldur(dsSurveyQuestions, exgvSoruGir);
            Araclar.MesajGoster(this.Page, "Soru başarıyla kaydedildi!", Araclar.MesajTipiEnum.Bilgi, 0);
            SurveyQuestionID = Guid.Empty;

            txtOptionTR.Text = string.Empty;
            txtOptionEn.Text = string.Empty;
            txtSoruEN.Text = string.Empty;
            txtSoruTR.Text = string.Empty;
            drpInputType.SelectedValue = "0";
            Araclar.GridDoldur(null, exgvSIKLAR);
        }

        protected void exgvSIKLAR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.FindBySurveyOptionID((new Guid(e.CommandArgument.ToString()))).Delete();
                Araclar.GridDoldur(dsSurveyQuestionOptions, exgvSIKLAR);
            }
        }

        protected void exgvSoruGir_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Guid surveyquestion = new Guid(e.CommandArgument.ToString());
                foreach (DSSurveyQuestionOptions.SURVEY_QUESTION_OPTIONSRow drOption in dsSurveyQuestionOptions.SURVEY_QUESTION_OPTIONS.Rows)
                {
                    if (drOption.SurveyQuestionID == surveyquestion)
                        drOption.Delete();
                }
                dsSurveyQuestions.SURVEY_QUESTIONS.FindBySurveyQuestionID(surveyquestion).Delete();
                Araclar.GridDoldur(dsSurveyQuestions, exgvSoruGir);
            }
        }

        protected void exbtnKaydet_Click(object sender, EventArgs e)
        {
            DSSurveyMemberShiptType dsMembers;
            if (this.YeniKayitMi)
                dsMembers = new DSSurveyMemberShiptType();
            else
                dsMembers = this.dsSurveyMemberShiptType;

            foreach (ListItem li in cbMemberShiptType.Items)
            {
                if (li.Selected)
                {
                    DSSurveyMemberShiptType.SURVEY_MEMBERSHIPTYPERow drMemberShipt = dsMembers.SURVEY_MEMBERSHIPTYPE.NewSURVEY_MEMBERSHIPTYPERow();
                    drMemberShipt.MemberShipTypeID = Convert.ToInt32(li.Value);
                    drMemberShipt.SurveyID = SurveyID;
                    drMemberShipt.SurveyMemID = Guid.NewGuid();
                    dsMembers.SURVEY_MEMBERSHIPTYPE.AddSURVEY_MEMBERSHIPTYPERow(drMemberShipt);
                }
            }

            if (dsMembers.SURVEY_MEMBERSHIPTYPE.Rows.Count == 0)
            {
                Araclar.MesajGoster(this.Page, "Lütfen en az bir izinli kullanıcı tipi seçiniz!", Araclar.MesajTipiEnum.Hata, 0);
                return;
            }

            DSSurvey.SURVEYRow dr;
            if (this.YeniKayitMi)
                dr = dsSurvey.SURVEY.NewSURVEYRow();
            else
            {
                dr = ((DSSurvey.SURVEYRow[])dsSurvey.SURVEY.Select("SurveyID='" + SurveyID.ToString() + "'"))[0];
            }
            dr.DateEnd = tvBit.Tarih;
            dr.DateStart = tvBas.Tarih;
            dr.Subject_EN = txtKonuEN.Text;
            dr.Subject_TR = txtKonuTR.Text;
            dr.SurveyID = SurveyID;
            if (this.YeniKayitMi)
                dsSurvey.SURVEY.AddSURVEYRow(dr);

            BSSurvey bs = new BSSurvey();
            bs.TestKayit(dsSurvey, dsMembers, dsSurveyQuestions, dsSurveyQuestionOptions);
            Listele();
            Araclar.MesajGoster(this.Page, "Test başarıyla kaydedildi!", Araclar.MesajTipiEnum.Bilgi, 0);
            mvListe.SetActiveView(vListe);
        }

        protected void drpInputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOptionTR.Text = string.Empty;
            txtOptionEn.Text = string.Empty;

            if (drpInputType.SelectedValue == Input_Type.Yazi.GetHashCode().ToString())
            {
                txtOptionTR.Text = "-";
                txtOptionEn.Text = "-";
                txtOptionEn.ReadOnly = true;
                txtOptionTR.ReadOnly = true;
            }
            else
            {
                txtOptionEn.ReadOnly = false;
                txtOptionTR.ReadOnly = false;
            }
        }

        protected void exgvMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = CacheHelper.KullaniciTipiGetir().MEMBERSHIPTYPE.FindByRECID(Convert.ToInt32(e.Row.Cells[2].Text)).DESCRIPTION;
            }
        }

        protected void exgvMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            exgvMembers.PageIndex = e.NewPageIndex;
            Araclar.GridDoldur(dsMember, exgvMembers);
        }

        protected void exgvMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sonuclar")
            {
                mvListe.SetActiveView(vSonuclar);
                ucShowSurvey.MemberID = Convert.ToInt32(e.CommandArgument);
                ucShowSurvey.MemberShipTypeID = -1;
                if (dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument.ToString())).MEMBERSHIPTYPE == MemberShipType.Guest.GetHashCode())
                {
                    ucShowSurvey.SessionID = dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).ADDRESS;
                    ucShowSurvey.MemberID = GuestUserID.UserID.GetHashCode();
                    ucShowSurvey.MemberShipTypeID = MemberShipType.Guest.GetHashCode();
                }
                if (UserSession.SeciliDil == Dil.English)
                    ucShowSurvey.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID(SurveyID).Subject_EN + " [Member:" + dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).NAME + " " + dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).SURNAME + "]";
                else
                    ucShowSurvey.ltHeader.Text = dsSurvey.SURVEY.FindBySurveyID(SurveyID).Subject_TR + " [Üye Kimliği:" + dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).NAME + " " + dsMember.MEMBER.FindByRECID(Convert.ToInt32(e.CommandArgument)).SURNAME + "]";
                ucShowSurvey.Goster();
            }
        }

        protected void exbtnTestler_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
        }

        protected void exbtnOylayanlar_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vOylayanlar);
        }

        protected void ibHepsiniYazdir_Click(object sender, ImageClickEventArgs e)
        {
            wordd = true;
            excell = false;
            BSSurvey bs = new BSSurvey();

            #region Cevaplarimi Getir
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            ds = bs.TestCevaplariniGetir(SurveyID.ToString());

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

            Araclar.GridDoldur(dsMember, exgvHepsi);
            if (UserSession.SeciliDil == Dil.English)
                Araclar.Ctrl2Word(dsSurvey.SURVEY.FindBySurveyID(SurveyID).Subject_EN, exgvHepsi, "Report.doc");
            else
                Araclar.Ctrl2Word(dsSurvey.SURVEY.FindBySurveyID(SurveyID).Subject_TR, exgvHepsi, "Report.doc");
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
                        if (wordd)
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
                        if (excell)
                        {
                            Literal exltGorunum = (Literal)e.Row.FindControl("exltGorunum");
                            exltGorunum.Visible = true;
                            exltGorunum.Text = "<ul>";
                            foreach (ListItem li in exrblOptions.Items)
                            {
                                DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[] drAnswer = (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsSurveyQuestionAnswer.SURVEY_QUESTION_ANSWER.Select("MemberID=" + MemberID.ToString() + " AND SurveyQuestionOptionID='" + li.Value + "'");
                                if (drAnswer.Length == 1)
                                {
                                    exltGorunum.Text += "<li>(+)" + li.Text + "</li>";
                                }
                                else
                                {
                                    exltGorunum.Text += "<li>(-)" + li.Text + "</li>";
                                }
                            }
                            exltGorunum.Text += "</ul>";
                        }
                    }
                    else if (Input_Type.Secmeli.GetHashCode().ToString() == exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString())
                    {
                        #region Seçmeli İse
                        CheckBoxList excbOptions = (CheckBoxList)e.Row.FindControl("excbOptions");
                        if (wordd)
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
                        if (excell)
                        {
                            Literal exltGorunum = (Literal)e.Row.FindControl("exltGorunum");
                            exltGorunum.Visible = true;
                            exltGorunum.Text = "<ul>";
                            foreach (ListItem li in excbOptions.Items)
                            {
                                DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[] drAnswer = (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsSurveyQuestionAnswer.SURVEY_QUESTION_ANSWER.Select("MemberID=" + MemberID.ToString() + " AND SurveyQuestionOptionID='" + li.Value + "'");
                                if (drAnswer.Length == 1)
                                {
                                    exltGorunum.Text += "<li>(+)" + li.Text + "</li>";
                                }
                                else
                                {
                                    exltGorunum.Text += "<li>(-)" + li.Text + "</li>";
                                }
                            }
                            exltGorunum.Text += "</ul>";
                        }
                    }
                    else if (Input_Type.Yazi.GetHashCode().ToString() == exgvSiklar.DataKeys[e.Row.RowIndex]["inputtypeid"].ToString())
                    {
                        #region Yazı ise
                        TextBox txtOption = (TextBox)e.Row.FindControl("txtOption");
                        Literal exltGorunum = (Literal)e.Row.FindControl("exltGorunum");
                        if (wordd)
                            txtOption.Visible = true;
                        else
                            exltGorunum.Visible = true;
                        DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[] drAnswer = (DSSurveyQuestionAnswer.SURVEY_QUESTION_ANSWERRow[])dsSurveyQuestionAnswer.SURVEY_QUESTION_ANSWER.Select("MemberID=" + MemberID.ToString() + " AND SurveyQuestionOptionID='" + exgvSiklar.DataKeys[e.Row.RowIndex]["SurveyOptionID"].ToString() + "'");
                        if (drAnswer.Length > 0)
                        {
                            if (wordd)
                                txtOption.Text = drAnswer[0].Answer;
                            else
                                exltGorunum.Text = drAnswer[0].Answer;
                        }
                        #endregion
                    }
                }
            }
        }

        protected void exgvHepsi_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.MemberID = Convert.ToInt32(exgvHepsi.DataKeys[e.Row.RowIndex]["RECID"].ToString());
                Literal exltMember = (Literal)e.Row.FindControl("exltMember");
                exltMember.Text = (dsMember.Tables[0].Select("RECID=" + MemberID.ToString()))[0]["NAME"].ToString() + " " + (dsMember.Tables[0].Select("RECID=" + MemberID.ToString()))[0]["SURNAME"].ToString();
                exgvSorular = (GridView)e.Row.FindControl("exgvSorular");
                exgvSorular.DataSource = dsSurveyQuestions;
                exgvSorular.DataBind();
            }
        }

        protected void ibExcelHepsi_Click(object sender, ImageClickEventArgs e)
        {
            wordd = false;
            excell = true;
            BSSurvey bs = new BSSurvey();

            #region Cevaplarimi Getir
            DSSurveyQuestionAnswer ds = new DSSurveyQuestionAnswer();
            ds = bs.TestCevaplariniGetir(SurveyID.ToString());

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

            Araclar.GridDoldur(dsMember, exgvHepsi);
            if (UserSession.SeciliDil == Dil.English)
                Araclar.Ctrl2Excel(dsSurvey.SURVEY.FindBySurveyID(SurveyID).Subject_EN, exgvHepsi, "Report.doc");
            else
                Araclar.Ctrl2Excel(dsSurvey.SURVEY.FindBySurveyID(SurveyID).Subject_TR, exgvHepsi, "Report.doc");
        }
    }
}