using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using practices5_7.Models;

namespace practices5_7.Data
{
    public class peopleContext : DbContext
    {
        public peopleContext()
        {
        }

        public peopleContext (DbContextOptions<peopleContext> options)
            : base(options)
        {
        }

        public DbSet<practices5_7.Models.PeopleModel>? PeopleModel { get; set; }

        public DbSet<practices5_7.Models.Party>? Parties { get; set; }
    }
}
