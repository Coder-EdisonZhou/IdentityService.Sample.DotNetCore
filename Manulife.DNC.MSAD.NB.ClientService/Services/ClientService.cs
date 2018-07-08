using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.NB.ClientService.Models;
using Manulife.DNC.MSAD.NB.ClientService.Repositories;
using System;

namespace Manulife.DNC.MSAD.NB.ClientService.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository clientRepository;

        public ClientService(IClientRepository _clientRepository)
        {
            this.clientRepository = _clientRepository;
        }

        public Client GetClientById(int _id)
        {
            // simulate one exception here
            string s = null;
            s.ToString();

            var model = clientRepository.GetClientById(_id);

            return model;
        }

        public Client UpdateClientInfo(Client _person)
        {
            var model = GetClientById(_person.Id);
            model.Name = "Edison Chen";
            var newPerson = new Client()
            {
                Name = "Nichcolas Xie",
                Sex = "M"
            };
            // below is a simple transaction
            clientRepository.Insert(newPerson, false);
            clientRepository.Update(model);

            return newPerson;
        }
    }
}
