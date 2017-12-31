using System;
using System.Collections.Generic;
using System.Text;
using HurriyetDemo.HurriyetDb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hurriyet.HurriyetDb.DataAccess.Concrete.EntityFramework
{
    public class HurriyetContext : DbContext
    {
        //public HurriyetContext(DbContextOptions<HurriyetContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             //optionsBuilder.UseNpgsql("User ID = postgres;Password=8515586189_Brk;Server=localhost;Port=5432;Database=HurriyetDemo;Integrated Security=true; Pooling=true;");
            //"Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1;Integrated Security=true;Pooling=true;"

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=HurriyetDb;User Id=postgres;Password=8515586189_Brk;Integrated Security=true;Pooling=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
