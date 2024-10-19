using eCommerce_dotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace eCommerce_dotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MasterContext masterContext = new MasterContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            var listSanPham = masterContext.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> model = new PagedList<TDanhMucSp>(listSanPham, pageNumber, pageSize);
            return View(model);

        }

        public IActionResult SanPhamTheoLoai(String maLoai,int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            var listSanPham = masterContext.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> model = new PagedList<TDanhMucSp>(listSanPham, pageNumber, pageSize);
            ViewBag.maLoai = maLoai;
            return View(model);
        }

        public IActionResult ChiTietSanPham(String maSp)
        {
            var sanPham = masterContext.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = masterContext.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
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
