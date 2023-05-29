using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;

namespace Miscshopify.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<UserEditViewModel> EditUser(string id);
        Task<bool> UpdateUserDetails(UserEditViewModel model);

        Task<ApplicationUser> GetUserById(string id);
    }
}
