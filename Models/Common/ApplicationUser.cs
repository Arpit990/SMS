using Microsoft.AspNetCore.Identity;

namespace SpeakerManagementSystem.Models.Common
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
