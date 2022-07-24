using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Coffee_Shop_Registration.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private  RecordStoreContext _recordStoreContext;
       
       
        public ProductController(ILogger<ProductController> newLogger, RecordStoreContext newRecordStoreContext)
        {
            logger = newLogger;
            _recordStoreContext = newRecordStoreContext;
        }
        public IActionResult Index()
        {
            Products[] products = null;
            products = _recordStoreContext.Products.ToArray();
            return View(products);
        }
        public IActionResult DetailView(int id)
        {
            Products[] productList = null;
            
            Products productDescription = null;
           //var proToDisplay = new Products();
            productList = _recordStoreContext.Products.ToArray();
            foreach (var product in productList)
            {
                if (product.Id == id)
                {
                    productDescription = product;
                    
                    break;
                }
            }
            return View(productDescription);

            //if (productDescription != null)
            //{
            //    return View(productDescription);
            //}
            //else
            //{
            //    throw new Exception($"Sorry, cannot find that ID");
            //}
        }
        //public IActionResult Detail()
        //{
        //    return View();
        //}
    }
}
