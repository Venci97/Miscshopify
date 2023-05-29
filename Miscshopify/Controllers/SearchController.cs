using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;

namespace Miscshopify.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(string searchTerm)
        {
            SearchViewModel viewModel = _searchService.Search(searchTerm);
            return View(viewModel);
        }
    }
}
