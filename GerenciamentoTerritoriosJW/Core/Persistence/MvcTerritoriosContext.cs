using GerenciamentoTerritoriosJW.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTerritoriosJW.Core.Persistence
{
    public class MvcTerritoriosContext : DbContext
    {
        public DbSet<Direction> Directions { get; set; }
        public IConfiguration Configuration { get; }

        public MvcTerritoriosContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("MvcTerritoriosContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.DirectionId);
                entity.Property(e => e.StreetName).IsRequired();
                entity.Property(e => e.HouseNumber).IsRequired();
                entity.Property(e => e.CardNumber).IsRequired();
            });
        }
    }
}
