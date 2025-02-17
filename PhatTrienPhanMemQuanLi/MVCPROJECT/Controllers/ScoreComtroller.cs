using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCPROJECT.Models;
namespace MVCPROJECT.Controllers
{
    public class ScoreController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(double A, double B, double C)
    {
            double finalScore = C * 0.1 + B * 0.3 + A * 0.6;
            ViewBag.FinalScore = $"Điểm tổng kết của bạn là: {finalScore:F2}";

            return View();
    }
}
}