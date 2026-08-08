using Microsoft.AspNetCore.Mvc;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Models;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult Results(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var emptyModel = new SearchViewModel
                {
                    Products = new List<ProductViewModel>(),
                    Categories = new List<CategoryViewModel>()
                };
                return View(emptyModel);
            }

            SearchViewModel viewModel = _searchService.Search(searchTerm);
            return View(viewModel);
        }
    }
}