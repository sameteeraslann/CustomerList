using CustomerInfo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CustomerInfo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult>  Index()
        {
            return View();
        }

        public JsonResult LoadDataTable()
        {
            string jsonFilePath = Path.Combine(uploadsPath, "customerList.json");
            var jsonDataDeConvert =  System.IO.File.ReadAllText(jsonFilePath);
            //var customersInfo = JsonConvert.DeserializeObject<List<CustomerVM>>(jsonDataDeConvert);

            return Json(jsonDataDeConvert);//, System.Web.Mvc.JsonRequestBehavior.AllowGet);

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
    }
}
