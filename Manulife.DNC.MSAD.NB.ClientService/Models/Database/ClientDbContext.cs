using Microsoft.EntityFrameworkCore;

namespace Manulife.DNC.MSAD.NB.ClientService.Models
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
