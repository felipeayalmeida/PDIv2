using Microsoft.AspNetCore.Identity;

namespace PDIv2.Models
{
    public class User : IdentityUser<int>
    {
        public int TenantId { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }     
    }
}
