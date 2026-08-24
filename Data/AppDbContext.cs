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
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(t => t.Status)
                      .HasConversion<string>()
                      .HasMaxLength(20);

                entity.Property(t => t.Priority)
                      .HasConversion<string>()
                      .HasMaxLength(20);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tickets)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Department)
                      .WithMany(d => d.Tickets)
                      .HasForeignKey(t => t.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasOne(u => u.Department)
                      .WithMany(d => d.Users)
                      .HasForeignKey(u => u.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments");

                entity.Property(d => d.Sector)
                    .HasConversion<string>()
                    .HasMaxLength(30);

                entity.HasData(
                    new Department { Id = 1, Sector = Sectors.Ti },
                    new Department { Id = 2, Sector = Sectors.Vendas },
                    new Department { Id = 3, Sector = Sectors.Financeiro },
                    new Department { Id = 4, Sector = Sectors.Rh },
                    new Department { Id = 5, Sector = Sectors.Producao },
                    new Department { Id = 6, Sector = Sectors.Gerencia },
                    new Department { Id = 7, Sector = Sectors.Layout }
                );
            });
        }
    }
}