using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Celulan.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Celulan.Repository
{
    public class CelulaContext : DbContext
    {
        public CelulaContext(DbContextOptions<CelulaContext> options) : base(options) { }

        public DbSet<TabLider> Lideres { get; set; }
        public DbSet<TabMembro> Membros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabLider>().ToTable("TabLider");
            modelBuilder.Entity<TabMembro>().ToTable("TabMembro");
        }
    }
}
