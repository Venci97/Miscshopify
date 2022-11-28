using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Name = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();
        }
    }
}
