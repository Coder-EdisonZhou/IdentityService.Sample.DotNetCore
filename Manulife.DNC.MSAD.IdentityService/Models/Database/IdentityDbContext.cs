using Microsoft.EntityFrameworkCore;

namespace Manulife.DNC.MSAD.IdentityService.Models
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LoginUser> LoginUsers { get; set; }
    }
}
