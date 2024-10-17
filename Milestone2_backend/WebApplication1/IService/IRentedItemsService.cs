using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface IRentedItemsService
    {
         string AddRentedItems(RentedItemsRequest item);
         List<RentedItemsResponse> GetAllRentedItems();
         Task<string> UpdateRentedItem(Guid id, RentedItemsRequest item);
         string DeleteRentedItem(Guid id);

    }
}
