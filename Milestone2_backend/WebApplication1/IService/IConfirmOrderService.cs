using WebApplication1.DTO.Request;
using WebApplication1.Modals;

namespace WebApplication1.IService
{
    public interface IConfirmOrderService
    {
        string AddConfirmOrder(ConfirmOrderRequest confirmOrderRequest);
        List<ConfirmOrders> GetConfirmOrders();
        string DeleteConfirmOrder(Guid confirmOrderId);
        string UpdateConfirmorder(ConfirmOrderRequest confirmOrderRequest, Guid confirmorderId);
    }
}
