using Microsoft.EntityFrameworkCore;

namespace API.MiddleLayer
{
    public class CustomerDB : DbContext
    {
        public CustomerDB(DbContextOptions<CustomerDB> options)
        : base(options) { }

        public DbSet<CustomerBase> User => Set<CustomerBase>();
    }
}
