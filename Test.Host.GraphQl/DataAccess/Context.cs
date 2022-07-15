using DataAccess.Domain.GuaranteeItems;
using DataAccess.Domain.Guarantees;
using DayanaCore.Infrastructure.DataAccess;
using Domain.GuaranteeItems;
using Domain.Guarantees;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Context : CoreDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Guarantee> Guarantees { get; set; }
        public DbSet<GuaranteeItem> GuaranteeItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GuaranteeConfiguration());
            modelBuilder.ApplyConfiguration(new GuaranteeItemConfiguration());

            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.HasCollation("my_collation", locale: "en-u-ks-primary", provider: "icu");
            //modelBuilder.UseDefaultColumnCollation("my_collation");
            //modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
        }

    }
}
