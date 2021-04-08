using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFramework;

namespace Individual-Project-Data
{
    public class SportsblogContext : DbContext
    {
        public DbSet<Authors> Author { get; set; }
        public DbSet<Articles> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Sportsblog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    }
}
