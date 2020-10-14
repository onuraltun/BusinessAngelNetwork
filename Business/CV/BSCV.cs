using System;
using System.Collections.Generic;
using System.Text;
using DataService;

namespace Types.TypeDataSets
{
    public class BSCV
    {
        public void Kaydet(DSCV ds)
        {
            Data dc = new Data();
            dc.TopluVeriIsleme(ds);
        }

        public DSCV Getir_byRECID(System.Int32 param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where RECID=" + param;
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byMEMBER(System.Int32 param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where MEMBER=" + param;
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_bySurnameFirstname(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where SurnameFirstname='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byAddress(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Address='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byTelephone(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Telephone='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byMobile(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Mobile='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byFax(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Fax='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byEmail(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Email='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byNationality(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Nationality='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byDateofBirth(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where DateofBirth='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byGender(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Gender='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byDesiredEmployment(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where DesiredEmployment='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byMotherTongue(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where MotherTongue='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_bySocialSkills(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where SocialSkills='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byOrganisationalSkills(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where OrganisationalSkills='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byTechnicalSkills(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where TechnicalSkills='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byComputerSkills(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where ComputerSkills='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byArtisticSkills(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where ArtisticSkills='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byOtherSkills(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where OtherSkills='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byAdditionalInformation(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where AdditionalInformation='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byAnnexes(System.String param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where Annexes='" + param + "'";
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where CREATEDBY=" + param;
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byCREATIONDATE(System.DateTime param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where CREATIONDATE=" + param;
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byMODIFIEDBY(System.Int32 param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where MODIFIEDBY=" + param;
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public DSCV Getir_byMODIFICATIONDATE(System.DateTime param)
        {
            Data dc = new Data();
            DSCV ds = new DSCV(); string sql = @"Select * from CV where MODIFICATIONDATE=" + param;
            dc.VeriGetir<DSCV>(ref ds, sql);
            return ds;
        }
        public void Sil_byRECID(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where RECID=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMEMBER(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where MEMBER=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_bySurnameFirstname(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where SurnameFirstname=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byAddress(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Address=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byTelephone(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Telephone=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMobile(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Mobile=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byFax(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Fax=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byEmail(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Email=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byNationality(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Nationality=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byDateofBirth(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where DateofBirth=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byGender(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Gender=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byDesiredEmployment(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where DesiredEmployment=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMotherTongue(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where MotherTongue=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_bySocialSkills(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where SocialSkills=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byOrganisationalSkills(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where OrganisationalSkills=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byTechnicalSkills(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where TechnicalSkills=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byComputerSkills(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where ComputerSkills=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byArtisticSkills(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where ArtisticSkills=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byOtherSkills(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where OtherSkills=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byAdditionalInformation(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where AdditionalInformation=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byAnnexes(System.String param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where Annexes=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATEDBY(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where CREATEDBY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byCREATIONDATE(System.DateTime param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where CREATIONDATE=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMODIFIEDBY(System.Int32 param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where MODIFIEDBY=" + param;
            dc.SQLKomutCalistir(sql);
        }
        public void Sil_byMODIFICATIONDATE(System.DateTime param)
        {
            Data dc = new Data(); string sql = @"Delete from CV where MODIFICATIONDATE=" + param;
            dc.SQLKomutCalistir(sql);
        }
    }
}