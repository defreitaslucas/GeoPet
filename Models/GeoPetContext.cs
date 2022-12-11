using Microsoft.EntityFrameworkCore;

namespace GeoPet.Models
{
    public class GeoPetContext : DbContext
    {
        public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options) { }
        public GeoPetContext() { }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetCarer> PetCarers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=pets;User=SA;Password=Password12!;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetCarer>().HasKey(p => p.PetCarerId);
            modelBuilder.Entity<Pet>().HasKey(p => p.PetId);
            modelBuilder.Entity<Pet>()
                .HasOne<PetCarer>(p => p.PetCarerId)
                .WithMany(p => p.PetId)
                .HasForeignKey(p => p.PetId);
        }
    }
}