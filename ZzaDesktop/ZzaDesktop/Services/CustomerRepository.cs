using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        ZzaDbContext context = new ZzaDbContext();

        #region ICustomerRepository Members
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customerToDelete = context.Customers.FirstOrDefault(customer => customer.Id == customerId);
            if (customerToDelete != null)
            {
                context.Customers.Remove(customerToDelete);
            }
            await context.SaveChangesAsync();
        }

        public Task<Customer> GetCustomerAsync(Guid customerId)
        {
            return context.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return context.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if(!context.Customers.Local.Any(cust => cust.Id == customer.Id))
            {
                context.Customers.Attach(customer);
            }
            context.Entry(customer).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return customer;
        }
        #endregion ICustomerRepository Members
    }
}
