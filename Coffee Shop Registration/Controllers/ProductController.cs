using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop_Registration.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
