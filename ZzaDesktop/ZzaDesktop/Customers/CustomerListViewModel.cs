using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        public CustomerListViewModel()
        {
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
        }

        private ICustomerRepository repo = new CustomerRepository(); // Initial, crude implementation... Should use DI (coming in a future module of this tutorial).

        public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
        public event Action<Guid> PlaceOrderRequested = delegate { };

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public async void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(
                await repo.GetCustomersAsync());
        }

        private void OnPlaceOrder(Customer customer)
        {
            PlaceOrderRequested(customer.Id);
        }



    }
}
