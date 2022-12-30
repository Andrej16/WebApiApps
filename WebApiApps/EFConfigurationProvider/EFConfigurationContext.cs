using Microsoft.EntityFrameworkCore;
using WebApiApps.Models;

namespace WebApiApps.EFConfigurationProvider
{
    public class EFConfigurationContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "conf";

        public EFConfigurationContext(DbContextOptions<EFConfigurationContext> options)
            : base(options)
        {
        }

        public DbSet<EFConfigurationValue> Values => Set<EFConfigurationValue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
        }
    }
}