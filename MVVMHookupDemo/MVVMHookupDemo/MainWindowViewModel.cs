using MVVMHookupDemo.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHookupDemo
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();
        }

        public Object CurrentViewModel { get; set; }
    }
}
