using EDC.DNC.MSAD.Common;
using EDC.DNC.MSAD.IdentityService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EDC.DNC.MSAD.IdentityService.Repositories
{
    public class LoginUserRepository : RepositoryBase<LoginUser, IdentityDbContext>, ILoginUserRepository
    {
        public LoginUserRepository(IdentityDbContext dbContext) : base(dbContext)
        {
        }

        public LoginUser Authenticate(string _userName, string _userPassword)
        {
            var entity = DbContext.LoginUsers.FirstOrDefault(p => p.UserName == _userName &&
                p.Password == _userPassword);

            return entity;
        }
    }
}
