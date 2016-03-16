using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDashboard.Services;

namespace MVVMHookupDemo.Customers
{

    public class CustomerListViewModel
    {
        private ICustomersRepository _repo = new CustomersRepository();
        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                if (_customers != value)
                    _customers = value;
            }
        }

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            Customers = new ObservableCollection<Customer>(_repo.GetCustomersAsync().Result);
        }
        
    }
}
