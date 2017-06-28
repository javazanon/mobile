using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.config;
using POS_ERP.com.zanon.ERP.database.connection;
using POS_ERP.com.zanon.ERP.database.model;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MaterialBean : GUI_DDL_Bean
    {
        public int ID {get;set;}
        public int COMP_ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}
        public int GRP_ID {get;set;}
        public int MEASURE {get;set;}
        public float MRP_LOW {get;set;}
        public float MRP_HIGH {get;set;}
        public DateTime CREATE_DATE {get;set;}
    }
}