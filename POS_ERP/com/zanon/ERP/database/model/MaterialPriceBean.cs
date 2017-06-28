using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MaterialPriceBean
    {
        public int ID {get;set;}
        public int MATER_ID {get;set;}
        public float PRICE {get;set;}
        public int CURRENCY {get;set;}
        public DateTime FROMDATE {get;set;}
        public DateTime TODATE {get;set;}
        public DateTime CREATE_DATE {get;set;}

        public List<MaterialPriceBean> getAllMaterialPrices(string sql ,  Dictionary<string,string> parameters)
        {
            List<MaterialPriceBean> materialPriceDataSource = new List<MaterialPriceBean>();
            try
            {
              DataTable pricesResult = new ConnectionManager().select(sql,parameters);
                 for(int i=0;i<pricesResult.Rows.Count;i++)
                    {
                        MaterialPriceBean matrPriceBean = new MaterialPriceBean();
                        matrPriceBean.ID =  int.Parse(pricesResult.Rows[i]["ID"].ToString());
                        matrPriceBean.MATER_ID =  int.Parse(pricesResult.Rows[i]["MATER_ID"].ToString());
                        matrPriceBean.PRICE =  float.Parse(pricesResult.Rows[i]["PRICE"].ToString());
                        matrPriceBean.CURRENCY =  int.Parse(pricesResult.Rows[i]["CURRENCY"].ToString());
                        matrPriceBean.FROMDATE =  DateTime.Parse(pricesResult.Rows[i]["FROMDATE"].ToString());
                        matrPriceBean.TODATE =  DateTime.Parse(pricesResult.Rows[i]["TODATE"].ToString());
                        matrPriceBean.CREATE_DATE =  DateTime.Parse(pricesResult.Rows[i]["CREATE_DATE"].ToString());
                        materialPriceDataSource.Add(matrPriceBean);
                    }
            }
            catch(Exception ex)
            {
            }
            return materialPriceDataSource ;
        }

        public  MaterialPriceBean getCurrentMaterialPrices(int materialID)
        {
           MaterialPriceBean materialPriceDataSource = new MaterialPriceBean();
            try
            {
                string currentDate = DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day;
                 string sql = " select * from pos.tmater_prce where MATER_ID = @material_id and FROMDATE < @FROMDATE and TODATE > @TODATE";
                 Dictionary<string,string> parameters  = new Dictionary<string,string>();
                 parameters.Add("@material_id",materialID+"");
                 parameters.Add("@FROMDATE",currentDate);
                 parameters.Add("@TODATE",currentDate);
                List<MaterialPriceBean> result =  getAllMaterialPrices(sql,parameters);
                materialPriceDataSource = result[0];
            }
            catch(Exception ex)
            {
            }
            return materialPriceDataSource ;
        }
    }
}