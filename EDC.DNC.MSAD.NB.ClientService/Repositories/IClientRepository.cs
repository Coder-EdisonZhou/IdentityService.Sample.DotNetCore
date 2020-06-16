using EDC.DNC.MSAD.Common;
using EDC.DNC.MSAD.NB.ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDC.DNC.MSAD.NB.ClientService.Repositories
{
    public interface IClientRepository : IRepository<Client, ClientDbContext>
    {
        Client GetClientById(int _personId);
    }
}
