using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Web.Library;

namespace Web.Admin
{
    public partial class Upload : MasterOfMaster
    {
        protected override Types.Enums.MemberShipType PageMemberShip
        {
            get { return Types.Enums.MemberShipType.Supervisor; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listele();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            btnUpload.Click += new EventHandler(btnUpload_Click);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);

            base.OnInit(e);
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("URL", Type.GetType("System.String"));

            foreach (String name in System.IO.Directory.GetFiles(Server.MapPath("/uploads")))
                dt.Rows.Add(new object[] { Path.GetFileName(name), string.Concat("/uploads/", Path.GetFileName(name)) });
            Araclar.GridDoldur(dt, GridView1);
        }

        void btnUpload_Click(object sender, EventArgs e)
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                if (File1.PostedFile.ContentLength > 1024 * 1024 * 2)
                    Araclar.MesajGoster(this, "File size cannot be larger than 2MB", Araclar.MesajTipiEnum.Bilgi);
                else
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("\\Uploads") + "\\" + fn;
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);
                        Araclar.MesajGoster(this, "The file has been uploaded.", Araclar.MesajTipiEnum.Bilgi);
                        Listele();
                    }
                    catch (Exception ex)
                    {
                        Araclar.MesajGoster(this, "Error: " + ex.Message, Araclar.MesajTipiEnum.Hata);
                    }
                }
            }
            else
            {
                Araclar.MesajGoster(this, "Please select a file to upload.", Araclar.MesajTipiEnum.Bilgi);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                System.IO.File.Delete(Server.MapPath("\\Uploads") + "\\" + e.CommandArgument);
                Listele();
            }
        }

    }
}
