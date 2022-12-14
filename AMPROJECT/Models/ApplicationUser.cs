using Microsoft.AspNetCore.Identity;

namespace AMPROJECT.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string City { get; set; } = String.Empty;

    }
}
