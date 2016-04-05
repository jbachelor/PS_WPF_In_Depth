using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Services
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<List<OrderStatus>> GetOrderStatusesAsync();

        Task<List<Product>> GetProductsAsync();
        Task<List<ProductOption>> GetProudctOptionsAsync();
        Task<List<ProductSize>> GetProductSizesAsync();
    }
}
