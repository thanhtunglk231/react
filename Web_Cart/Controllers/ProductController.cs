using Microsoft.AspNetCore.Mvc;
using Web_Cart.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Web_Cart.Extensions; // Thêm dòng này

namespace Web_Cart.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1500, ImageUrl = "/images/laptop.png" },
        new Product { Id = 2, Name = "Phone", Price = 800, ImageUrl = "/images/phone.png" }
    };

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(c => c.Product.Id == id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            TempData["Message"] = $"{product.Name} đã được thêm vào giỏ hàng!";

            return RedirectToAction("Index");
        }
    }
}
