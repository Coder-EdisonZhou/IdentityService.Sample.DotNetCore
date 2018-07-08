using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.IdentityService.Models;

namespace Manulife.DNC.MSAD.IdentityService.Repositories
{
    public interface ILoginUserRepository : IRepository<LoginUser, IdentityDbContext>
    {
        LoginUser Authenticate(string _userName, string _userPassword);
    }
}
