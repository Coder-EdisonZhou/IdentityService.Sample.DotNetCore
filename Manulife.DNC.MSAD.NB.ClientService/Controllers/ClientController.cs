using EasyNetQ;
using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.Messages;
using Manulife.DNC.MSAD.NB.ClientService.Models;
using Manulife.DNC.MSAD.NB.ClientService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.NB.ClientService.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly IBus bus;

        public ClientController(IClientService _clientService, IBus _bus)
        {
            clientService = _clientService;
            bus = _bus;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var client = clientService.GetClientById(id);

            return Json(client);
        }

        [HttpPost]
        public async Task<string> Post([FromBody]ClientDTO clientDto)
        {
            // Business Logic here...
            // eg.Add new client to your service databases via EF
            // Sample Publish
            ClientMessage message = new ClientMessage
            {
                ClientId = clientDto.Id.Value,
                ClientName = clientDto.Name,
                Sex = clientDto.Sex,
                Age = 29,
                SmokerCode = "N",
                Education = "Master",
                YearIncome = 100000
            };
            await bus.PublishAsync(message);

            return "Add Client Success! You will receive some letter later.";
        }
    }
}