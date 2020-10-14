using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Globalization;
using Types.TypeDataSets;
using Types.Enums;
using Business.Management;
using System.IO;

namespace Web.Library
{
    public enum Mesaj_Status
    {
        Okunmadi = 0,
        Okundu = 1,
        Taslak = 2
    }

    public enum Mesaj_Sayfa_Status
    {
        Inbox = 1,
        Gonderilenler = 2,
        Taslaklar = 3,
        Silinenler = 4
    }

    public enum Input_Type
    {
        CoktanSecmeli = 1,
        Yazi = 2,
        Secmeli = 3
    }

    public class Araclar
    {
        public enum MesajTipiEnum
        {
            Bilgi = 1,
            Uyari = 2,
            Hata = 3,
            Basari = 4
        }

        /// <summary>
        /// Gönderilen mesajı çevirerek gösterir
        /// </summary>
        public static void MesajGoster(System.Web.UI.Page oPage, string sMesaj, MesajTipiEnum tip)
        {
            Araclar arc = new Araclar();
            sMesaj = arc.DilCevirGetir(UserSession.SeciliDil, sMesaj);
            //Literal exltMesaj = (Literal)oPage.Master.FindControl("exltMesaj");
            Literal exltMesaj = new Literal();
            exltMesaj.Text = "<div id=\"dialog\" class=\"" + tip.ToString() + "\" style=\"display:none;\" title=\"" + tip.GetHashCode().ToString() + "\">" + sMesaj + "</div>";
            oPage.RegisterClientScriptBlock("uyari", exltMesaj.Text);
        }

        /// <summary>
        /// Çevirmeden göster
        /// </summary>
        public static void MesajGoster(System.Web.UI.Page oPage, string sMesaj, MesajTipiEnum tip, int _param)
        {
            Literal exltMesaj = new Literal();
            exltMesaj.Text = "<div id=\"dialog\" class=\"" + tip.ToString() + "\" style=\"display:none;\"  title=\"" + tip.GetHashCode().ToString() + "\">" + sMesaj + "</div>";
            oPage.RegisterClientScriptBlock("uyari", exltMesaj.Text);
        }

        /// <summary>
        /// Standart mesajlar
        /// </summary>
        public static void MesajGoster(System.Web.UI.Page oPage, MesajTipiEnum tip)
        {
            //// Define the name and type of the client scripts on the page. 
            string sMesaj = String.Empty;
            //string csname1 = "PopupScript";
            //Type cstype = oPage.GetType();
            //string imageName = "";
            //int nGenislik = 300;
            //int nYukseklik = 150;

            switch (tip)
            {
                case MesajTipiEnum.Basari:
                    if (UserSession.SeciliDil == Dil.English)
                        sMesaj = "Operation completed succesfully.";
                    else
                        sMesaj = "İşlem başarıyla tamamlandı.";
                    break;
                case MesajTipiEnum.Bilgi:
                    if (UserSession.SeciliDil == Dil.English)
                        sMesaj = "Operation completed succesfully.";
                    else
                        sMesaj = "İşlem başarıyla tamamlandı.";
                    break;
                case MesajTipiEnum.Hata:
                    if (UserSession.SeciliDil == Dil.English)
                        sMesaj = "An unexptected error occured!";
                    else
                        sMesaj = "Hata oluştu!";
                    break;
            }

            Literal exltMesaj = new Literal();
            exltMesaj.Text = "<div id=\"dialog\" class=\"" + tip.ToString() + "\" style=\"display:none;\"  title=\"" + tip.GetHashCode().ToString() + "\">" + sMesaj + "</div>";
            oPage.RegisterClientScriptBlock("uyari", exltMesaj.Text);
        }

