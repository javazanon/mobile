using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;

namespace POS_ERP.com.zanon.ERP.beans
{
    [Serializable]
    public class CustomerBean
    {
        //SELECT //`tcustomer`.`ID`,`tcustomer`.`COMP_ID`,`tcustomer`.`GRP_ID`,`tcustomer`.`NAME`,
        //`tcustomer`.`LONG_NAME`,`tcustomer`.`DESC`,`tcustomer`.`COUNTERY`,`tcustomer`.`ADDRESS`,
        //`tcustomer`.`OWNER`,`tcustomer`.`PHONE`,`tcustomer`.`STATUS`,`tcustomer`.`CREATE_DATE`        
         NLogLogger myLog = new NLogLogger();
        public int ID {get;set;}
        public int COMP_ID {get;set;}
        public int GRP_ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}
        public string DESC {get;set;}
        public int COUNTERY {get;set;}
        public string ADDRESS {get;set;}
        public string OWNER {get;set;}
        public string PHONE {get;set;}
        public int STATUS {get;set;}
        public DateTime CREATE_DATE {get;set;}

        public List<CustomerBean> getAllCustomer(string sql ,  Dictionary<string,string> parameters)
        {
            List<CustomerBean> customerDataSource = new List<CustomerBean>();
            try
            {
              DataTable customerResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<customerResult.Rows.Count;i++)
                    {
                        CustomerBean custBean = new CustomerBean();
                        custBean.ID =  int.Parse(customerResult.Rows[i]["ID"].ToString());
                        custBean.COMP_ID =  int.Parse(customerResult.Rows[i]["COMP_ID"].ToString());
                        custBean.GRP_ID =  int.Parse(customerResult.Rows[i]["GRP_ID"].ToString());
                        custBean.NAME =  customerResult.Rows[i]["NAME"].ToString();
                        custBean.LONG_NAME =  customerResult.Rows[i]["LONG_NAME"].ToString();
                        custBean.DESC =  customerResult.Rows[i]["DESC"].ToString();
                        custBean.COUNTERY =  int.Parse(customerResult.Rows[i]["COUNTERY"].ToString());
                        custBean.ADDRESS =  customerResult.Rows[i]["ADDRESS"].ToString();
                        custBean.OWNER =  customerResult.Rows[i]["OWNER"].ToString();
                        custBean.PHONE =  customerResult.Rows[i]["PHONE"].ToString();
                        custBean.STATUS =  int.Parse(customerResult.Rows[i]["STATUS"].ToString());
                        customerDataSource.Add(custBean);
                    }
            }
            catch(Exception ex)
            {
                 myLog.Error(ex);
            }
            return customerDataSource ;
        }

       public CustomerBean getCustomerByID(int id)
        {
            CustomerBean customerDataSource = new CustomerBean();
            try
            {
                string sql = " select * from pos.tcustomer where ID=@ID" ;
                Dictionary<string,string> parameter = new   Dictionary<string,string>(); 
                parameter.Add("@ID",id+"");
                List<CustomerBean> result = getAllCustomer(sql,parameter);
                customerDataSource = result[0];
            }
            catch(Exception ex)
            {
               myLog.Error(ex);
            }
            return customerDataSource ;
        }
    }
}