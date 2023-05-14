using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.WebApi.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