        public void SayfaDilAyari(Control ctrl)
        {
            try
            {
                if (ctrl is GridView)
                {

                    for (int i = 0; i < ((GridView)ctrl).Columns.Count; i++)
                    {
                        if (((GridView)ctrl).Columns[i].HeaderText != string.Empty)
                            ((GridView)ctrl).Columns[i].HeaderText = DilCevirGetir(UserSession.SeciliDil, ((GridView)ctrl).Columns[i].HeaderText.ToLower());
                    }
                    ((GridView)ctrl).EmptyDataText = DilCevirGetir(UserSession.SeciliDil, "kayityok");
                    ((GridView)ctrl).DataBind();

                    return;
                }

                if (ctrl.Controls.Count > 0)
                {
                    foreach (Control ctrDil in ctrl.Controls)
                    {
                        SayfaDilAyari(ctrDil);
                    }
                }
                else
                {
                    if (ctrl.ID != null)
                    {
                        if (ctrl.ID.StartsWith("ex"))
                            return;
                    }

                    if (ctrl is Label)
                    {
                        if (((Label)ctrl).ID.StartsWith("ref") | ((Label)ctrl).ID.StartsWith("cvdrp"))
                            return;
                        ((Label)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((Label)ctrl).ID);
                    }
                    else if (ctrl is Button)
                    {
                        ((Button)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((Button)ctrl).ID);
                    }
                    else if (ctrl is DropDownList)
                    {
                        DropDownList drp = (DropDownList)ctrl;
                        for (int i = 0; i < drp.Items.Count; i++)
                        {
                            drp.Items[i].Text = DilCevirGetir(UserSession.SeciliDil, drp.Items[i].Text);
                        }
                    }
                    else if (ctrl is Literal)
                    {
                        ((Literal)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((Literal)ctrl).ID);
                    }
                    else if (ctrl is HyperLink)
                    {
                        ((HyperLink)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((HyperLink)ctrl).ID);
                    }
                    else if (ctrl is CheckBox)
                    {
                        ((CheckBox)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((CheckBox)ctrl).ID);
                    }
                    else if (ctrl is LinkButton)
                    {
                        ((LinkButton)ctrl).Text = DilCevirGetir(UserSession.SeciliDil, ((LinkButton)ctrl).ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OlmayanKelimeyiKaydet(string Deyim)
        {
            DSDictionary ds = new DSDictionary();
            DSDictionary.DICTIONARYRow dr = ds.DICTIONARY.NewDICTIONARYRow();
            dr.CONTROLNAME = Deyim;
            dr.CREATEDBY = UserSession.KullaniciID;
            dr.CREATIONDATE = DateTime.Now;
            dr.ENGLISH = Deyim;
            dr.TURKISH = Deyim;
            ds.DICTIONARY.AddDICTIONARYRow(dr);
            BSDictionary bs = new BSDictionary();
            bs.Kaydet(ds);
            CacheHelper.SozlukTemizle();
        }

        public string DilCevirGetir(Dil Cevrilecekdili, string Deyim)
        {
            Deyim = Deyim.ToLower();
            if (Cevrilecekdili == Dil.Turkish)
            {
                if (CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'").Length > 0)
                {
                    return ((DSDictionary.DICTIONARYRow[])CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'"))[0].TURKISH;
                }
                else
                {
                    OlmayanKelimeyiKaydet(Deyim);
                    return Deyim;
                }
            }
            else
            {
                if (CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'").Length > 0)
                {
                    return ((DSDictionary.DICTIONARYRow[])CacheHelper.SozlukGetir().DICTIONARY.Select("CONTROLNAME='" + Deyim + "'"))[0].ENGLISH;
                }
                else
                {
                    OlmayanKelimeyiKaydet(Deyim);
                    return Deyim;
                }
            }
        }

        public static void GridDoldur(object objDataSource, GridView gvListe)
        {
            gvListe.BorderWidth = 0;
            gvListe.RowStyle.CssClass = "odd";
            gvListe.AlternatingRowStyle.CssClass = "even";
            gvListe.CssClass = "grid";
            gvListe.SelectedRowStyle.CssClass = "selected";
            gvListe.EmptyDataRowStyle.ForeColor = Color.Red;
            gvListe.EmptyDataRowStyle.Font.Bold = true;

            foreach (GridViewRow Row in gvListe.Rows)
            {
                Row.Attributes.Add("onmouseover", "this.className='grvMouseOver'");
                Row.Attributes.Add("onmouseout", "this.className='grvRowStyle'");
            }

            gvListe.DataSource = objDataSource;
            gvListe.DataBind();
        }

        public static void GridDoldur(DataSet objDataSource, GridView gvListe, string SortExpression)
        {
            gvListe.RowStyle.CssClass = "odd";
            gvListe.AlternatingRowStyle.CssClass = "even";
            gvListe.CssClass = "grid";
            gvListe.SelectedRowStyle.CssClass = "selected";
            gvListe.EmptyDataRowStyle.ForeColor = Color.Red;
            gvListe.EmptyDataRowStyle.Font.Bold = true;

            DataView dv = new DataView(objDataSource.Tables[0]);
            dv.Sort = SortExpression;
            gvListe.DataSource = dv;
            gvListe.DataBind();
        }

        public enum KomboTip
        {

            Normal = 0,
            Hepsi = 1,
            Bos = 2,
            Seciniz = 3
        }

        /// <summary>
        /// Gönderilen kontrolün excel çıktısını verir.
        /// </summary>
        /// <param name="ctrl">Çıktısını istediğiniz kontrol. eg.Gridview,Page vs... Eğer kontrol olarak Page Gönderiliyorsa EnableEventValidation=falase yapılması lazım</param>
        public static void Ctrl2Excel(Control ctrl)
        {
            Araclar.PrepareControlForExport(ctrl);
            HttpResponse cResponse = HttpContext.Current.Response;
            cResponse.Clear();
            cResponse.BufferOutput = true;
            cResponse.AddHeader("content-disposition", "attachment;filename=Rapor.xls");
            cResponse.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
            cResponse.Charset = "windows-1254";
            cResponse.Cache.SetCacheability(HttpCacheability.NoCache);
            cResponse.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            ctrl.RenderControl(htmlWrite);
            cResponse.Write(HttpContext.Current.Server.HtmlDecode(stringWrite.ToString()));
            cResponse.End();
        }

        public static void Ctrl2PPT(byte[] icerik)
        {
            HttpResponse cResponse = HttpContext.Current.Response;
            cResponse.Clear();
            cResponse.BufferOutput = true;
            cResponse.AddHeader("content-disposition", "attachment;filename=Presentation.ppt");
            cResponse.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
            cResponse.Charset = "windows-1254";
            cResponse.Cache.SetCacheability(HttpCacheability.NoCache);
            cResponse.ContentType = "application/vnd.ms-powerpoint";
            cResponse.BinaryWrite(icerik);
            cResponse.End();
        }

        /// <summary>
        /// Gönderilen kontrolün word çıktısını verir.
        /// </summary>
        /// <param name="ctrl">Çıktısını istediğiniz kontrol. eg.Gridview,Page vs... Eğer kontrol olarak Page Gönderiliyorsa EnableEventValidation=falase yapılması lazım</param>
        public static void Ctrl2Word(Control ctrl)
        {
            Araclar.PrepareControlForExport(ctrl);
            HttpResponse cResponse = HttpContext.Current.Response;
            cResponse.Clear();
            cResponse.BufferOutput = true;
            cResponse.AddHeader("content-disposition", "attachment;filename=Rapor.doc");
            cResponse.ContentEncoding = System.Text.Encoding.UTF7;
            cResponse.Charset = "ISO-8859-9";
            cResponse.Cache.SetCacheability(HttpCacheability.NoCache);
            cResponse.ContentType = "application/vnd.doc";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            ctrl.RenderControl(htmlWrite);
            cResponse.Write(HttpContext.Current.Server.HtmlDecode(stringWrite.ToString()));
            cResponse.End();
        }

        public static bool IsNumeric(string ifade)
        {
            CultureInfo MyCultureInfo;
            if (UserSession.SeciliDil == Dil.Turkish)
                MyCultureInfo = new CultureInfo("tr-TR");
            else
                MyCultureInfo = new CultureInfo("en-US");
            double Sonuc;
            return double.TryParse(ifade, System.Globalization.NumberStyles.Any, MyCultureInfo, out Sonuc);
        }

        public static bool IsDecimal(string ifade)
        {
            CultureInfo MyCultureInfo;
            if (UserSession.SeciliDil == Dil.Turkish)
                MyCultureInfo = new CultureInfo("tr-TR");
            else
                MyCultureInfo = new CultureInfo("en-US");
            decimal Sonuc;
            return decimal.TryParse(ifade, System.Globalization.NumberStyles.Number, MyCultureInfo, out Sonuc);
        }

        public static bool IsDateTime(string ifade)
        {
            try
            {
                string dtTarihim = Convert.ToDateTime(ifade).ToString("dd.MM.yyyy");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Temizle(Control ctrl)
        {
            if (ctrl.Controls.Count > 0)
            {
                foreach (Control ctrTemizlik in ctrl.Controls)
                {
                    Temizle(ctrTemizlik);
                }
                return;
            }

            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = "";
            if (ctrl is Moxiecode.TinyMCE.Web.TextArea)
                ((Moxiecode.TinyMCE.Web.TextArea)ctrl).Value = "";
            if (ctrl is DropDownList)
            {
                if (((DropDownList)ctrl).Items.FindByValue("0") != null)
                    ((DropDownList)ctrl).SelectedValue = "0";
            }
        }

        public static void KomboDoldur(ListControl drp, object ds, string dataTextField, string dataValueField, KomboTip secenek)
        {
            if (ds is DataRow[])
                Araclar.Kombo_Doldur(drp, (DataRow[])ds, dataTextField, dataValueField, secenek);
            else if (ds is DataSet)
                Araclar.Kombo_Doldur(drp, (DataSet)ds, dataTextField, dataValueField, secenek);
            else if (ds is DataView)
                Araclar.Kombo_Doldur(drp, (DataView)ds, dataTextField, dataValueField, secenek);
        }

        public static void Kombo_Doldur(ListControl drp, DataSet ds, string dataTextField, string dataValueField, KomboTip secenek)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = dataTextField + " ASC";
            drp.DataTextField = dataTextField;
            drp.DataValueField = dataValueField;
            drp.DataSource = dv;
            drp.DataBind();

            ListItem li;
            if (secenek == KomboTip.Hepsi)
            {
                if (UserSession.SeciliDil == Dil.Turkish)
                    li = new ListItem("Hepsi", "0");
                else
                    li = new ListItem("All", "0");
                drp.Items.Insert(0, li);
            }
            if (secenek == KomboTip.Bos)
            {
                li = new ListItem("", "0");
                drp.Items.Insert(0, li);
            }
            if (secenek == KomboTip.Seciniz)
            {
                if (UserSession.SeciliDil == Dil.Turkish)
                    li = new ListItem("Seçiniz", "0");
                else
                    li = new ListItem("Not Selected", "0");
                drp.Items.Insert(0, li);
            }
        }

        public static void Kombo_Doldur(ListControl drp, DataView dv, string dataTextField, string dataValueField, KomboTip secenek)
        {
            dv.Sort = dataTextField + " ASC";
            drp.DataTextField = dataTextField;
            drp.DataValueField = dataValueField;
            drp.DataSource = dv;
            drp.DataBind();

            ListItem li;
            if (secenek == KomboTip.Hepsi)
            {
                if (UserSession.SeciliDil == Dil.Turkish)
                    li = new ListItem("Hepsi", "0");
                else
                    li = new ListItem("All", "0");
                drp.Items.Insert(0, li);
            }
            if (secenek == KomboTip.Bos)
            {
                li = new ListItem("", "0");
                drp.Items.Insert(0, li);
            }
            if (secenek == KomboTip.Seciniz)
            {
                if (UserSession.SeciliDil == Dil.Turkish)
                    li = new ListItem("Seçiniz", "0");
                else
                    li = new ListItem("Not Selected", "0");
                drp.Items.Insert(0, li);
            }
        }

        public static void Kombo_Doldur(ListControl drp, DataRow[] drCol, string dataTextField, string dataValueField, KomboTip secenek)
        {
            ListItem li;
            DataRow dr;
            drp.Items.Clear();
            for (int i = 0; i < drCol.Length; i++)
            {
                dr = (DataRow)drCol.GetValue(i);

                li = new ListItem(dr[dataTextField].ToString(), dr[dataValueField].ToString());
                drp.Items.Insert(i, li);
            }
            if (secenek == KomboTip.Hepsi)
            {
                if (UserSession.SeciliDil == Dil.Turkish)
                    li = new ListItem("Hepsi", "0");
                else
                    li = new ListItem("All", "0");
                drp.Items.Insert(0, li);
            }
            if (secenek == KomboTip.Bos)
            {
                li = new ListItem("", "0");
                drp.Items.Insert(0, li);
            }
            if (secenek == KomboTip.Seciniz)
            {
                if (UserSession.SeciliDil == Dil.Turkish)
                    li = new ListItem("Seçiniz", "0");
                else
                    li = new ListItem("Not Selected", "0");
                drp.Items.Insert(0, li);
            }
        }

        protected static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                try
                {
                    if (current is LinkButton)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                    }
                    else if (current is ImageButton)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                    }
                    else if (current is Button)
                    {
                        control.Controls.Remove(current);
                    }
                    else if (current is HyperLink)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                    }
                    else if (current is DropDownList)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                    }
                    else if (current is CheckBox)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                    }
                }
                catch (Exception ex)
                {

                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
        }

        public static void Ctrl2Word(string Baslik, Control ctrl, string fileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.Charset = "ISO-8859-9";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-word";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-9");
            HttpContext.Current.Response.Charset = "ISO-8859-9";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".doc");

            System.IO.StringWriter stringWrite = new StringWriter(System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR"));
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stringWrite);
            ctrl.RenderControl(htmlWriter);

            // Output table as HTML
            string a1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title>Datos</title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
            string a3 = "<h2 align='center'>" + HttpContext.Current.Server.HtmlDecode(Baslik) + "</h2>";
            string a4 = "<h4 align='center'>Rapor Tarihi : " + DateTime.Now.ToShortDateString() + "</h4>";
            string a2 = "\n</body>\n</html>";
            HttpContext.Current.Response.Write(a1 + a3 + a4 + stringWrite.ToString() + a2);
            HttpContext.Current.Response.End();
        }

        public static void Ctrl2Excel(string Baslik, Control ctrl, string fileName)
        {
            Araclar.PrepareControlForExport(ctrl);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
            HttpContext.Current.Response.Charset = "windows-1254";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".xls");

            System.IO.StringWriter stringWrite = new StringWriter(System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR"));
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stringWrite);
            ctrl.RenderControl(htmlWriter);

            // Output table as HTML
            string a1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title>Datos</title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
            string a3 = "<h2 align='center'>" + HttpContext.Current.Server.HtmlDecode(Baslik) + "</h2>";
            string a4 = "<h4 align='center'>Rapor Tarihi : " + DateTime.Now.ToShortDateString() + "</h4>";
            string a2 = "\n</body>\n</html>";
            HttpContext.Current.Response.Write(a1 + a3 + a4 + stringWrite.ToString() + a2);
            HttpContext.Current.Response.End();
        }

        public static void SetObjectPropertyValue(Object ctl, string property, object value)
        {
            if (value == DBNull.Value)
                value = null;
            ctl.GetType().GetProperty(property).SetValue(ctl, value, null);
        }
    }
}
