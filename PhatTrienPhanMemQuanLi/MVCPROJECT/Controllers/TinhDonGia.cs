using MVCPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MVCPROJECT.Controllers
{
    public class TinhDonGiaController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TinhDonGia invoice)
        {
            if (invoice.Quantity <= 0 || invoice.UnitPrice <= 0 || string.IsNullOrEmpty(invoice.ProductName))
            {
                ViewBag.Message = "Vui lòng nhập đầy đủ thông tin hợp lệ!";
                return View();
            }

            invoice.CalculateTotal();

            ViewBag.Message = $"Sản phẩm: {invoice.ProductName} - Số lượng: {invoice.Quantity} - Đơn giá: {invoice.UnitPrice:C} - Tổng tiền: {invoice.Total:C}";

            return View(invoice);
        }
    }
}