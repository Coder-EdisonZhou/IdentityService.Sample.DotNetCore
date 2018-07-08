using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.NB.ClientService.Models;
using System.Linq;

namespace Manulife.DNC.MSAD.NB.ClientService.Repositories
{
    public class ClientRepository : RepositoryBase<Client, ClientDbContext>, IClientRepository
    {
        public ClientRepository(ClientDbContext dbContext) : base(dbContext)
        {
        }

        public Client GetClientById(int _personId)
        {
            var entity = DbContext.Clients.FirstOrDefault(p => p.Id == _personId);
            return entity;
        }
    }
}
