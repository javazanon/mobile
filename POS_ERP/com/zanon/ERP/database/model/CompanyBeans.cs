using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS_ERP.com.zanon.ERP.database;
using System.Data;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class CompanyBeans
    {

        //SELECT `tcompany`.`id`,`tcompany`.`cmp_code`,`tcompany`.`cmp_nme`,`tcompany`.`cmp_lng_nme`,
        //`tcompany`.`address`,`tcompany`.`create_date`,`tcompany`.`telephone`,`tcompany`.`mobile`
        //FROM `pos`.`tcompany`;
         NLogLogger myLog = new NLogLogger();
        public int id {get;set;}
        public string cmp_code {get;set;}
        public string cmp_nme {get;set;}
        public string cmp_lng_nme {get;set;}
        public string address {get;set;}
        public string telephone {get;set;}
        public string mobile {get;set;}


        public List<CompanyBeans> getAllCompany(string sql ,  Dictionary<string,string> parameters)
        {
            List<CompanyBeans> companyDataSource = new List<CompanyBeans>();
            try
            {
              DataTable companyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<companyResult.Rows.Count;i++)
                    {
                        CompanyBeans compBean = new CompanyBeans();
                        compBean.id =  int.Parse(companyResult.Rows[i]["id"].ToString());
                        compBean.cmp_code =  companyResult.Rows[i]["cmp_code"].ToString();
                        compBean.cmp_nme =  companyResult.Rows[i]["cmp_nme"].ToString();
                        compBean.cmp_lng_nme =  companyResult.Rows[i]["cmp_lng_nme"].ToString();
                        compBean.address =  companyResult.Rows[i]["address"].ToString();
                        compBean.telephone =  companyResult.Rows[i]["telephone"].ToString();
                        compBean.mobile =  companyResult.Rows[i]["mobile"].ToString();
                        companyDataSource.Add(compBean);
                    }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return companyDataSource ;
        }

       public CompanyBeans getCompanyByID(int id)
        {
            CompanyBeans companyDataSource = new CompanyBeans();
            try
            {
                string sql = " select * from pos.tcompany where id=@ID" ;
                Dictionary<string,string> parameter = new   Dictionary<string,string>(); 
                parameter.Add("@ID",id+"");
                List<CompanyBeans> result = getAllCompany(sql,parameter);
                companyDataSource = result[0];
            }
            catch(Exception ex)
            {
               myLog.Error(ex);
            }
            return companyDataSource ;
        }

    }
}