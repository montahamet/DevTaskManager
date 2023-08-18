using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using STAGE._2023.TEST.Entities;
using STAGE._2023.TEST.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //Modules _Modules = Repository.Module.GetAll();

            //if (_Modules != null)
            //{ 
            //    HttpContext.Session.SetString("Modules", JsonConvert.SerializeObject(_Modules));
            //} 

            return View("Index_H");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Module()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
