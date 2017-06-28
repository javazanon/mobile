using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POS_ERP.com.zanon.ERP.database;
using POS_ERP.com.zanon.ERP.logging;
using POS_ERP.com.zanon.ERP.database.connection;

namespace POS_ERP.com.zanon.ERP.beans
{
    public class materialGroupBean
    {
        public int ID {get;set;}
        public int CMP_ID {get;set;}
        public string NAME {get;set;}
        public string LONG_NAME {get;set;}
        public int RANGE_ID {get;set;}
    }
}