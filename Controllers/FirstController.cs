using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using ASP.NET_CORE_MVC.Services;
using System.Linq;
namespace ASP.NET_CORE_MVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductServices _productServices;
        public FirstController(ILogger<FirstController> logger, ProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }
        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData

            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Thong bao");
            return "Tôi là index của first";
        }
        public void NoThing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi","xin chào các bạn");
        }
        public object AnyThing()=> new int[]{1,2,3};

        public IActionResult ReadMe()
        {
            var content = @"xin chao cac ban, cac ban dang ho ve asp.net mvc";
            return Content(content,"text/plain");
        }

        public IActionResult Bird()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "chucnang_project.png");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/png");

        }
        public IActionResult IphonePrice()
        {
            return Json(
                new {
                    productName = "Iphone X",
                    Price = 1000
                }
            );
        }
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");

            _logger.LogInformation("Chuyển hướng đến");
            return LocalRedirect(url); //local ~ host
        }

        public IActionResult Google() //chuyển hướng về trang kh nằm trong local thì dùng Redirect
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyển hướng đến "+url);
            return Redirect(url);
        }
        public IActionResult HelloView(string username)
        {
            if(string.IsNullOrEmpty(username))
                username = "khácch";
            // View() -> Razor, Engine, doc .cshtml (template)
            //View(template) - đường dẫn tuyệt đối tới .cshtml
            //View(template, model)
            // return View("/MyView/xinchao1.cshtml",username);

            //xinchao2.cshtml -> Views/First/xinchao2.cshtml
            //return View("xinchao2",username);

            //HelloView.cshtml -> Views/First/HelloView
            return View((object)username);
        }
        [TempData]
        public string StatusMessage{get;set;}

        //Chỉ được phương thức truy cập là POST và GET
        [AcceptVerbs("POST","GET")]
        public IActionResult ViewProduct(int? id)
        {
            var product = _productServices.Where(x=>x.Id == id).FirstOrDefault();
            if(product == null)
            {
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "San pham ban yeu cau khong co";
                return Redirect(Url.Action("Index","Home"));
            }
            //Model
            // return View(product);

            //ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            //Chuyển dữ liêu từ trang này qua trang khác TempData(tìm hiểu gg) - lưu ở session
            //TempData["Thongbao"] = "";

            ViewBag.product = product;
            return View("ViewProduct3");
        }
        //IActionResult
        //      ContentResult               | Content()
        //     EmptyResult                 | new EmptyResult()
        //     FileResult                  | File()
        //     ForbidResult                | Forbid()
        //     JsonResult                  | Json()
        //     LocalRedirectResult         | LocalRedirect()
        //     RedirectResult              | Redirect()
        //     RedirectToActionResult      | RedirectToAction()
        //     RedirectToPageResult        | RedirectToRoute()
        //     RedirectToRouteResult       | RedirectToPage()
        //     PartialViewResult           | PartialView()
        //     ViewComponentResult         | ViewComponent()
        //     StatusCodeResult            | StatusCode()
        //     ViewResult                  | View()

     }
}