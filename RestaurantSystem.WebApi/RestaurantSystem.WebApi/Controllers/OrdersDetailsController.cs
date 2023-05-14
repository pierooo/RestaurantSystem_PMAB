using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.WebApi.Controllers
{
    public class OrdersDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
