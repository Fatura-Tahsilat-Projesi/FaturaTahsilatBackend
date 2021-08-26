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

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceActivity> InvoiceActivities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }


        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<InvoiceActivity>()
            //   .HasOne(s => s.Invoice)
            //   .WithMany(c => c.InvoiceActivities)
            //   .HasForeignKey(s => new { s.CompanyId, s.UserId, s.InvoiceId });

            //modelBuilder.Entity<Invoice>().HasMany(i => i.Invoice).WithRequired().WillCascadeOnDelete(false);


            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            
            modelBuilder.ApplyConfiguration(new InvoiceActivityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());


            //modelBuilder.Entity<InvoiceActivity>()
            //   .HasOne(s => s.Invoice)
            //   .WithMany(c => c.InvoiceActivities)
            //   .HasForeignKey(s => new { s.CompanyId, s.UserId, s.InvoiceId });


            //modelBuilder.Entity<InvoiceActivity>()
            //   .HasOne(s => s.Invoice)
            //   .WithMany(c => c.RecordOfInvoiceActivity)
            //   .HasForeignKey(s => new { s.CompanyId, s.UserId, s.InvoiceId });

            //modelBuilder.Entity<Invoice>().HasMany(i => i.Invoice).WithRequired().WillCascadeOnDelete(false);




            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1,2 }));

            //modelBuilder.ApplyConfiguration(new InvoiceSeed(new int[] { 1,2 }));
        }

    }
}
