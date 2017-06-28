using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.database;
using System.Data;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class NumberRangeBeans
    {
        //SELECT`tnumb_rng`.`ID`,`tnumb_rng`.`CMP_ID`,`tnumb_rng`.`rng_id`,`tnumb_rng`.`from`,`tnumb_rng`.`to`,`tnumb_rng`.`current`,
         //`tnumb_rng`.`obj_id`FROM `pos`.`tnumb_rng`;
        public int ID {get;set;}
        public int CMP_ID {get;set;}
        public int rng_id {get;set;}
        public int from {get;set;}
        public int to {get;set;}
        public int current {get;set;}
        public int obj_id {get;set;}
        NLogLogger myLog = new NLogLogger(); 
        public int getNextNumberInRange(int rng_id)
        {
            int nextID = -1 ;
            try
            {
                string sql = " select *  from pos.tnumb_rng where ID =@rng_id  ";
                Dictionary<string,string> parameters  = new Dictionary<string,string>();
                parameters.Add("@rng_id",rng_id+"");

                DataTable result = new ConnectionManager().select(sql,parameters);
                if(result.Rows.Count>0)
                {
                    int id= int.Parse(result.Rows[0]["ID"].ToString());
                    int toRange = int.Parse(result.Rows[0]["to"].ToString());
                    int current = int.Parse(result.Rows[0]["current"].ToString());
                    int tempID= current+1;
                    if(tempID <= toRange)
                    {
                        sql = " update pos.tnumb_rng set current = @current where ID = @ID";
                         parameters  = new Dictionary<string,string>();
                         parameters.Add("@ID",id+"");
                        parameters.Add("@current",tempID+"");
                        int dbStatus = new ConnectionManager().insertDeleteUpdate(sql,parameters);
                        if(dbStatus==1)
                        {
                            nextID = tempID ;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                myLog.Error(ex);
            }
            return nextID ;
        }
    }
}