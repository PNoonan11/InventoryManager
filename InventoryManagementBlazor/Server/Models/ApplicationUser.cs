using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementBlazor.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(4)]
        public string Username { get; set; }

        [MinLength(4)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}