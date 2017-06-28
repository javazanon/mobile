using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MeasureBean
    {
        public int id {get;set;}
        public string name {get;set;}
        public string long_name {get;set;}
        public string iso_code {get;set;}

        public List<MeasureBean> getAllMeasures(string sql ,  Dictionary<string,string> parameters)
        {
            List<MeasureBean> measureDataSource = new List<MeasureBean>();
            try
            {
              DataTable currencyResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<currencyResult.Rows.Count;i++)
                    {
                        MeasureBean measurBean = new MeasureBean();
                        measurBean.id =  int.Parse(currencyResult.Rows[i]["id"].ToString());
                        measurBean.name =  currencyResult.Rows[i]["name"].ToString();
                        measurBean.long_name =  currencyResult.Rows[i]["long_nme"].ToString();
                        measurBean.iso_code =  currencyResult.Rows[i]["iso_code"].ToString();
                        measureDataSource.Add(measurBean);
                    }
            }
            catch(Exception ex)
            {
            }
            return measureDataSource ;
        }
    }
}