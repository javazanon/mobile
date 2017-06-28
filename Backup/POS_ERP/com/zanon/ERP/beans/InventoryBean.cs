using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class InventoryBean
    {
        public int id {get;set;}
        public int cmp_id {get;set;}
        public string strg_name {get;set;}
        public string long_nme {get;set;}
        public string desc {get;set;}
        public string address {get;set;}
        NLogLogger myLog= new NLogLogger();
       private List<InventoryBean> getAllInventory(string sql ,  Dictionary<string,string> parameters)
        {
            List<InventoryBean> inevntory_dataSource = new List<InventoryBean>();
            try
            {
              DataTable currencyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<currencyResult.Rows.Count;i++)
                    {
                        InventoryBean invent_Bean = new InventoryBean();
                        invent_Bean.id =  int.Parse(currencyResult.Rows[i]["id"].ToString());
                        invent_Bean.cmp_id = int.Parse(currencyResult.Rows[i]["cmp_id"].ToString());
                        invent_Bean.strg_name =  currencyResult.Rows[i]["strg_name"].ToString();
                        invent_Bean.long_nme =  currencyResult.Rows[i]["long_nme"].ToString();
                        invent_Bean.desc =  currencyResult.Rows[i]["desc"].ToString();
                        invent_Bean.address =  currencyResult.Rows[i]["address"].ToString();
                        inevntory_dataSource.Add(invent_Bean);
                    }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return inevntory_dataSource ;
        }

         public List<InventoryBean> getAllInventoryUnderCompany(string cmpID)
        {
            List<InventoryBean> inevntory_dataSource = new List<InventoryBean>();
            try
            {
                string sql = " select * from pos.tinventory where cmp_id  = @cmp_id ";
                Dictionary<string,string> parameters  = new Dictionary<string,string>();
                parameters.Add("@cmp_id",cmpID);
                inevntory_dataSource = getAllInventory(sql,parameters);
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return inevntory_dataSource ;
        }

        
    }
}