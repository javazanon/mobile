using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class CustomerGroupBean
    {
        //SELECT     `tcust_grp`.`ID`,    `tcust_grp`.`COMP_ID`,    `tcust_grp`.`RNG_ID`,
        //`tcust_grp`.`NAME`,  `tcust_grp`.`LONG_NAME`, `tcust_grp`.`DESCR` FROM `pos`.`tcust_grp`;
        public int ID {get;set;}
        public int COMP_ID {get;set;}
        public int RNG_ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}
        public string DESCR {get;set;}
       public List<CustomerGroupBean> getAllCustomerGroups(string sql ,  Dictionary<string,string> parameters)
        {
            List<CustomerGroupBean> custGrpsDataSource = new List<CustomerGroupBean>();
            try
            {
              DataTable custGrpResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<custGrpResult.Rows.Count;i++)
                    {
                        CustomerGroupBean currBean = new CustomerGroupBean();
                        currBean.ID =  int.Parse(custGrpResult.Rows[i]["ID"].ToString());
                        currBean.COMP_ID =  int.Parse(custGrpResult.Rows[i]["COMP_ID"].ToString());
                        currBean.RNG_ID =  int.Parse(custGrpResult.Rows[i]["RNG_ID"].ToString());
                        currBean.NAME =  custGrpResult.Rows[i]["NAME"].ToString();
                        currBean.LONG_NAME =  custGrpResult.Rows[i]["LONG_NAME"].ToString();
                        currBean.DESCR =  custGrpResult.Rows[i]["DESCR"].ToString();
                        custGrpsDataSource.Add(currBean);
                    }
            }
            catch(Exception ex)
            {
            }
            return custGrpsDataSource ;
        }
    }
}