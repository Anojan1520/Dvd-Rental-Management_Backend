using WebApplication1.Modals;

namespace WebApplication1.IRepository
{
    public interface IRentedItemsRepository
    {
        string AddRentedItems(RentedItems rentedItems);
        List<RentedItems> GetAllRentedItems();
        string DeleteRentedItem(Guid id);
        Task<string> UpdateRentedItems(RentedItems rentedItems);
    }
}
