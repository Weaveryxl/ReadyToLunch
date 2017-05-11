using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Data
{
    public class LunchContext : DbContext
    {
        public LunchContext() : base("LunchContext")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CartItem> Cart { get; set; }
        public DbSet<CartItemBase> CartItemBases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<QuestionConcept>().HasKey(qc => new {qc.QuestionId, qc.ConceptId});

        }

        //public override int SaveChanges()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IAuditableEntity
        //                    &&
        //                    (x.State == EntityState.Added ||
        //                     x.State == EntityState.Modified));

        //    foreach (var entry in modifiedEntries)
        //    {
        //        IAuditableEntity entity = entry.Entity as IAuditableEntity;
        //        if (entity != null)
        //        {
        //            string identityName = Thread.CurrentPrincipal.Identity.Name;
        //            DateTime now = DateTime.Now;

        //            if (entry.State == System.Data.Entity.EntityState.Added)
        //            {
        //                entity.CreatedBy = identityName;
        //                entity.CreatedDate = now;
        //            }
        //            else
        //            {
        //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //            }

        //            entity.UpdatedBy = identityName;
        //            entity.UpdatedDate = now;
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}