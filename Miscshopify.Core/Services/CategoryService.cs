﻿using Microsoft.AspNetCore.Http;
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
    public class CategoryService : ICategoryService
    {
        private readonly IAppDbRepository repo;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IAppDbRepository _repo, IUnitOfWork _unitOfWork)
        {
            repo = _repo;
            unitOfWork = _unitOfWork;
        }

        public async Task Add(CategoryViewModel model)
        {
            unitOfWork.UploadImage(file);

            var category = new Category()
            {

                Name = model.Name,
                Description = model.Description,
                
                
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await repo.All<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<CategoryViewModel> Edit(Guid id)
        {
            var cat = await repo.GetByIdAsync<Category>(id);

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
    }
}