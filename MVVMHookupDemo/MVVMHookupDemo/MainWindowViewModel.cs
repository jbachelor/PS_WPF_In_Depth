using MVVMHookupDemo.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MVVMHookupDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Timer timer = new Timer(5000);
        
        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();
            timer.Elapsed += (s, e) => NotificationMessage = "At the tone the time will be: " + DateTime.Now.ToLocalTime();
            timer.Start();
        }

        public Object CurrentViewModel { get; set; }

        private string notificationMessage;
        public string NotificationMessage
        {
            get
            {
                return notificationMessage;
            }
            set
            {
                if(value != notificationMessage)
                {
                    notificationMessage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("NotificationMessage"));
                }
            }
        }
    }
}
