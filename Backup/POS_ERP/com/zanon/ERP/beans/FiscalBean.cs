using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class FiscalBean
    {
        public int id {get;set;}
        public int cmp_id {get;set;}
        public int year {get;set;}
        public string name {get;set;}

        public int getIDForYear(int year)
        {
            int foundID = -1 ;
            try
            {
              string sql =" select id from pos.tfiscal_yr where year = @year and status = 1 ";
              Dictionary<string,string> parameters = new Dictionary<string,string>();
              parameters.Add("@year",year+"");
              DataTable Result = new ConnectionManager().select(sql,parameters);
               foundID = int.Parse(Result.Rows[0]["id"].ToString());
            }
            catch(Exception ex)
            {
            }
            return foundID ;
        }
    }
}