using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Customers
{
    public class AddEditCustomerViewModel : BindableBase
    {
        private bool editMode;
        public bool EditMode
        {
            get { return editMode; }
            set { SetProperty(ref editMode, value); }
        }

        private Customer editingCustomer = null;
        public void SetCustomer(Customer customer)
        {
            editingCustomer = customer;
        }

    }
}
