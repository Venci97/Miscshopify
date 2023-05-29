using Miscshopify.Core.Models;

namespace Miscshopify.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task Add(CategoryViewModel model);
        Task<CategoryViewModel> Edit(Guid id);
        Task<bool> UpdateCategoryDetails(CategoryViewModel model);
        void RemoveCategoryWithProducts(Guid categoryId);
    }
}
