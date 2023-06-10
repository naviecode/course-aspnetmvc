using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using ASP.NET_CORE_MVC.Services;
using System.Linq;

namespace ASP.NET_CORE_MVC.Controllers
{

    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductServices _productServices;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductServices productServices, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }
        [Route("/cac-san-pham")]
        public IActionResult Index()
        {
            // /Areas/AreaName/Views/ControllerName/Action.cshtml
            var products = _productServices.OrderBy(x=>x.Name).ToList();
            return View(products); //  /Areas/ProductManage/Views/Product/Index.cshtml
        }
    }
}