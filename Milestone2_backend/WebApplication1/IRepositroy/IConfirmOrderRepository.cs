using WebApplication1.Modals;

namespace WebApplication1.IRepository
{
    public interface IConfirmOrderRepository
    {
        string AddConfirmOrder(ConfirmOrders confirmOrders);
        List<ConfirmOrders> GetConfirmOrders();
        string DeleteConfirmOrder(Guid confirmOrderId);
        string UpdateConfirmorder(ConfirmOrders confirmorder);
    }
}
