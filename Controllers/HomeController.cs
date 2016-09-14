using System;
using Microsoft.AspNetCore.Mvc;
using PlatanoWeb.Model;
using Platano.Helpers;

namespace PlatanoWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var x = "37746";
            ViewBag.Maco = x.LastX(3);

            var model = new Device();
            model.Id = Guid.NewGuid();
            model.Name = "Garage Door";
            model.Status = "OPEN";
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}