using Microsoft.AspNetCore.Identity;

namespace PDIv2.Models
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }     
    }
}
