using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.Models.ContactsModel;

namespace WebApplication1.Data
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("ec2-52-15-222-231.us-east-2.compute.amazonaws.com;user=ssaqueton;password=0712Ksl&");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Fname).IsRequired();
                entity.Property(e => e.Lname).IsRequired();
                entity.Property(e => e.Num).IsRequired();
            });

        }
    }
}
