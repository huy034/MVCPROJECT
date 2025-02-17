using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MVCPROJECT.Controllers
{
    public class IMBController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }  
[HttpPost]
        public IActionResult Index(int CanNang, int ChieuCao)
        {
           string strOutput = "Cân nặng " + CanNang +" " + "Chiều Cao " + ChieuCao;
           ViewBag.Message = strOutput;
           return View();
        }
    }
}
