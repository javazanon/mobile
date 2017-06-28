using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.database;
using System.Data;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    [Serializable]
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
    }
}