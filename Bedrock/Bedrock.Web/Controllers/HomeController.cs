using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bedrock.Services.Sample.Interfaces;

namespace Bedrock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoService _todoService;
        public HomeController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
