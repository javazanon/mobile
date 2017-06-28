using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class FiscalPeriodBean
    {
        public int period_id {get;set;}
        public string code {get;set;}
        public string name {get;set;}
        public int fyear {get;set;}
        public string long_nme {get;set;}
        public DateTime start_from {get;set;}
        public DateTime end_to {get;set;}


        public int getIDForCurrentfiscalPeriod()
        {
            int foundID = -1 ;
            try
            {
              string mydate = DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day ;
              string currentYear = DateTime.Now.Year+"";
              string sql =" SELECT * FROM pos.tfiscal_prid where start_from <= @mydate and end_to >= @mydate " +
                          " and fyear in (select id from pos.tfiscal_yr where year = @year)";
              Dictionary<string,string> parameters = new Dictionary<string,string>();
              parameters.Add("@year",currentYear);
              parameters.Add("@mydate",mydate);
              DataTable Result = new ConnectionManager().select(sql,parameters);
               foundID = int.Parse(Result.Rows[0]["period_id"].ToString());
            }
            catch(Exception ex)
            {
            }
            return foundID ;
        }
    }
}