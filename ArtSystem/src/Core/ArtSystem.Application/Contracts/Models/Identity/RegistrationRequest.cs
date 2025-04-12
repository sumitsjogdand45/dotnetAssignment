
using System.ComponentModel.DataAnnotations; 

namespace ArtSystem.Application.Contracts.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
