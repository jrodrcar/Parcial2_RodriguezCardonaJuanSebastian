using Microsoft.EntityFrameworkCore;
using Parcial2_RodriguezCardonaJuanSebastian.DAL.Entities;
using System.Diagnostics.Metrics;
using System.Net.Sockets;

namespace Parcial2_RodriguezCardonaJuanSebastian.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ticket> tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ticket>().HasIndex(i => i.Id).IsUnique();

        }
    }
}
