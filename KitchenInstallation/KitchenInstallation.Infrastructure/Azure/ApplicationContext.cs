namespace KitchenInstallation.Infrastructure.Azure
{
    using Entities.Details;
    using Microsoft.EntityFrameworkCore;

    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Tabletop> Tabletops { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
