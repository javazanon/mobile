using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MovementsBean
    {
        public int id {get;set;}
        public int cmp_id {get;set;}
        public string code {get;set;}
        public string name {get;set;}
        public string lng_name {get;set;}
        public int positive {get;set;}
        public int status {get;set;}
        public List<MovementsBean> getAllMovements(string sql ,  Dictionary<string,string> parameters)
        {
            List<MovementsBean> movemenetsDataSource = new List<MovementsBean>();
            try
            {
              DataTable currencyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<currencyResult.Rows.Count;i++)
                    {
                        MovementsBean movBean = new MovementsBean();
                        movBean.id =  int.Parse(currencyResult.Rows[i]["id"].ToString());
                        movBean.code =  currencyResult.Rows[i]["code"].ToString();
                        movBean.name =  currencyResult.Rows[i]["name"].ToString();
                        movBean.lng_name =  currencyResult.Rows[i]["lng_name"].ToString();
                        movBean.cmp_id =  int.Parse(currencyResult.Rows[i]["cmp_id"].ToString());
                        movBean.positive =  int.Parse(currencyResult.Rows[i]["positive"].ToString());
                        movBean.status =  int.Parse(currencyResult.Rows[i]["status"].ToString());
                        movemenetsDataSource.Add(movBean);
                    }
            }
            catch(Exception ex)
            {
            }
            return movemenetsDataSource ;
        } 
    }
}