using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using TestWebApp.Models;
using IOFile = System.IO.File;

namespace Mei.Controllers {
    public class FileController : Controller {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger) {
            _logger = logger;
        }

        [ResponseCache(Duration = 36000, Location = ResponseCacheLocation.Client)]
        public IActionResult ServeFile(string name) {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(name, out string contentType)) {
                contentType = "application/octet-stream";
            }
            return File(IOFile.OpenRead(name), contentType);
        }
    }
}
