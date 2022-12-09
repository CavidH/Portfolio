using Microsoft.AspNetCore.Identity;

namespace Portfolio.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
