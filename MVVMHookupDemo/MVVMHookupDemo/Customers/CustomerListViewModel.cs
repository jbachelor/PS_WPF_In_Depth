using System.Collections.ObjectModel;
using System.ComponentModel;
using Zza.Data;
using ZzaDashboard.Services;

namespace MVVMHookupDemo.Customers
{

    public class CustomerListViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ICustomersRepository _repo = new CustomersRepository();

        #endregion Fields

        #region Constructors

        public CustomerListViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            ChangeCustomerCommand = new RelayCommand(OnChangeCustomer, CanChangeCustomer);
        }

        #endregion Constructors

        #region Commands

        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ChangeCustomerCommand { get; private set; }

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }

        private bool CanChangeCustomer()
        {
            return SelectedCustomer != null;
        }

        private void OnChangeCustomer()
        {
            SelectedCustomer.FirstName = "Changed in background";
        }

        #endregion Commands

        #region Events

        public event PropertyChangedEventHandler PropertyChanged = delegate { }; // The anonymous delegate will not be used, but prevents risk of a null ref exception.

        #endregion Events

        #region Properties
        
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
                {
                    _customers = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
                }
            }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                    DeleteCommand.RaiseCanExecuteChanged();
                    ChangeCustomerCommand.RaiseCanExecuteChanged();
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
                }
            }
        }

        #endregion Properties
        
        public async void LoadCustomersAsync()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            Customers = new ObservableCollection<Customer>(await _repo.GetCustomersAsync());
        }
    }
}
