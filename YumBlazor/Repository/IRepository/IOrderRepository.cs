using YumBlazor.Data;

public interface IOrderRepository
{
    Task<OrderHeader> CreateAsync(OrderHeader obj);
    Task<OrderHeader> UpdateAsync(OrderHeader obj);
    Task<OrderHeader> GetOrderBySessionIdAsync(string  sessionId);
    Task<bool> UpdateStatusAsync(int orderId, string status,string paymentIntentId);
    Task<bool> DeleteAsync(int id);
    Task<OrderHeader> GetAsync(int id);
    Task<IEnumerable<OrderHeader>> GetAllAsync();
}
