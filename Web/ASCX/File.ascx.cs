using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Member;
using Types.TypeDataSets;
using Web.Library;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using Business;
using System.Drawing;
using Types.Enums;
using System.IO;

namespace Web.ASCX
{
    public partial class File : System.Web.UI.UserControl
    {
        #region properties

        public int RelationID
        {
            get
            {
                return Convert.ToInt32(ViewState["__relationID"]);
            }
            set
            {
                ViewState["__relationID"] = value;
            }

        }

        public string TaskName
        {
            get
            {
                return ViewState["__TaskName"].ToString();
            }
            set
            {
                ViewState["__TaskName"] = value;
            }

        }

        private FileTypeEnums fileType;
        public FileTypeEnums FileType
        {
            get
            {
                return fileType;
            }
            set
            {
                fileType = value;
            }

        }

        private string tableName;
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }

        }

        #endregion


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
                if (TaskName == "ReadOnly" || TaskName == "Guest")
                {
                    lbUploadFile.Visible = false;
                }
            }
        }

        public void Listele()
        {
            if (RelationID != 0 && TableName != "" && FileType != 0)
            {
                Araclar araclar = new Araclar();
                exltHeader.Text = araclar.DilCevirGetir(UserSession.SeciliDil, FileType.ToString());
                BSFiles bs = new BSFiles();
                DSFiles ds = new DSFiles();
                ds = bs.Getir_MukkemmelBirSorguDaha(RelationID, TableName, FileType.GetHashCode());
                Araclar.GridDoldur(ds, gvListe);
                mvListe.SetActiveView(vListe);
            }
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (RelationID != 0 && TableName != "" && FileType.GetHashCode() != 0)
            {
                Araclar araclar = new Araclar();

                if (fuFile.HasFile)
                {
                    BSFiles bs = new BSFiles();
                    DSFiles ds = new DSFiles();


                    DSFiles.FILESRow dr = ds.FILES.NewFILESRow();
                    dr.CREATEDBY = UserSession.KullaniciID;
                    dr.CREATIONDATE = DateTime.Now;


                    int MB1 = 1024 * 1024;

                    if (fuFile.PostedFile.ContentLength > MB1)
                    {
                        exltValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "filecannotbelargerthan");
                        return;
                    }

                    if (fuFile.PostedFile.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" &
                        fuFile.PostedFile.ContentType != "application/pdf" &
                        fuFile.PostedFile.ContentType != "application/msword" &
                        fuFile.PostedFile.ContentType != "application/vnd.ms-powerpoint" &
                        fuFile.PostedFile.ContentType != "application/vnd.ms-excel" &
                        fuFile.PostedFile.ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    {
                        exltValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "fileformatnotsupported");
                        return;
                    }

                    dr.FILENAME = fuFile.FileName;
                    dr.SIZE = fuFile.FileBytes.Length;
                    dr.TABLENAME = TableName;
                    dr.FILETYPE = FileType.GetHashCode();
                    dr.RELATIONID = RelationID;

                    dr.FILEBINARY = fuFile.FileBytes;

                    ds.FILES.AddFILESRow(dr);

                    bs.Kaydet(ds);

                    Listele();

                    exltValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "dosyagonderildi");
                }
            }
        }

        protected void gvListe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                BSFiles bs = new BSFiles();
                DSFiles ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                ds.FILES.FindByRECID(Convert.ToInt32(e.CommandArgument)).Delete();
                bs.Kaydet(ds);
                Listele();
                Araclar.MesajGoster(this.Page, Araclar.MesajTipiEnum.Bilgi);
            }
            else if (e.CommandName == "Sec")
            {
                BSFiles bs = new BSFiles();
                DSFiles ds = bs.Getir_byRECID(Convert.ToInt32(e.CommandArgument));

                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(ds.FILES[0].FILENAME, System.Text.Encoding.UTF8));
                Response.BinaryWrite(ds.FILES[0].FILEBINARY);
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            mvListe.SetActiveView(vListe);
            Araclar.Temizle(vListe);
        }

        protected void gvListe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (TaskName == "ReadOnly" || TaskName == "Guest")
                {
                    ((ImageButton)e.Row.FindControl("ibSil")).Visible = false;
                }
            }
        }


    }
}