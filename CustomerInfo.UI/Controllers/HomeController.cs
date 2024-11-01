using CustomerInfo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

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

        public async Task<IActionResult> Index()
        {
            string jsonFilePath = Path.Combine(uploadsPath, "customerList.json");
            var jsonDataDeConvert = await System.IO.File.ReadAllTextAsync(jsonFilePath);
            var customersInfo = JsonConvert.DeserializeObject<List<CustomerVM>>(jsonDataDeConvert);


            return View(customersInfo);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                //uploads klasörü yoksa oluþturulur.
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                string jsonFilePath = Path.Combine(uploadsPath, "customerList.json");
                var existingExcelDataList = new List<CustomerVM>();

                if (System.IO.File.Exists(jsonFilePath))
                {
                    var existingJsonData = await System.IO.File.ReadAllTextAsync(jsonFilePath);
                    existingExcelDataList = JsonConvert.DeserializeObject<List<CustomerVM>>(existingJsonData)
                                            ?? new List<CustomerVM>();
                }
                existingExcelDataList.Add(customerVM);

                // JSON dosyasýna yazma iþlemi
                var jsonData = JsonConvert.SerializeObject(existingExcelDataList, Formatting.Indented);
                await System.IO.File.WriteAllTextAsync(jsonFilePath, jsonData);

              
                // Veritabanýna kaydetme iþlemleri gibi kodlar
                return RedirectToAction("Success");
            }

            return View("Index", customerVM); // Model hatalýysa formu tekrar göster
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
