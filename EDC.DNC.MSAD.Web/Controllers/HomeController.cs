using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EDC.DNC.MSAD.Web.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace EDC.DNC.MSAD.Web.Controllers
{
    public class HomeController : Controller
    {
        private string gatewayUri;

        public HomeController(IConfiguration configuration)
        {
            gatewayUri = $"http://{configuration["Gateway:IP"]}:{configuration["Gateway:Port"]}";
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(/*[FromServices]HttpClient httpClient*/)
        {
            //var result = httpClient.GetStreamAsync($"{gatewayUri}/api/clientservice/trace").GetAwaiter().GetResult();
            //ViewData["Message"] = $"Your request data result : {result}";

            string userName = this.User.Identity.Name;
            //string realName = this.User.FindFirst("RealName").Value;
            //string email = this.User.FindFirst("Email").Value;

            ViewData["Message1"] = $"Current User => {userName}";

            ViewData["Message2"] = $"AccessToken => { HttpContext.GetTokenAsync("access_token") }";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
