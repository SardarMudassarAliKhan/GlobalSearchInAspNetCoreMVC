using GlobalSearchInAspNetCoreMVC.Data;
using GlobalSearchInAspNetCoreMVC.IAppServices;
using GlobalSearchInAspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSearchInAspNetCoreMVC.AppService
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext _context;

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> SearchAsync(string searchTerm, string filter)
        {
            List<object> results = new List<object>();

            if (filter == "all" || filter == "products")
            {
                var products = await _context.Products
                    .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                    .Select(p => new { p.Id, p.Name, p.Description, p.ImageUrl })
                    .ToListAsync();

                results.AddRange(products);
            }

            if (filter == "all" || filter == "categories")
            {
                var categories = await _context.Categories
                    .Where(c => c.Name.Contains(searchTerm))
                    .Select(c => new { c.Id, c.Name })
                    .ToListAsync();

                results.AddRange(categories);
            }

            return results;
        }

        public async Task<SearchResultItem> GetItemByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                return new SearchResultItem
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl
                };
            }

            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                return new SearchResultItem
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = "Category"
                };
            }

            return null;
        }
    }
}
