using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels.SecurityModels
{
    public class ApplicationUser : IdentityUser
    {
        public IList<string> Role { get; set; } = [];
    }

    public class UserRoleDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
    }

    public class AssignRoleDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public IList<string> Role { get; set; } = [];
    }
    public class ImageUpload
    {
        public string? ImageData { get; set; }
        public string? ImageName { get; set; }
    }
    public class AuthRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class AuthResponse
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string[] Roles { get; set; } = [];
    }
    public class RegistrationRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public IList<string> Role { get; set; } = [];
    }
}
