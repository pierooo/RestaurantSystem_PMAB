﻿using Microsoft.AspNetCore.Mvc;

namespace RestaurantSystem.WebApi.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
