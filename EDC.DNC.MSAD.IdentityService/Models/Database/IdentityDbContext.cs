using Microsoft.EntityFrameworkCore;

namespace EDC.DNC.MSAD.IdentityService.Models
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LoginUser> LoginUsers { get; set; }
    }
}
