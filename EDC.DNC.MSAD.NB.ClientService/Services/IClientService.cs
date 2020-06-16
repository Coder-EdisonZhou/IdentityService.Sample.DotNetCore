using EDC.DNC.MSAD.Common;
using EDC.DNC.MSAD.NB.ClientService.Models;

namespace EDC.DNC.MSAD.NB.ClientService.Services
{
    public interface IClientService
    {
        Client GetClientById(int _id);
    }
}
