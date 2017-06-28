using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_ERP.com.zanon.ERP.config
{
    public class MaterialMovementTypeKeys
    {
        //1	1	100	استلام 	استلام بضاعة من مورد	1	1	2014-11-18 18:28:35
        //2	1	101	ارجاع	ارجاع بضاة للمورد	-1	1	2014-11-18 18:29:21
        //3	1	200	بيع	بيع للعميل	-1	1	2014-11-18 18:30:07
        //4	1	900	رصيد افتتاحى	رصيد افتتاحى اول السنة	1	1	2014-11-18 18:30:44
        //5	1	300	اهلاك تالف	اهلاك بضاعة تالفة	-1	1	2014-11-18 18:31:11
							
        public static int PURCHASE_ITEM_FROM_VENDOR = 1;
        public static int RETURN_ITEM_TO_VENDOR = 2;
        public static int ORDER = 3;
        public static int INITIAL_BALANCE = 4;
        public static int SCARP_ITEM = 5;
    }
}