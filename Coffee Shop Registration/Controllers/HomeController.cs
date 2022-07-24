using Coffee_Shop_Registration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coffee_Shop_Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecordStoreContext _recordStoreContext;
        public HomeController(ILogger<HomeController> logger, RecordStoreContext newRecordStoreContext)
        {
            _logger = logger;
            _recordStoreContext = newRecordStoreContext;
        }

        public IActionResult Index()
        {
            var prcount = _recordStoreContext.Products.Count();
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult RegistrationSubmit(CoffeeUser user)
        {
            return View("RegistrationSubmit", user);
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