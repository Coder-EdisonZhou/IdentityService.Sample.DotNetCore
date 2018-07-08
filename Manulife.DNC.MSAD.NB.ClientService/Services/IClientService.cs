using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.NB.ClientService.Models;

namespace Manulife.DNC.MSAD.NB.ClientService.Services
{
    public interface IClientService
    {
        Client GetClientById(int _id);
    }
}
