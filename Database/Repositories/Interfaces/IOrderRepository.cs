using System.Threading.Tasks;
using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;
using shop_backend.Database.Helpers;

namespace shop_backend.Database.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<PagedList<Order>> GetAllOrdersAsync(int pageNumber, string search, DeliveryMethod? deliveryMethod, PaymentMethod? paymentMethod, bool? sortByDateDescending);
        Task CreateAsync(Order order);
        Task<Order> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}