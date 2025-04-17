using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Cart.Models;
using Web_Cart.Services.Momo;

namespace Web_Cart.Controllers
{
    public class PaymentController : Controller
    {
        private IMomoService _momoService;
        //private readonly IVnPayService _vnPayService;
        public PaymentController(IMomoService momoService)
        {
            _momoService = momoService;

        }
        [HttpPost]
        [Route("CreatePaymentUrl")]
        public async Task<IActionResult> CreatePaymentUrl(OrderInfo model)
        {
            var response = await _momoService.CreatePaymentMomo(model);
            return Redirect(response.PayUrl);
        }


    }
}
