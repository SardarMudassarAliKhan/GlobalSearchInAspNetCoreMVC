using GlobalSearchInAspNetCoreMVC.Models;

namespace GlobalSearchInAspNetCoreMVC.IAppServices
{
    public interface ISearchService
    {
        Task<IEnumerable<object>> SearchAsync(string searchTerm,string filter);
        Task<SearchResultItem> GetItemByIdAsync(int id);
    }
}
