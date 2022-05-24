using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;
using System.Data.Entity;


namespace WebShop.DAL
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var goods = new List<Good>
            {
                new Good { Name = "Стол", Amount = 10, Price = 8000, Description = "" },
                new Good { Name = "Стул", Amount = 78, Price = 1200, Description = "" },
                new Good { Name = "Шкаф", Amount = 6, Price = 34000, Description = "" },
                new Good { Name = "Табуретка", Amount = 242, Price = 345, Description = "" }
            };
            goods.ForEach(good => context.Goods.Add(good));

            var admins = new List<Admin>
            {   
                new Admin {Login = "qwerty", Password = "1234"}
            };
            admins.ForEach(admin => context.Admins.Add(admin));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}