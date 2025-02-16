using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MVCPROJECT.Controllers
{
    public class PersonController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }  

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
