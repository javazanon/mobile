using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.database.connection;
using POS_ERP.com.zanon.ERP.database.model;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class MovementsBean : GUI_DDL_Bean
    {
        public int id {get;set;}
        public int cmp_id {get;set;}
        public string code {get;set;}
        public string name {get;set;}
        public string lng_name {get;set;}
        public int positive {get;set;}
        public int status {get;set;}
       
    }
}