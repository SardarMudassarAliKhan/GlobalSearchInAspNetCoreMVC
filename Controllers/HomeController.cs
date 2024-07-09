using GlobalSearchInAspNetCoreMVC.IAppServices;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSearchInAspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;

        public HomeController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _searchService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}
