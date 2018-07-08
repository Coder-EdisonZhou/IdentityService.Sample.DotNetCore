using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Manulife.DNC.MSAD.NB.ClientService.Controllers
{
    [Route("api/Trace")]
    public class TraceController : Controller
    {
        private string gatewayUri;

        public TraceController(IConfiguration configuration)
        {
            gatewayUri = $"http://{configuration["Gateway:IP"]}:{configuration["Gateway:Port"]}";
        }

        [HttpGet]
        public string Get([FromServices]HttpClient httpClient)
        {
            var result = httpClient.GetStringAsync($"{gatewayUri}/api/productservice/values").GetAwaiter().GetResult();

            return $"ProductService AccessTime: {DateTime.Now.ToString()}, Result: {result}";
        }
    }
}