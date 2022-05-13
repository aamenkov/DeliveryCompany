using DeliveryCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.DataAccessEF.Context
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options) {}

        public DbSet<Application> Application { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().Property(u => u.Weight).HasDefaultValue(0);
            modelBuilder.Entity<Application>().Property(u => u.Length).HasDefaultValue(0);
            modelBuilder.Entity<Application>().Property(u => u.Width).HasDefaultValue(0);
            modelBuilder.Entity<Application>().Property(u => u.Height).HasDefaultValue(0);
            modelBuilder.Entity<Application>().Property(u => u.Volume).HasDefaultValue(0);

            modelBuilder.Entity<Application>()
                .Property(u => u.Volume)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Application>().Property(u => u.Status).HasDefaultValue("Новая");
            modelBuilder.Entity<Application>().Property(u => u.Message).HasDefaultValue("OK");
        }
    }
}
