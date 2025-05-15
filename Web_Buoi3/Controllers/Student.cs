using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Web_Buoi3.Controllers
{
    public class Student : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string hoTen, decimal? diemTB, string chuyenNganh)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                ViewBag.Error = "Vui lòng nhập họ tên của bạn";
                return View();
            }

            if (!diemTB.HasValue || diemTB < 0 || diemTB > 10)
            {
                ViewBag.Error = "Điểm trung bình phải nằm trong khoảng từ 0 đến 10";
                return View();
            }

            if (string.IsNullOrWhiteSpace(chuyenNganh))
            {
                ViewBag.Error = "Vui lòng chọn một chuyên ngành";
                return View();
            }

            // Dictionary để chuyển đổi mã ngành thành tên đầy đủ
            var majorNames = new Dictionary<string, string>
            {
                { "CNPM", "Công nghệ phần mềm (CNPM)" },
                { "HTTT", "Hệ thống thông tin (HTTT)" },
                { "ANM", "An ninh mạng (ANM)" },
                { "TTNT", "Trí tuệ nhân tạo (TTNT)" },
                { "MMT", "Mạng máy tính (MMT)" }
            };

            // Lấy tên đầy đủ của chuyên ngành
            string fullMajorName = majorNames.ContainsKey(chuyenNganh) ? majorNames[chuyenNganh] : chuyenNganh;

            // Chuẩn bị dữ liệu
            ViewBag.HoTen = hoTen;
            ViewBag.DiemTB = diemTB.Value.ToString("0.0");
            ViewBag.ChuyenNganh = fullMajorName;
            ViewBag.MaChuyenNganh = chuyenNganh;

            return View("KetQua");
        }
    }
}
