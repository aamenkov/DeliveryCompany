using DeliveryCompanyData.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompanyDataAccessEF.Context
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options) {}

        public DbSet<Application> Application { get; set; }
        public DbSet<Department> Department { get; set; }

    }
}
