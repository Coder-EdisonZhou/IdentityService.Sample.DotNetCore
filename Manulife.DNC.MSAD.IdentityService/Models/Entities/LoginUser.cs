using System.ComponentModel.DataAnnotations.Schema;

namespace Manulife.DNC.MSAD.IdentityService.Models
{
    [Table("TLoginUsers")]
    public class LoginUser
    {
        [Column("LoginUserId")]
        public int Id { get; set; }

        [Column("LoginUserName")]
        public string UserName { get; set; }

        [Column("LoginUserPassword")]
        public string Password { get; set; }

        [Column("LoginUserRealName")]
        public string RealName { get; set; }

        [Column("LoginUserEmail")]
        public string Email { get; set; }
    }
}
