using Microsoft.EntityFrameworkCore;
using PlatformService.API.Models;

namespace PlatformService.API.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
