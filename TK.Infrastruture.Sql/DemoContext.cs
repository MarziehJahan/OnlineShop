using Microsoft.EntityFrameworkCore;
using System;
using TK.Core.Entites;
using TK.Infrastruture.Sql.Config;

namespace TK.Infrastruture.Sql
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new DealerConfig());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Media> Medias { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
    }
}
