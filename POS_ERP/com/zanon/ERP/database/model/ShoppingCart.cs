using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.beans
{
    [Serializable]
    public class ShoppingCart
    {
        public int orderID {get;set;}
        public string shoppingGregDate {get;set;}
        public string shoppingHejriDate {get;set;}
        public CustomerBean  customer {get;set;}
        public CompanyBeans  company {get;set;}
        public List<ShoppingLineItemBean> items  {get;set;}
        public ShoppingCart ()
        {
            items = new List<ShoppingLineItemBean>();
        }
    }
}