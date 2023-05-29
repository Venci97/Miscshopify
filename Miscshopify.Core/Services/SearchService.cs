using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;

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
            List<Category> categories = repo.All<Category>().Where(c => c.Name.Contains(searchTerm)).ToList();
            List<Product> products = repo.All<Product>().Where(p => p.Name.Contains(searchTerm) || p.Category.Name.Contains(searchTerm)).ToList();

            SearchViewModel viewModel = new SearchViewModel
            {
                Categories = categories,
                Products = products
            };

            return viewModel;
        }
    }

}
