using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;

namespace ZzaDesktop
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            customerListViewModel.PlaceOrderRequested += NavToOrder;
            customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            customerListViewModel.EditCustomerRequested += NavToEditCustomer;
        }

        private CustomerListViewModel customerListViewModel = new CustomerListViewModel();
        private OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private OrderViewModel orderViewModel = new OrderViewModel();
        private AddEditCustomerViewModel addEditViewModel = new AddEditCustomerViewModel();

        public RelayCommand<string> NavCommand { get; private set; }

        private BindableBase currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }
        
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "orderPrep":
                    CurrentViewModel = orderPrepViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = customerListViewModel;
                    break;
            }
        }
        
        private void NavToOrder(Guid customerId)
        {
            orderViewModel.CustomerId = customerId;
            CurrentViewModel = orderViewModel;
        }

        private void NavToEditCustomer(Customer customer)
        {
            addEditViewModel.EditMode = true;
            addEditViewModel.SetCustomer(customer);
            CurrentViewModel = addEditViewModel;
        }

        private void NavToAddCustomer(Customer customer)
        {
            addEditViewModel.EditMode = false;
            addEditViewModel.SetCustomer(customer);
            currentViewModel = addEditViewModel;
        }

    }
}
