using EDC.DNC.MSAD.Common;
using EDC.DNC.MSAD.IdentityService.Models;

namespace EDC.DNC.MSAD.IdentityService.Repositories
{
    public interface ILoginUserRepository : IRepository<LoginUser, IdentityDbContext>
    {
        LoginUser Authenticate(string _userName, string _userPassword);
    }
}
