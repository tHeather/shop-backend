using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop_backend.Database.Entities;
using shop_backend.Database.Entities.Enums;
using shop_backend.Database.Helpers;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Extensions;

namespace shop_backend.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static int pageSize = 10;
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Order.SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<PagedList<Order>> GetAllOrdersAsync(int pageNumber, string search, DeliveryMethod? deliveryMethod, PaymentMethod? paymentMethod, bool? sortByDateDescending)
        {
            IQueryable<Order> query = context.Order.Include(p => p.PersonalPickupBranch).OrderBy(o => o.DateTime);
            if (sortByDateDescending.HasValue && sortByDateDescending.Value)
            {
                query = context.Order.OrderByDescending(o => o.DateTime);
            }

            if(!search.IsNullOrEmpty())
            {
                var searchUppercased = search.ToUpper();
                query = query.Where(o => o.Id.ToString().Contains(searchUppercased) || o.EmailAddress.ToUpper().Contains(searchUppercased));
            }

            if (deliveryMethod.HasValue)
            {
                query = query.Where(o => o.DeliveryMethod == deliveryMethod.Value);
            }

            if (paymentMethod.HasValue)
            {
                query = query.Where(o => o.PaymentMethod == paymentMethod.Value);
            }

            return await PagedList<Order>.Create(query, pageNumber, pageSize);
        }

        public async Task CreateAsync(Order order)
        {
            context.Order.Add(order);
            await context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
