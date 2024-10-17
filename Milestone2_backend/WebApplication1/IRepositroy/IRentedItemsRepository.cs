using WebApplication1.Modals;

namespace WebApplication1.IRepository
{
    public interface IRentedItemsRepository
    {
        string AddRentedItems(RentedItems rentedItems);
        List<RentedItems> GetAllRentedItems();
        Task<string> UpdateRentedItems(RentedItems rentedItems);
        string DeleteRentedItem(Guid id);

    }
}
