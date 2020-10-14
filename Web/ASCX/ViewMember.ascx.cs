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
using System.Drawing;
using Types.Enums;

namespace Web.ASCX
{
    public partial class ViewMember : System.Web.UI.UserControl
    {
        #region properties

        private string taskName;
        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
            }

        }

        protected int MemberID
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

        #endregion

        protected override void OnInit(EventArgs e)
        {
            if (TaskName == "ReadOnly" || TaskName == "ViewMember")
                MemberID = Convert.ToInt32(Request.QueryString["m"]);
            else
                MemberID = UserSession.KullaniciID;

            File1.RelationID = MemberID;
            File1.TaskName = TaskName;
            File1.Listele();
            File2.RelationID = MemberID;
            File2.TaskName = TaskName;
            File2.Listele();
            File3.RelationID = MemberID;
            File3.TaskName = TaskName;
            File3.Listele();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((TaskName == "My" || TaskName == "ReadOnly") && (UserSession.UserMemberShipType != MemberShipType.Guest.GetHashCode()))
                    || (TaskName == "ViewMember" && (UserSession.UserMemberShipType == MemberShipType.Supervisor.GetHashCode() ||
                    UserSession.UserMemberShipType == MemberShipType.Admin.GetHashCode())))
                {
                    BSMember bs = new BSMember();
                    DSMember ds = new DSMember();
                    if (TaskName == "My")
                    {
                        ds = bs.KullaniciGetirRecId(MemberID);
                        imgMember.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=p&r={0}", MemberID);
                        imgLogo.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=l&r={0}", MemberID);
                    }
                    else if (TaskName == "ViewMember")
                    {
                        ds = bs.KullaniciGetirRecId(Convert.ToInt32(Request.QueryString["m"]));
                        imgMember.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=p&r={0}", Request.QueryString["m"]);
                        imgLogo.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=l&r={0}", Request.QueryString["m"]);
                        lbChangeLogo.Visible = false;
                        lbChangePicture.Visible = false;
                        lbUpdateProfile.Visible = false;
                        lbUpdateCV.Visible = false;
                    }
                    else if (TaskName == "ReadOnly")
                    {
                        ds = bs.KullaniciGetirRecId(Convert.ToInt32(Request.QueryString["m"]));
                        imgMember.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=p&r={0}", Request.QueryString["m"]);
                        imgLogo.ImageUrl = string.Format("~/Common/ViewImage.aspx?t=l&r={0}", Request.QueryString["m"]);
                        lbChangeLogo.Visible = false;
                        lbChangePicture.Visible = false;
                        lbUpdateProfile.Visible = false;
                        lbUpdateCV.Visible = false;
                    }
                    DSMember.MEMBERRow dr = ds.MEMBER[0];

                    trInvestorType.Visible = trAmount.Visible = (dr.MEMBERSHIPTYPE == MemberShipType.Investor.GetHashCode());

                    if (!dr.IsADDRESSNull())
                        exltADDRESS.Text = dr.ADDRESS;
                    if (!dr.IsCITYNull())
                        exltCITY.Text = dr.CITY;
                    if (!dr.IsPROVINCENull())
                        exltPROVINCE.Text = dr.PROVINCE;
                    if (!dr.IsCOUNTRYNull())
                        exltCOUNTRY.Text = dr.COUNTRY;
                    if (!dr.IsPOSTALCODENull())
                        exltPOSTALCODE.Text = dr.POSTALCODE;

                    if (!dr.IsAMOUNTSPERINVESTMENTNull())
                        exltAMOUNTSPERINVESTMENT.Text = dr.AMOUNTSPERINVESTMENT.ToString();
                    if (!dr.IsCOMPANYNAMENull())
                        exltCOMPANYNAME.Text = dr.COMPANYNAME;
                    exltEMAIL.Text = dr.EMAIL;
                    if (!dr.IsFAXNull())
                        exltFAX.Text = dr.FAX;
                    if (!dr.IsMOBILENUMBERNull())
                        exltMOBILENUMBER.Text = dr.MOBILENUMBER;
                    exltNAME.Text = dr.NAME;
                    if (!dr.IsPOSITIONNull())
                        exltPOSITION.Text = dr.POSITION;
                    exltSURNAME.Text = dr.SURNAME;
                    if (!dr.IsTELEPHONENull())
                        exltTELEPHONE.Text = dr.TELEPHONE;

                    Araclar araclar = new Araclar();

                    if (!dr.IsINVESTORTYPENull())
                        exltInvestorType.Text = araclar.DilCevirGetir(UserSession.SeciliDil, CacheHelper.InvestorTypeGetir().INVESTORTYPE.FindByRECID(dr.INVESTORTYPE).DESCRIPTION);

                    exltTitle.Text = araclar.DilCevirGetir(UserSession.SeciliDil, CacheHelper.TitleGetir().TITLE.FindByRECID(dr.TITLE).DESCRIPTION);

                    mvListe.SetActiveView(vKayitGoster);
                    mvListe.Visible = true;
                }
                else
                    mvListe.Visible = false;

            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();

            if (fuImage.HasFile)
            {
                BSMember bs = new BSMember();
                DSMember ds = new DSMember();
                ds = bs.KullaniciGetirRecId(MemberID);
                DSMember.MEMBERRow dr = ds.MEMBER[0];

                int MB1 = 1024 * 1024;

                if (fuImage.PostedFile.ContentLength > MB1)
                {
                    exltValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "filecannotbelargerthan");
                    return;
                }

                if (fuImage.PostedFile.ContentType != "image/bmp" &
                    fuImage.PostedFile.ContentType != "image/jpg" &
                    fuImage.PostedFile.ContentType != "image/gif" &
                    fuImage.PostedFile.ContentType != "image/pjpeg" &
                    fuImage.PostedFile.ContentType != "image/x-png")
                {
                    exltValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "fileformatnotsupported");
                    return;
                }

                HttpPostedFile resim = Request.Files[0];
                System.Drawing.Image originalImg = System.Drawing.Image.FromStream(resim.InputStream);

                Bitmap tumb = new Bitmap(100, 100);
                Graphics gf = Graphics.FromImage(tumb);
                SolidBrush sb = new SolidBrush(Color.White);
                gf.FillRectangle(sb, 0, 0, tumb.Width, tumb.Height);
                gf.DrawImage(originalImg, 0, 0, tumb.Width, tumb.Height);

                byte[] content = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(tumb).ConvertTo(tumb, typeof(byte[]));
                dr.PICTURE = content;

                bs.Kaydet(ds);

                exltValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "resimgonderildi");
            }
        }

        protected void btnUploadLogo_Click(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();

            if (fuLogo.HasFile)
            {
                BSMember bs = new BSMember();
                DSMember ds = new DSMember();
                ds = bs.KullaniciGetirRecId(MemberID);
                DSMember.MEMBERRow dr = ds.MEMBER[0];

                int MB1 = 1024 * 1024;

                if (fuLogo.PostedFile.ContentLength > MB1)
                {
                    exltLogoValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "filecannotbelargerthan");
                    return;
                }

                if (fuLogo.PostedFile.ContentType != "image/bmp" & fuLogo.PostedFile.ContentType != "image/jpg" &
                    fuLogo.PostedFile.ContentType != "image/gif" & fuLogo.PostedFile.ContentType != "image/pjpeg" &
                    fuLogo.PostedFile.ContentType != "image/x-png")
                {
                    exltLogoValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "fileformatnotsupported");
                    return;
                }

                HttpPostedFile resim = Request.Files[1];
                System.Drawing.Image originalImg = System.Drawing.Image.FromStream(resim.InputStream);

                Bitmap tumb = new Bitmap(100, 100);
                Graphics gf = Graphics.FromImage(tumb);
                SolidBrush sb = new SolidBrush(Color.White);
                gf.FillRectangle(sb, 0, 0, tumb.Width, tumb.Height);
                gf.DrawImage(originalImg, 0, 0, tumb.Width, tumb.Height);

                byte[] content = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(tumb).ConvertTo(tumb, typeof(byte[]));
                dr.LOGO = content;

                bs.Kaydet(ds);

                exltLogoValidate.Text = araclar.DilCevirGetir(UserSession.SeciliDil, "resimgonderildi");
            }
        }

        protected void lbUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Common/UpdateProfile.aspx");
        }

        protected void lbUpdateCV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Common/EditCV.aspx");
        }

        protected void lbExportCV_Click(object sender, EventArgs e)
        {
            Session["cvMEMBER"] = MemberID;
            Response.Redirect("/Common/ExportCV.aspx");
        }
    }
}