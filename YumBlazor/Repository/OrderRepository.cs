using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> UpdateStatusAsync(int orderId, string status , string paymentIntentId)
        {
            var orderHeader = await _db.OrderHeader.FirstOrDefaultAsync(u => u.Id == orderId);
            if (orderHeader != null)
            {
                orderHeader.Status = status;
                if(!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderHeader.PaymentIntentId = paymentIntentId;
                }


                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }


        public async Task<OrderHeader> GetOrderBySessionIdAsync (string sessionId)
        {
            return await _db.OrderHeader
                .FirstOrDefaultAsync(o => o.SessionId == sessionId.ToString());
        }



        public async Task<OrderHeader> CreateAsync(OrderHeader obj)
        {
            _db.OrderHeader.Add(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<OrderHeader> UpdateAsync(OrderHeader obj)
        {
            _db.OrderHeader.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _db.OrderHeader.FindAsync(id);
            if (order == null) return false;

            _db.OrderHeader.Remove(order);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _db.OrderHeader
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync()
        {
            return await _db.OrderHeader
                .Include(x => x.OrderDetails)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

    }
}
