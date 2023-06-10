using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using ASP.NET_CORE_MVC.Services;
using System.Linq;

namespace ASP.NET_CORE_MVC.Controllers
{
    //Thiết lập route cho hệ mặt trời
    //Thiết lập action trong route của controller thì kh cần thiếp lập route cho các action trong controller
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetSerivce _planetServices;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(PlanetSerivce planetService, ILogger<PlanetController> logger)
        {
            _planetServices = planetService;
            _logger = logger;
        }
        
        //Nếu thiệt lập dấu '/' trước route url thì sẽ kh kết hợp với route controller => /danh-sach-cac-hanh-tinh.html -> ok
        //custom đường dẫn cho trang index
        [Route("/danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index() //   he-mat-troi/danh-sach-cac-hanh-tinh.html
        {
            return View();
        }

        //route: action
        [BindProperty(SupportsGet = true, Name="action")]
        public string Name{get;set;} //Action ~ PlanetModel



        //Nếu thiết lập route controller thì phải thêm route vào các action để truy vấn được action vd: Route("ten-ket-hop"))
        public IActionResult English1()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult English2()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult English3()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult English4()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult English5()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }

        //Chỉ truy cập bằng phương thức GET với địa chỉ này
        [HttpGet("/English6.html")]
        public IActionResult English6()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }

        //order là độ ưu tiên cho thẻ asp-action phát sinh ra url (1 trong route)
        //Name dùng để phát sinh route url
        [Route("sao/[action]", Order=3, Name="english7-1")]//sao/English7
        [Route("sao/[controller]/[action]",Order=2, Name="english7-2")] // * sao/Planet/English7
        [Route("[controller]-[action].html",Order=1, Name= "english7-3")]//Planet-English7.html
        public IActionResult English7()
        {
            var planet = _planetServices.Where(x=>x.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }

        //controller, action, area => {controler} [action] [area]

        [Route("hanhtinh/{id:int}")] //Ràng buộc id - sẽ không truy cập theo địa chỉ endpoints định nghĩa trong startup nữa
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetServices.Where(x=>x.Id == id).FirstOrDefault();

            return View("Detail",planet);
        }
    }

}