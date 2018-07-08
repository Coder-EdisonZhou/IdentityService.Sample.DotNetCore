using Exceptionless;
using Manulife.DNC.MSAD.Common.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.NB.ClientService.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        public ILogger Logger { get; }

        public LoginController(ILogger logger)
        {
            Logger = logger;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            Logger.Info($"User {id} Login Successfully. Time:{DateTime.Now.ToString()}", "Tag1", "Tag2");

            return "Login Success.";
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                string str = null;
                str.ToString();
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }

            return "Unknown Error!";
        }
    }
}
