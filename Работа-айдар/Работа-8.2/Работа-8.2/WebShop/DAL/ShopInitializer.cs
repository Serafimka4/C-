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
            var OkOperation = new List<Ok>
            {
                new Ok { Name = "Genshin", Amount = 5, Price = 10000, Description = "" },
                new Ok { Name = "Dota 2", Amount = 5, Price = 2500, Description = "" },
                new Ok { Name = "Doka 3", Amount = 5, Price = 3000, Description = "" },
                new Ok { Name = "Cyberpank", Amount = 5, Price = 3000, Description = "" },
                new Ok { Name = "CS-GO", Amount = 5, Price = 3000, Description = "" },
                new Ok { Name = "Kazahstan", Amount = 5, Price = 9999999, Description = "" }
            };
            OkOperation.ForEach(ok => context.OkOperation.Add(ok));

            var admins = new List<Admin>
            {   new Admin {Login = "mr_animals2", Password = "SpidnacknusBaf2"}
            };
            admins.ForEach(admin => context.Admins.Add(admin));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}