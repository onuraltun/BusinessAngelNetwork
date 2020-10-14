using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Types.TypeDataSets;
using Types.Enums;

namespace DataService
{
    public class Data
    {
        public static string sCnstr;
        private SqlConnection cn;
        private SqlTransaction oTransaction;
        public bool IsTransactional;

        public Data()
            : this(false)
        {
        }

        public Data(bool bTransaction)
        {
            sCnstr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            cn = new SqlConnection(sCnstr);
            IsTransactional = bTransaction;
            if (IsTransactional)
            {
                try
                {
                    cn.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
                BeginTransaction();
            }
        }

        public void BeginTransaction()
        {
            oTransaction = cn.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            if (IsTransactional)
            {
                oTransaction.Rollback();
                cn.Close();
            }
        }

        public void CommitTransaction()
        {
            if (IsTransactional)
            {
                oTransaction.Commit();
                cn.Close();
            }
        }

        public int SQLKomutCalistir(string ssql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(ssql, cn);
            if (IsTransactional)
                cmd.Transaction = oTransaction;
            try
            {
                SaveCommandLog(ssql);
                return (cmd.ExecuteNonQuery());
            }
            catch (Exception e)
            {
                throw HataOlustur(e, ssql);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void VeriGetir(ref DataSet ds, string ssql)
        {
            if (ds.Tables.Count == 0)
                ds.Tables.Add();
            DataTable dt = ds.Tables[0];
            VeriGetir(ref dt, ssql);
        }

        public void VeriGetir(ref DataSet ds, string ssql, string stable)
        {
            DataTable dt = ds.Tables[stable];
            VeriGetir(ref dt, ssql);
        }

        public DataSet VeriGetir(string ssql)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            VeriGetir(ref ds, ssql);
            return ds;
        }

        public void VeriGetir<T>(ref T ds, string ssql) where T : DataSet
        {
            DataTable dt = ds.Tables[0];
            VeriGetir(ref dt, ssql);
        }

        public void VeriGetir(ref DataTable dt, string ssql)
        {
            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(ssql, cn);
            try
            {
                if (IsTransactional)
                    da.SelectCommand.Transaction = oTransaction;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw HataOlustur(e, ssql);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void VeriGetirSP(ref DataSet ds, string sSPAdi, SqlParameter[] pParametre)
        {
            int i;
            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Connection = cn;
            da.SelectCommand.CommandText = sSPAdi;
            try
            {
                if (IsTransactional)
                    da.SelectCommand.Transaction = oTransaction;
                if ((pParametre != null))
                {
                    for (i = 0; i <= pParametre.Length - 1; i++)
                    {
                        da.SelectCommand.Parameters.Add(pParametre[i]);
                    }
                }
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw HataOlustur(e, sSPAdi);
            }
            finally
            {
                CloseConnection();
            }

        }

        public void TopluVeriIsleme(DataSet ds, string ssql, string sTable)
        {
            TopluVeriIsleme(ds.Tables[sTable], ssql);
        }

        public void TopluVeriIsleme(DataSet ds, string ssql)
        {
            TopluVeriIsleme(ds.Tables[0], ssql);
        }

        public void TopluVeriIsleme(DataSet ds)
        {
            string ssql = "SELECT * FROM " + ds.Tables[0].TableName;
            TopluVeriIsleme(ds.Tables[0], ssql);
        }

        public void TopluVeriIsleme(DataTable dt)
        {

            string ssql = "SELECT * FROM " + dt.TableName;
            TopluVeriIsleme(dt, ssql);
        }

        public void TopluVeriIslemeID(DataTable dt, string ssql, string sIDFieldName)
        {

            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(ssql, cn);
            SqlDataAdapter da1 = new SqlDataAdapter(ssql, cn);
            if (IsTransactional)
                da.SelectCommand.Transaction = oTransaction;
            //checked 
            try
            {


                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                SqlCommand cmd;

                cmd = cb.GetInsertCommand();
                cmd.CommandText += "; " + ssql + " Where " + sIDFieldName + "=@@IDENTITY";
                cmd.UpdatedRowSource = UpdateRowSource.Both;
                da1.InsertCommand = cmd;
                da1.UpdateCommand = cb.GetUpdateCommand();
                da1.DeleteCommand = cb.GetDeleteCommand();
                DataTable dtBefore = dt.Copy();
                da1.Update(dt);
                LogWriteDataTable(dtBefore, dt);
            }
            catch (Exception e)
            {
                throw HataOlustur(e, ssql);
            }
            finally
            {
                CloseConnection();
            }

        }

        public void TopluVeriIslemeID(DataTable dt)
        {
            string ssql = "SELECT * FROM " + dt.TableName;
            TopluVeriIslemeID(dt, ssql, dt.PrimaryKey[0].ColumnName);
        }

        public void TopluVeriIslemeID(DataSet ds)
        {
            TopluVeriIslemeID(ds.Tables[0]);
        }

        public void TopluVeriIsleme(DataTable dt, string ssql)
        {
            OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(ssql, cn);
            if (IsTransactional)
                da.SelectCommand.Transaction = oTransaction;
            try
            {

                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable dtBefore = dt.Copy();
                da.Update(dt);
                LogWriteDataTable(dtBefore, dt);
            }
            catch (Exception E)
            {
                throw HataOlustur(E, ssql);
            }
            finally
            {
                CloseConnection();
            }
        }

        public object TekDegerGetir(string ssql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(ssql, cn);
            if (IsTransactional)
                cmd.Transaction = oTransaction;
            try
            {
                return (cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw HataOlustur(e, ssql);
            }
            finally
            {
                CloseConnection();
            }
        }

        private Exception HataOlustur(Exception e, string ssql)
        {
            return e;
            //if (e is DBConcurrencyException)
            //{
            //    return new SQLKomutCalismaHatasi("Bu kayıt sizden önce başkası tarafından değiştirilmiş. Yeni durumu görmek için tekrar sorgulama yapınız.", e, "Dataservis.SQLKomutCalistir", ssql);
            //}
            //else if (e is SqlException)
            //{
            //    SqlException eSQL = (SqlException)e;
            //    switch (eSQL.Number)
            //    {
            //        case 8152:
            //            return new SQLKomutCalismaHatasi("Girilen bilgilerden bazıları ayrılan alan uzunluğundan fazladır.", e, "Dataservis.SQLKomutCalistir", ssql);
            //        case 2627:
            //        case 2601:
            //            return new SQLKomutCalismaHatasi("Aynı Birincil Alanlı(Primary Key) kayıt daha önceden girilmiş.", e, "Dataservis.SQLKomutCalistir", ssql);
            //        default:
            //            return new SQLKomutCalismaHatasi("Veritabanı komut hatası.", e, "Dataservis.SQLKomutCalistir", ssql);
            //    }
            //}
            //else
            //{
            //    return new SQLKomutCalismaHatasi("Bilinmeyen veritabanı hatası.", e, "Dataservis.SQLKomutCalistir", ssql);
            //}
        }

        private void OpenConnection()
        {
            if (!IsTransactional)
            {
                try
                {
                    cn.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private void CloseConnection()
        {
            if (!IsTransactional)
                cn.Close();
        }

        private void LogWriteDataTable(DataTable dtOnce, DataTable dtSonra)
        {
            int IslemTuru = 0;
            DataRow drTemp;
            DataRow drTemp2;
            DSLog dsLog = new DSLog();
            int SilinenKayitSayisi = 0;
            for (int i = 0; i < dtOnce.Rows.Count; i++)
            {
                DSLog.LOGRow drLog = dsLog.LOG.NewLOGRow();
                drLog.OPDATE = DateTime.Now;
                drLog.IPADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress;
                drLog.TABLENAME = dtOnce.TableName;
                drLog.DETAIL = string.Empty;
                try
                {
                    drLog.MEMBERID = Convert.ToInt32(System.Web.HttpContext.Current.Session["__KullaniciID"]);
                }
                catch { }
                //State i kaydetmeden önceki halinden alırız                
                if (dtOnce.Rows[i].RowState == DataRowState.Added
                    || dtOnce.Rows[i].RowState == DataRowState.Deleted
                    || dtOnce.Rows[i].RowState == DataRowState.Modified)
                {
                    drTemp = null;
                    drTemp2 = null;
                    switch (dtOnce.Rows[i].RowState)
                    {
                        case DataRowState.Deleted:
                            SilinenKayitSayisi++;
                            IslemTuru = Log_Yapilan_Islem_Turu.Kayit_Silme.GetHashCode();
                            drTemp = dtOnce.Rows[i];    //Kaydetmeden önce; verileri kaybetmemek için
                            drTemp.RejectChanges();     //Verileri görebilmek için
                            for (int Kolonlar = 0; Kolonlar < dtOnce.Columns.Count - 1; Kolonlar++)
                            {
                                if (drTemp[Kolonlar] != null)
                                    drLog.DETAIL += dtOnce.Columns[Kolonlar].ColumnName + " =" + drTemp[Kolonlar].ToString() + "<br />";
                                else
                                    drLog.DETAIL += dtOnce.Columns[Kolonlar].ColumnName + " = null<br />";
                            }
                            break;
                        case DataRowState.Added:
                            IslemTuru = Log_Yapilan_Islem_Turu.Yeni_Kayit.GetHashCode();
                            drTemp = dtSonra.Rows[i - SilinenKayitSayisi];   //Kaydedildikten sonra; id leri alabilmek için
                            for (int Kolonlar = 0; Kolonlar < dtOnce.Columns.Count - 1; Kolonlar++)
                            {
                                if (drTemp[Kolonlar] != null)
                                    drLog.DETAIL += dtOnce.Columns[Kolonlar].ColumnName + " =" + drTemp[Kolonlar].ToString() + "<br />";
                                else
                                    drLog.DETAIL += dtOnce.Columns[Kolonlar].ColumnName + " = null<br />";
                            }
                            break;
                        case DataRowState.Modified:
                            bool degisenVarmi = false;
                            IslemTuru = Log_Yapilan_Islem_Turu.Kayit_Guncelleme.GetHashCode();
                            drTemp = dtSonra.Rows[i - SilinenKayitSayisi];   //Kaydedildikten sonra;

                            drTemp2 = dtOnce.Rows[i];    //Kaydetmeden önce; verileri kaybetmemek için
                            drTemp2.RejectChanges();     //Verileri görebilmek için
                            for (int Kolonlar = 0; Kolonlar < dtOnce.Columns.Count; Kolonlar++)
                            {
                                if (drTemp[Kolonlar].ToString() != drTemp2[Kolonlar].ToString())
                                {
                                    drLog.DETAIL += "<b>" + dtOnce.Columns[Kolonlar].ColumnName + " Yeni Hali</b> =" + drTemp[Kolonlar].ToString() + " <b>Eski Hali</b> =" + drTemp2[Kolonlar].ToString() + "<br />";
                                    degisenVarmi = true;
                                }
                            }
                            if (!degisenVarmi)
                                continue;
                            break;
                    }
                    drLog.OPERATIONTYPE = IslemTuru;
                    dsLog.LOG.AddLOGRow(drLog);
                }
            }
            #region logu kaydet
            SqlDataAdapter da = new SqlDataAdapter("Select * from Log", cn);
            if (this.IsTransactional) da.SelectCommand.Transaction = oTransaction;
            try
            {
                SqlCommandBuilder builder1 = new SqlCommandBuilder(da);
                da.Update(dsLog.LOG);
            }
            catch (Exception e)
            {
                throw HataOlustur(e, "Select * from Log");
            }
            #endregion
        }

        private void SaveCommandLog(string SQL)
        {
            DSLog dsLog = new DSLog();
            DSLog.LOGRow drLog = dsLog.LOG.NewLOGRow();
            drLog.OPDATE = DateTime.Now;
            drLog.DETAIL = SQL;
            drLog.IPADDRESS = System.Web.HttpContext.Current.Request.UserHostAddress;
            drLog.TABLENAME = "Sorgu";
            try
            {
                drLog.MEMBERID = Convert.ToInt32(System.Web.HttpContext.Current.Session["__KullaniciID"]);
            }
            catch { }
            drLog.OPERATIONTYPE = Convert.ToInt32(Log_Yapilan_Islem_Turu.Diger.GetHashCode());
            dsLog.LOG.AddLOGRow(drLog);

            #region logu kaydet
            SqlDataAdapter da = new SqlDataAdapter("Select * from Log", cn);
            if (this.IsTransactional) da.SelectCommand.Transaction = oTransaction;
            try
            {
                SqlCommandBuilder builder1 = new SqlCommandBuilder(da);
                da.Update(dsLog.LOG);
            }
            catch (Exception e)
            {
                throw HataOlustur(e, "Select * from Log");
            }
            #endregion
        }
    }
}
