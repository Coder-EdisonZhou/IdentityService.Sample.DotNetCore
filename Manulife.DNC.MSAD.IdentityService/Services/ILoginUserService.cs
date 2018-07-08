using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.IdentityService.Models;

namespace Manulife.DNC.MSAD.IdentityService.Services
{
    public interface ILoginUserService
    {
        bool Authenticate(string _userName, string _userPassword, out LoginUser loginUser);
    }
}
