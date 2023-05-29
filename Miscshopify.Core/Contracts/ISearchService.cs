using Miscshopify.Core.Models;

namespace Miscshopify.Core.Contracts
{
    public interface ISearchService
    {
        SearchViewModel Search(string searchTerm);
    }
}
