using WebApplication1.DTO.Request;
using WebApplication1.IRepository;
using WebApplication1.IService;
using WebApplication1.Modals;

namespace WebApplication1.Service
{
    public class ConfirmOrderService : IConfirmOrderService
    {
        private IConfirmOrderRepository _confirmOrderRepository;

        public ConfirmOrderService(IConfirmOrderRepository confirmOrderRepository)
        {
            _confirmOrderRepository = confirmOrderRepository;
        }


        public string AddConfirmOrder(ConfirmOrderRequest confirmOrderRequest)
        {
            var obj = new ConfirmOrders
            {
                Movie = confirmOrderRequest.Movie,
                TotalRent = confirmOrderRequest.TotalRent,
                UserId = confirmOrderRequest.UserId,
                RentedDate = confirmOrderRequest.RentedDate,
                ReturnDate = confirmOrderRequest.ReturnDate,
                MovieId = confirmOrderRequest.MovieId
            };

            var data = _confirmOrderRepository.AddConfirmOrder(obj);
            return data;
        }


        public List<ConfirmOrders> GetConfirmOrders()
        {
            var data = _confirmOrderRepository.GetConfirmOrders();
            var listResponse = new List<ConfirmOrders>();
            foreach (var item in data)
            {
                var response = new ConfirmOrders
                {
                    id = item.id,
                    Movie = item.Movie,
                    TotalRent = item.TotalRent,
                    UserId = item.UserId,
                    RentedDate = item.RentedDate,
                    ReturnDate = item.ReturnDate,
                    MovieId = item.MovieId
                };

                listResponse.Add(response);
            }
            return listResponse;

        }


        public string DeleteConfirmOrder(Guid confirmOrderId)
        {
            var data = _confirmOrderRepository.DeleteConfirmOrder(confirmOrderId);
            return data;
        }

        public string UpdateConfirmorder(ConfirmOrderRequest confirmOrderRequest, Guid confirmorderId)
        {
            var orderrequest = new ConfirmOrders
            {
                id = confirmorderId,
                Movie = confirmOrderRequest.Movie,
                TotalRent = confirmOrderRequest.TotalRent,
                UserId = confirmOrderRequest.UserId,
                RentedDate = confirmOrderRequest.RentedDate,
                ReturnDate = confirmOrderRequest.ReturnDate,
                MovieId = confirmOrderRequest.MovieId
            };

            var data = _confirmOrderRepository.UpdateConfirmorder(orderrequest);
            return data;
        }
    }
}
