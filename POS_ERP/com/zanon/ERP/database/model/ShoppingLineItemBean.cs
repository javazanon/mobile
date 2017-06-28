using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.beans
{
    [Serializable]
    public class ShoppingLineItemBean
    {
        public int Material_id {get;set;}
        public string Material_name {get;set;}
        public float qnty {get;set;}
        public float unit_price {get;set;}
        public float totla_before_deduction {get;set;}
        public float deduction {get;set;}
        public float totla_after_deduction {get;set;}
    }
}