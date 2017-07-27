using Microsoft.AspNetCore.Mvc;
namespace VideoCatalog.Controllers
{
    public class MultimediasController : Controller
    {
        public IActionResult Video()
        {
            return View();
        }
        public IActionResult Catalog()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Item()
        {
            return View();
        }
    }
}