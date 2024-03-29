﻿using Microsoft.EntityFrameworkCore;
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
                Description = model.Description
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
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    Name = c.Name,
                    Description = c.Description
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
                Description = cat.Description
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

			repo.Delete(category);

		    repo.SaveChanges();
		}
	}
}