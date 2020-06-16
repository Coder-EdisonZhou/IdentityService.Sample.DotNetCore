using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDC.DNC.MSAD.NB.ClientService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EDC.DNC.MSAD.NB.ClientService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ProductService productService;

        public ValuesController(ProductService _productService)
        {
            productService = _productService;
        }

        //[HttpGet("{type}")]
        //public async Task<string> Get(string type)
        //{
        //    var result = await productService.GetAllProductsAsync(type);

        //    return result;
        //}

        //private static int _count = 0;
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //_count++;
            //Console.WriteLine($"Get...{_count}");
            //if (_count <= 4)
            //{
            //    System.Threading.Thread.Sleep(5000);
            //}

            return new string[] { $"ClinetService: {DateTime.Now.ToString()} {Environment.MachineName} " +
                $"OS: {Environment.OSVersion.VersionString}" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            //var result = await productService.GetAllProductsAsync("B");
            string userName = this.User.Identity.Name;
            string realName = this.User.FindFirst("RealName").Value;
            string email = this.User.FindFirst("Email").Value;

            string result = $"Current User => {userName} : {realName} : {email}";

            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
