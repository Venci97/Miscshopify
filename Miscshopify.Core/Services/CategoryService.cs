using Microsoft.EntityFrameworkCore;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

namespace Miscshopify.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IAppDbRepository repo;

        public CategoryService(IAppDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task Add(CategoryViewModel model)
        {
            var category = new Category()
            {
                ImagePath = model.ImagePath,
                Name = model.Name,
                Description = model.Description,
                ParentId = model.ParentId
            };

            if (model == null)
            {
                throw new NullReferenceException("Empty category");
            }

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await repo.All<Category>()
                .Include(c => c.Products)
                .Include(c => c.Parent) 
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    Name = c.Name,
                    Description = c.Description,
                    ProductsCount = c.Products.Count,
                    ParentId = c.ParentId,
                    ParentName = c.Parent != null ? c.Parent.Name : null 
                })
                .ToListAsync();
        }

        public async Task<CategoryViewModel> Edit(Guid id)
        {
            var cat = await repo.GetByIdAsync<Category>(id);

            if (cat == null)
            {
                throw new NullReferenceException("Invalid Category");
            }

            return new CategoryViewModel()
            {
                Id = cat.Id,
                Name = cat.Name,
                Description = cat.Description,
                ImagePath = cat.ImagePath,
                ParentId = cat.ParentId
            };
        }

        public async Task<bool> UpdateCategoryDetails(CategoryViewModel model)
        {
            bool result = false;
            var cat = await repo.GetByIdAsync<Category>(model.Id);

            if (cat != null)
            {
                cat.Name = model.Name;
                cat.Description = model.Description;
                cat.ParentId = model.ParentId;
                cat.ImagePath = model.ImagePath;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public void RemoveCategoryWithProducts(Guid categoryId)
        {
            var category = repo.All<Category>()
                .FirstOrDefault(i => i.Id == categoryId);

            if (category == null)
            {
                throw new NullReferenceException("Category not exist");
            }

            var products = repo.All<Product>()
                .Where(p => p.CategoryId == categoryId);

            foreach (var item in products)
            {
                repo.Delete(item);
            }

            var subcategories = repo.All<Category>()
                .Where(c => c.ParentId == categoryId);

            foreach (var subcategory in subcategories)
            {
                var subcategoryProducts = repo.All<Product>()
                    .Where(p => p.CategoryId == subcategory.Id);

                foreach (var product in subcategoryProducts)
                {
                    repo.Delete(product);
                }

                repo.Delete(subcategory);
            }

            repo.Delete(category);
            repo.SaveChanges();
        }


        public async Task<IEnumerable<CategoryViewModel>> GetMainCategories()
        {
            return await repo.All<Category>()
                .Where(c => c.ParentId == null)
                .Include(c => c.Products)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    ProductsCount = c.Products.Count
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetSubcategories(Guid parentId)
        {
            return await repo.All<Category>()
                .Where(c => c.ParentId == parentId)
                .Include(c => c.Products)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImagePath = c.ImagePath,
                    ParentId = c.ParentId,
                    ProductsCount = c.Products.Count
                })
                .ToListAsync();
        }

        public async Task<bool> HasSubcategories(Guid categoryId)
        {
            return await repo.All<Category>()
                .AnyAsync(c => c.ParentId == categoryId);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesForDropdown()
        {
            return await repo.All<Category>()
                .Where(c => c.ParentId == null)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<CategoryViewModel> GetCategoryById(Guid id)
        {
            var category = await repo.All<Category>()
                .Include(c => c.Parent)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return null;

            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImagePath = category.ImagePath,
                ParentId = category.ParentId,
                ParentName = category.Parent != null ? category.Parent.Name : null,
                ProductsCount = category.Products.Count
            };
        }
    }
}