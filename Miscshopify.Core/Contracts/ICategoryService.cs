using Microsoft.AspNetCore.Http;
using Miscshopify.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task Add(CategoryViewModel model);
        Task<CategoryViewModel> Edit(Guid id);

        Task<bool> UpdateCategoryDetails(CategoryViewModel model);
    }
}
