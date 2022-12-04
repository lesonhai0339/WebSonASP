using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WebSonASP.Models;

namespace WebSonASP.Controllers
{
    public class SonController : Controller
    {
        private Models.QLSONContext db = new Models.QLSONContext();
        [Route("/Trang-Chu/San-Pham")]
        public IActionResult Index()
        {
             return View(db.Sons.ToList());
        }
        [Route("/Trang-Chu/Gioi-Thieu")]
        public IActionResult about()
        {
            return View();
        }
        [Route("/Trang-Chu/Tin-Tuc")]
        public IActionResult blog()
        {
            return View();
        }
        [Route("/Trang-Chu/Lien-He")]
        public IActionResult contact()
        {
            return View();
        }
        [Route("/Trang-Chu/Danh-Sach-Mau-Son")]
        public IActionResult portfolio()
        {
            List<Models.Mauson> ds = db.Mausons.Select(a => new Models.Mauson
            {
                Mason = a.Mason,
                Tenmau = a.Tenmau,
                Maloai = a.MaloaiNavigation.Maloai
            }).ToList();
            return View(ds);
        }
        [Route("/Trang-Chu/Danh-Muc-San-Pham")]
        public IActionResult danhMucSanPham()
        {
            return View(db.Sons.ToList());
        }
        [HttpGet]
        [Route("/Trang-Chu/Danh-Muc-San-Pham/Chi-Tiet-San-Pham/")]
        public IActionResult chiTietSanPham(string id)
        {
            Son x = new Son();
            foreach (var s in db.Sons)
            {
                if(s.Id == id)
                {
                    x.Id = s.Id;
                    x.Ten = s.Ten;
                    x.Loai = s.Loai;
                    x.Chuthich = s.Chuthich;
                    x.Hinhanh = s.Hinhanh;
                    x.Huongdansd = s.Huongdansd;
                    x.Congdung = s.Congdung;
                }
            }
            return View(x);
        }
        [Route("/Trang-Chu/Cham-Soc-Khach-Hang")]
        public IActionResult services()
        {
            return View();
        }
        [Route("/Trang-Chu/Doi-Ngu")]
        public IActionResult team()
        {
            return View();
        }
    }
}
