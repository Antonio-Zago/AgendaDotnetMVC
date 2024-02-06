using AgendaMVC.Models;
using AgendaMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            var eventos = _homeService.GetEventos();
            return View();
        }


    }
}