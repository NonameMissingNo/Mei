using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using TestWebApp.Models;

namespace TestWebApp.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            if (Request.Query["path"].Count != 0) {
                string path = Request.Query["path"][0];
                return View(new TestVideoSourceModel { Paths = Directory.GetFiles($"D:\\{path}") });
            } else
                return View(new TestVideoSourceModel { Paths = Directory.GetFiles($"D:\\VPVideos") });
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
