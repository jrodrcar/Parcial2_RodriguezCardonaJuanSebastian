using Microsoft.EntityFrameworkCore;
using Parcial2_RodriguezCardonaJuanSebastian.Models.DAL.Entities;
using System.Diagnostics.Metrics;
using System.Net.Sockets;

namespace Parcial2_RodriguezCardonaJuanSebastian.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ticket> tickets { get; set; }

        //
    }
}
