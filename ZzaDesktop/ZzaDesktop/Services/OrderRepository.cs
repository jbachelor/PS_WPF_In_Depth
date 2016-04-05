using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Zza.Data;

namespace ZzaDesktop.Services
{
    public class OrderRepository : IOrderRepository
    {
        ZzaDbContext context = new ZzaDbContext();

        #region IOrderRepository Members
        public async Task<Order> AddOrderAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var order = context.Orders.Include("OrderItems").Include("OrderItems.OrderItemOptions").FirstOrDefault(o => o.Id == orderId);
                if(orderId != null)
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        foreach (var orderItemOption in orderItem.Options)
                        {
                            context.OrderItemOptions.Remove(orderItemOption);
                        }
                        context.OrderItems.Remove(orderItem);
                    }
                    context.Orders.Remove(order);
                }
                await context.SaveChangesAsync();
                scope.Complete();
            }
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId)
        {
            return await context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return await context.OrderStatuses.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<List<ProductSize>> GetProductSizesAsync()
        {
            return await context.ProductSizes.ToListAsync();
        }

        public async Task<List<ProductOption>> GetProudctOptionsAsync()
        {
            return await context.ProductOptions.ToListAsync();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if(!context.Orders.Local.Any(o => o.Id == order.Id))
            {
                context.Orders.Attach(order);
            }
            context.Entry(order).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return order;
        }
        #endregion IOrderRepository Members
    }
}
