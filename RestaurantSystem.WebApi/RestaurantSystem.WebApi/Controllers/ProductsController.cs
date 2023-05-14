using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.WebApi.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
