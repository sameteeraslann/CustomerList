using CustomerInfo.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerInfo.UI.Controllers
{
    public class CustomerController : Controller
    {
        string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerVM customerVM)
        {

            //uploads klasörü yoksa oluşturulur.
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
            customerVM.Id = Guid.NewGuid().ToString();
            existingExcelDataList.Add(customerVM);
            // JSON dosyasına yazma işlemi
            var jsonData = JsonConvert.SerializeObject(existingExcelDataList, Formatting.Indented);
            await System.IO.File.WriteAllTextAsync(jsonFilePath, jsonData);


            // Veritabanına kaydetme işlemleri gibi kodlar
            return RedirectToAction("Index", "Home");

        }

    }
}
