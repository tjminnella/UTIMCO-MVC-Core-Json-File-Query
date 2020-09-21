using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using UTIMCO.Models;
using UTIMCO.ViewModel;
using UTIMCO.Utilities;

namespace UTIMCO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment hosting;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hosting)
        {
            _logger = logger;
            this.hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(JsonEvaluateViewModel model)
        {
            if (ModelState.IsValid && model.JsonFile != null)
            {
                try
                {
                    //save the file
                    string uniqueFileName = Utility.ProcessUploadedFile(model, hosting.WebRootPath);
                    //deserialize
                    List<MyArray> root = Utility.GetMenus(uniqueFileName);
                    //initialize results
                    model.MyResults = Utility.GetResults(root);
                }
                catch
                {
                    model.ErrorMessage = "That was not a well formed Json file you uploaded.";
                }
            }
            return View(model);
        }

    }
}
