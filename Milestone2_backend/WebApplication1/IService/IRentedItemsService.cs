using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface IRentedItemsService
    {
         string AddRentedItems(RentedItemsRequest item);
         List<RentedItemsResponse> GetAllRentedItems();
         string GetRentedItems(Guid id);

    }
}
