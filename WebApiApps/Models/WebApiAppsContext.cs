using Microsoft.EntityFrameworkCore;

namespace WebApiApps.Models
{
    public class WebApiAppsContext : DbContext
    {
        public WebApiAppsContext(DbContextOptions<WebApiAppsContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
