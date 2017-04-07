using Microsoft.AspNetCore.Mvc;
using Bedrock.Application.Services.Abstract.Sample;

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
