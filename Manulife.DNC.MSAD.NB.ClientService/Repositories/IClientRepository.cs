using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.NB.ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.NB.ClientService.Repositories
{
    public interface IClientRepository : IRepository<Client, ClientDbContext>
    {
        Client GetClientById(int _personId);
    }
}
