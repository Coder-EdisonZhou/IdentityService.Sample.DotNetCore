using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDC.DNC.MSAD.IdentityService.Models
{
    public class LoginRequestParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
    }
}
