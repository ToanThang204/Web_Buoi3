using Microsoft.AspNetCore.Mvc;

namespace Web_Buoi3.Controllers
{
    public class HelloController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Xinchao()  
        {
            ViewBag.name = "Lê Toàn Thắng";
            ViewData["name"] = "Lê Toàn Thắng";
            return View();
        }
    }
}
