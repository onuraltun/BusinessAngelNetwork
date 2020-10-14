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

namespace Web.Common
{
    public partial class PollResults : System.Web.UI.Page
    {
        int Toplam = 0;

        protected DSPoll_Answers dscevaplar
        {
            get
            {
                return (DSPoll_Answers)Session["cevaplar"];
            }
            set
            {
                Session["cevaplar"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AnketiYukle();
            }
        }

        protected void AnketiYukle()
        {
            BSPoll bs = new BSPoll();
            DSPoll dsPoll = new DSPoll();
            dsPoll = bs.AnketleriGetir(UserSession.UserMemberShipType);
            if (UserSession.SeciliDil == Dil.English)
            {
                lblAnketKonusu.Text = dsPoll.POLL[0].NAME_EN;
            }
            else
            {
                lblAnketKonusu.Text = dsPoll.POLL[0].NAME_TR;
            }

            DSPoll_Answers dsAnswers = new DSPoll_Answers();
            dsAnswers = bs.Anket_Cevaplari_Getir(dsPoll.POLL[0].RECID);
            this.dscevaplar = dsAnswers;

            Toplam = dsAnswers.POLL_ANSWERS.Rows.Count;

            if (Toplam == 0)
            {
                Response.Write("<script>alert('Henüz oylama yapılmamış!');window.close();</script>");
            }
            else
            {
                DSPoll_Options dsOptions = new DSPoll_Options();
                dsOptions = bs.Anket_Secenekleri_Getir(dsPoll.POLL[0].RECID);
                lbToplam.Text = "Toplam:" + Toplam.ToString() + " Oy";
                gvAnketSonucu.DataSource = dsOptions;
                gvAnketSonucu.DataBind();
                CssEkle(gvAnketSonucu);
            }
        }

        protected void gvAnketSonucu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (UserSession.SeciliDil == Dil.English)
                {
                    e.Row.Cells[0].Text = gvAnketSonucu.DataKeys[e.Row.RowIndex]["OPTIONTEXT_EN"].ToString();
                }

                int optionID = Convert.ToInt32(gvAnketSonucu.DataKeys[e.Row.RowIndex]["RECID"].ToString());
                int Sayi = dscevaplar.POLL_ANSWERS.Select("POLL_OPTIONID=" + optionID.ToString()).Length;

                Image ISonuc = (Image)e.Row.FindControl("ISonuc");
                decimal Yuzde = Sayi * 100 / Toplam;
                ISonuc.Width = new Unit(Sayi * 100 / Toplam, UnitType.Percentage);
                Label lbYuzde = (Label)e.Row.FindControl("lbYuzde");
                lbYuzde.Text = "%" + ISonuc.Width.Value.ToString();
            }
        }

        public static void CssEkle(GridView grv)
        {
            grv.BorderWidth = 1;
            grv.AlternatingRowStyle.CssClass = "grvAlternatingRowStyle";
            grv.RowStyle.CssClass = "grvRowStyle";
            grv.HeaderStyle.CssClass = "grvHeaderStyle";
            grv.SelectedRowStyle.CssClass = "grvSelectedRowStyle";
            grv.PagerStyle.CssClass = "grvPager";
            grv.Width = new Unit(100, UnitType.Percentage);
            foreach (GridViewRow Row in grv.Rows)
            {
                Row.Attributes.Add("onmouseover", "this.className='grvMouseOver'");
                Row.Attributes.Add("onmouseout", "this.className='grvRowStyle'");
            }
        }
    }
}
