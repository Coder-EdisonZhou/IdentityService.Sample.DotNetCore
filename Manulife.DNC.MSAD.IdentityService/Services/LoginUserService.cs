using Manulife.DNC.MSAD.Common;
using Manulife.DNC.MSAD.IdentityService.Models;
using Manulife.DNC.MSAD.IdentityService.Repositories;
using System;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.IdentityService.Services
{
    public class LoginUserService : ILoginUserService
    {
        private ILoginUserRepository loginUserRepository;

        public LoginUserService(ILoginUserRepository _loginUserRepository)
        {
            this.loginUserRepository = _loginUserRepository;
        }

        public bool Authenticate(string _userName, string _userPassword, out LoginUser loginUser)
        {
            // some business logic code here ...
            // eg.Security check & MD5 & 3DES ...
            loginUser = loginUserRepository.Authenticate(_userName, _userPassword);
            return loginUser == null ? false : true;
        }
    }
}
