using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class CurrencyBean
    {
        public int ID {get;set;}
        public string CODE {get;set;}
        public string NAME {get;set;}
        public int COUNTERY {get;set;}

        public List<CurrencyBean> getAllCurrency(string sql ,  Dictionary<string,string> parameters)
        {
            List<CurrencyBean> currencyDataSource = new List<CurrencyBean>();
            try
            {
              DataTable currencyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<currencyResult.Rows.Count;i++)
                    {
                        CurrencyBean currBean = new CurrencyBean();
                        currBean.ID =  int.Parse(currencyResult.Rows[i]["ID"].ToString());
                        currBean.NAME =  currencyResult.Rows[i]["NAME"].ToString();
                        currBean.CODE =  currencyResult.Rows[i]["CODE"].ToString();
                        currBean.COUNTERY =  int.Parse(currencyResult.Rows[i]["COUNTERY"].ToString());
                        currencyDataSource.Add(currBean);
                    }
            }
            catch(Exception ex)
            {
            }
            return currencyDataSource ;
        }
    }
}