using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.WebApi.Controllers
{
    public class RestaurantTablesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
