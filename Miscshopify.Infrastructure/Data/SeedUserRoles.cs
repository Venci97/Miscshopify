using Microsoft.AspNetCore.Identity;
using Miscshopify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Infrastructure.Data
{
    public class SeedUsersRoles
    {
        private readonly List<IdentityRole> _roles;
        private readonly List<ApplicationUser> _users;
        private readonly List<IdentityUserRole<string>> _userRoles;
        public SeedUsersRoles()
        {
            _roles = GetRoles();
            _users = GetUsers();
            _userRoles = GetUserRoles(_users, _roles);
        }

        public List<IdentityRole> Roles { get { return _roles; } }
        public List<ApplicationUser> Users { get { return _users; } }
        public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }

        private List<IdentityRole> GetRoles()
        {

            // Seed Roles
            var adminRole = new IdentityRole("Administrator");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
                adminRole};

            return roles;
        }

        private List<ApplicationUser> GetUsers()
        {

            string pwd = "Admin123.";
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            // Seed Users
            var adminUser = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                ImagePath = "uploads/userImg/userPhoto.png",
                FirstName = "Admin",
                LastName = "Admin",
                City = "Admin",
                Address = "Admin",
                PostCode = "1234",
                Gender = Models.Enums.GenderEnum.Male,
                PhoneNumber = "1234567890",
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            List<ApplicationUser> users = new List<ApplicationUser>() {
           adminUser};

            return users;
        }

        private List<IdentityUserRole<string>> GetUserRoles(List<ApplicationUser> users, List<IdentityRole> roles)
        {
            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Administrator").Id
            });

            return userRoles;
        }
    }
}
