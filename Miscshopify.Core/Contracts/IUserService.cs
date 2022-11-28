using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
    }
}
