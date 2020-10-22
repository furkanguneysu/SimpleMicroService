using Microsoft.EntityFrameworkCore;
using SimpleMicroservice.UserService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMicroservice.UserService.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-0TARDM2; initial catalog = SimpleMicroservice.UserService;persist security info=True;user id=sa; password=dotnettricks");
        }
    }
}
