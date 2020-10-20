namespace Pavilions.dataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context4")
        {
        }

        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<ShoppingCenter> ShoppingCenter { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Pavilions> Pavilions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCenter>()
                .HasMany(e => e.Pavilions)
                .WithRequired(e => e.ShoppingCenter)
                .WillCascadeOnDelete(false);
        }
    }
}
