using Microsoft.EntityFrameworkCore;
using SistemaChamados.Models;

namespace SistemaChamados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(t => t.Status)
                      .HasConversion<string>()
                      .HasMaxLength(20);

                
                entity.Property(t => t.Priority)
                      .HasConversion<string>()
                      .HasMaxLength(20);
            });
        }
    }
}
