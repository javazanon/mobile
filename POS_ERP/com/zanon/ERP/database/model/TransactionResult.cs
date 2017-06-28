using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.database.model
{
    [Serializable]
    public class TransactionResult
    {
        public string msg { get; set; }
        public string val { get; set; }
        public bool status { get; set; }
    }
}