using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_MVC.Areas.Database.controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DBManageController : Controller
    {
        private readonly AppDBContext _dbcontext;
        public DBManageController(AppDBContext dBContext)
        {
            _dbcontext = dBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [TempData]
        public string StatusMessage{get;set;}
        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDbAysnc()
        {
            var success = await _dbcontext.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Xóa database thành công" : "Không xóa duoc";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _dbcontext.Database.MigrateAsync();
            StatusMessage = "Cập nhập database thành công";
            return RedirectToAction(nameof(Index));
        }
    }
}