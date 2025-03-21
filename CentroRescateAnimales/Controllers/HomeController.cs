using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CentroRescateAnimales.Models;

namespace CentroRescateAnimales.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Sobre Nosotros";
            return View();
        }
    }

