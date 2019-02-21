using Microsoft.EntityFrameworkCore;
using SharedLib.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using Connection = DbLib.DbPostgreSQL.Configuration.Configuration;

namespace DbLib.DbPostgreSQL.Context
{
    public class PostgreSqlContext: DbContext
    {
        public DbSet<ProductModel> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Connection.ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Task");

            modelBuilder.Entity<ProductModel>()
                .HasKey(x => x.Id);
                
            modelBuilder.HasPostgresExtension("uuid-ossp")
                   .Entity<ProductModel>()
                   .Property(e => e.Id)
                   .HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
