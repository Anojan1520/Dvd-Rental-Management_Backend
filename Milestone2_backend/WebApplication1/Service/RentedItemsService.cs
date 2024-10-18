using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.IRepository;
using WebApplication1.IService;
using WebApplication1.Modals;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class RentedItemsService : IRentedItemsService
    {
        private IRentedItemsRepository _rentedItemsRepository;

        public RentedItemsService(IRentedItemsRepository rentedItemsRepository)
        {
            this._rentedItemsRepository = rentedItemsRepository;
        }


        public string AddRentedItems(RentedItemsRequest item)
        {
            var obj = new RentedItems
            {
                MovieId = item.MovieId,
                UserId = item.UserId,
                Status = item.Status,
                RentQuantity = item.RentQuantity,
                RentedDate = item.RentedDate,
                ReturnDate = item.ReturnDate,
            };
            var Itemdata = _rentedItemsRepository.AddRentedItems(obj);
            return Itemdata;
        }
        public async Task<string> UpdateRentedItem(Guid id , RentedItemsRequest item)
        {
            var obj = new RentedItems
            {
                Id = id,
                MovieId = item.MovieId,
                UserId = item.UserId,
                Status = item.Status,
                RentQuantity = item.RentQuantity,
                RentedDate = item.RentedDate,
                ReturnDate = item.ReturnDate,
            };
            var Itemdata =await _rentedItemsRepository.UpdateRentedItems(obj);
            return Itemdata;
        }

        public List<RentedItemsResponse> GetAllRentedItems()
        {
            var data = _rentedItemsRepository.GetAllRentedItems();
            var listrespons = new List<RentedItemsResponse>();
            foreach (var item in data)
            {
                var response = new RentedItemsResponse()
                {
                    Id=item.Id,
                    MovieId = item.MovieId,
                    UserId = item.UserId,
                    Status = item.Status,
                    RentQuantity = item.RentQuantity,
                    RentedDate = item.RentedDate,
                    ReturnDate = item.ReturnDate,

                };
                listrespons.Add(response);

            };
            return listrespons;
        }


        public string GetRentedItems(Guid id)
        {
            var data = _rentedItemsRepository.DeleteRentedItem(id);
            return data;
        }
    }
}
