using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using System.Linq;

namespace Miscshopify.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAppDbRepository repo;

        public SearchService(IAppDbRepository _repo)
        {
            repo = _repo;
        }

        public SearchViewModel Search(string searchTerm)
        {
            var categoryEntities = repo.All<Category>()
                .Where(c => c.Name.Contains(searchTerm))
                .ToList();

            var productEntities = repo.All<Product>()
                .Where(p => p.Name.Contains(searchTerm) || p.Category.Name.Contains(searchTerm))
                .ToList();

            var categories = categoryEntities.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImagePath = c.ImagePath
            }).ToList();

            var products = productEntities.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                ImagePath = p.ImagePath,
                CategoryId = p.CategoryId,
                //CategoryName = p.Category.Name
            }).ToList();

            SearchViewModel viewModel = new SearchViewModel
            {
                Categories = categories,
                Products = products
            };

            return viewModel;
        }
    }
}