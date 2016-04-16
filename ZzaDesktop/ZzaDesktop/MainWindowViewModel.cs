using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Zza.Data;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;
using ZzaDesktop.Services;

namespace ZzaDesktop
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            _customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();
            _addEditViewModel = ContainerHelper.Container.Resolve<AddEditCustomerViewModel>();

            NavCommand = new RelayCommand<string>(OnNav);
            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerListViewModel.EditCustomerRequested += NavToEditCustomer;
            _addEditViewModel.DoneSaving += NavToCustomerList;
        }
        
        private CustomerListViewModel _customerListViewModel;
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private AddEditCustomerViewModel _addEditViewModel;

        public RelayCommand<string> NavCommand { get; private set; }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }
        
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "orderPrep":
                    CurrentViewModel = _orderPrepViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = _customerListViewModel;
                    break;
            }
        }
        
        private void NavToOrder(Guid customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private void NavToEditCustomer(Customer customer)
        {
            _addEditViewModel.EditMode = true;
            _addEditViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToAddCustomer(Customer customer)
        {
            _addEditViewModel.EditMode = false;
            _addEditViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToCustomerList()
        {
            CurrentViewModel = _customerListViewModel;
        }

    }
}
