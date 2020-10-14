using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Poll;
using Types.TypeDataSets;
using Web.Library;
using Types.Enums;

namespace Web.ASCX
{
    public partial class Poll : System.Web.UI.UserControl
    {
        protected int MasterID
        {
            get
            {
                return Convert.ToInt32(ViewState["__PollMasterID"]);
            }
            set
            {
                ViewState["__PollMasterID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BSPoll bs = new BSPoll();
                DSPoll ds = new DSPoll();
                ds = bs.AnketleriGetir(UserSession.UserMemberShipType);

                if (ds.POLL.Rows.Count == 0)
                    return;

                DSPoll_Options dsOptions = new DSPoll_Options();
                dsOptions = bs.Anket_Secenekleri_Getir(ds.POLL[0].RECID);
                this.MasterID = ds.POLL[0].RECID;

                if (UserSession.SeciliDil == Dil.English)
                {
                    exlblAnketKonusu.Text = ds.POLL[0].NAME_EN;
                    Araclar.Kombo_Doldur(exrblAnket, dsOptions, "OPTIONTEXT_EN", "RECID", Araclar.KomboTip.Normal);
                }
                else
                {
                    exlblAnketKonusu.Text = ds.POLL[0].NAME_TR;
                    Araclar.Kombo_Doldur(exrblAnket, dsOptions, "OPTIONTEXT_TR", "RECID", Araclar.KomboTip.Normal);
                }
            }
        }

        protected void btnVote_Click(object sender, EventArgs e)
        {
            if (exrblAnket.SelectedIndex < 0)
            {
                Araclar.MesajGoster(this.Page, "vote_option", Araclar.MesajTipiEnum.Uyari);
                return;
            }
            if (Request.Cookies["voted_" + this.MasterID.ToString()] == null)
            {
                BSPoll bs = new BSPoll();
                if (UserSession.UserMemberShipType != MemberShipType.Guest.GetHashCode())
                {
                    if (bs.OylayabilirMi(UserSession.KullaniciID, this.MasterID))
                    {
                        Oyla();
                    }
                    else
                    {
                        Araclar.MesajGoster(this.Page, "votedbefore", Araclar.MesajTipiEnum.Hata);
                        return;
                    }
                }
                else
                {
                    Oyla();
                }
            }
            else
            {
                Araclar.MesajGoster(this.Page, "votedbefore", Araclar.MesajTipiEnum.Hata);
            }
        }

        protected void Oyla()
        {
            BSPoll bs = new BSPoll();
            DSPoll_Answers dsAnswer = new DSPoll_Answers();
            DSPoll_Answers.POLL_ANSWERSRow dr = dsAnswer.POLL_ANSWERS.NewPOLL_ANSWERSRow();
            dr.POLL_OPTIONID = Convert.ToInt32(exrblAnket.SelectedValue);
            dr.POLLID = this.MasterID;
            dr.USERID = UserSession.KullaniciID;
            dsAnswer.POLL_ANSWERS.AddPOLL_ANSWERSRow(dr);
            bs.AnketCevapKayit(dsAnswer);
            Response.SetCookie(new HttpCookie("voted_" + this.MasterID.ToString(), "1"));
            Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
        }
    }
}