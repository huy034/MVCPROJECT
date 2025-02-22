using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MVCPROJECT.Models;
namespace MVCPROJECT.Controllers
{
    public class IMBController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IMB imb)
        {
            if (imb.Weight <= 0 || imb.Height <= 0 || string.IsNullOrEmpty(imb.Gender))
            {
                ViewBag.Message = "Vui lòng nhập đầy đủ thông tin!";
                return View();
            }

            double heightInMeters = imb.Height / 100;


            imb.BMI = imb.Weight / (heightInMeters * heightInMeters);

            if (imb.BMI < 18.5) imb.Result = "Bạn đang gầy";
            else if (imb.BMI < 24.9) imb.Result = "Bạn đang bình thường";
            else if (imb.BMI < 29.9) imb.Result = "Bạn đang thừa cân";
            else if (imb.BMI < 34.9) imb.Result = "Bạn đang béo phì cấp độ 1";
            else if (imb.BMI < 39.9) imb.Result = "Bạn đang béo phì cấp độ 2";
            else imb.Result = "Bạn đang béo phì cấp độ 3";

            ViewBag.Message = $"Giới tính: {imb.Gender} - Chỉ số BMI: {imb.BMI:F2} - {imb.Result}";

            return View(imb);
        }
    }


}
