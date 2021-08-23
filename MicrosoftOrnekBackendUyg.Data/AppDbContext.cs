using Microsoft.EntityFrameworkCore;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Data.Configurations;
using MicrosoftOrnekBackendUyg.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MicrosoftOrnekBackendUyg.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Fatura> Fatura { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FaturaConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1,2 }));
            modelBuilder.ApplyConfiguration(new FaturaSeed(new int[] { 1,2 }));
        }

    }
}
