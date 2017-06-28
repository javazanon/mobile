using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class DeliveryMethodBean
    {
         // SELECT`tdlvr_mthod`.`ID`,`tdlvr_mthod`.`NAME`,`tdlvr_mthod`.`LONG_NAME` 
        //FROM `pos`.`tdlvr_mthod`;

        public int ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}

         public List<DeliveryMethodBean> getAllDeliveryMethod(string sql ,  Dictionary<string,string> parameters)
        {
            List<DeliveryMethodBean> deliveryMethodDataSource = new List<DeliveryMethodBean>();
            try
            {
              DataTable deliveryMethodResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<deliveryMethodResult.Rows.Count;i++)
                    {
                        DeliveryMethodBean deliveryBean = new DeliveryMethodBean();
                        deliveryBean.ID =  int.Parse(deliveryMethodResult.Rows[i]["ID"].ToString());
                        deliveryBean.NAME =  deliveryMethodResult.Rows[i]["NAME"].ToString();
                        deliveryBean.LONG_NAME =  deliveryMethodResult.Rows[i]["LONG_NAME"].ToString();
                        deliveryMethodDataSource.Add(deliveryBean);
                    }
            }
            catch(Exception ex)
            {
            }
            return deliveryMethodDataSource ;
        }
    }
}