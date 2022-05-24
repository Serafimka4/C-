using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int GoodID { get; set; }
        public int CustomerID { get; set; }
        public int AmountGood { get; set; }
        public virtual Good Good { get; set;}
        public virtual Customer Customer { get; set;}
    
    }
}