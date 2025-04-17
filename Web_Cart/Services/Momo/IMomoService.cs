using Web_Cart.Models.Momo;
using Web_Cart.Models;

namespace Web_Cart.Services.Momo
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentMomo(OrderInfo model);

        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
    }
}
