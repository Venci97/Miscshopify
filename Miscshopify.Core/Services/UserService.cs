using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

namespace Miscshopify.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbRepository repo;

        public UserService(IAppDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>()
                .Select(u => new UserViewModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.PhoneNumber,
                    CreationDate = u.CreationDate,
                    Gender = u.Gender,
                    IsActive = u.IsActive
                })
                .ToListAsync();
        }

		public async Task<UserEditViewModel> EditUser(string id)
		{
			var user = await repo.GetByIdAsync<ApplicationUser>(id);

			return new UserEditViewModel()
			{
                Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                IsActive = user.IsActive
            };
		}

        public async Task<bool> UpdateUserDetails(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Gender = model.Gender;
                user.IsActive = model.IsActive;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }
    }
}
