using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
namespace Web_Cart.Controllers
{
    public class UploadController : Controller
    {
        private readonly string _imagePath = "wwwroot/uploads"; // Thư mục lưu ảnh

        public UploadController()
        {
            // Tạo thư mục lưu ảnh nếu chưa tồn tại
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(_imagePath);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(_imagePath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                ViewBag.Message = "Tải ảnh thành công!";
                ViewBag.ImagePath = "/uploads/" + fileName; // Đường dẫn ảnh để hiển thị
            }
            else
            {
                ViewBag.Message = "Vui lòng chọn ảnh!";
            }

            return View("Index");
        }
    }
}
