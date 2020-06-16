using EDC.DNC.MSAD.Common;
using EDC.DNC.MSAD.IdentityService.Models;

namespace EDC.DNC.MSAD.IdentityService.Services
{
    public interface ILoginUserService
    {
        bool Authenticate(string _userName, string _userPassword, out LoginUser loginUser);
    }
}
