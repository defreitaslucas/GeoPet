using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeoPet.Models
{
    public class GeoPetContext : DbContext
    {
        public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options) { }
        public GeoPetContext() { }

        public DbSet<PetCarer> Pets { get; set; }
        public DbSet<PetCarer> PetCarers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=127.0.0.1;Database=geopet_db;User=SA;Password=Password12!";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            // executa o metodo UseSqlServer e passa a connection string a ele
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
