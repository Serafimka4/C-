using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Good
    {
        public int GoodID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Purchase> Purchases { set; get; }

    }
}