using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { }; // The anonymous delegate will not be used, but prevents risk of a null ref exception.

        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        private Guid _id;
        public Guid Id {
            get
            {
                return _id;
            }
            set
            {
                if(value != _id)
                {
                    _id = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                }
            }
        }

        private Guid? _storeId;
        public Guid? StoreId
        {
            get
            {
                return _storeId;
            }
            set
            {
                if(value != _storeId)
                {
                    _storeId = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("StoreId"));
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if(value != _lastName)
                {
                    _lastName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                }
            }
        }

        public string FullName { get { return FirstName + " " + LastName; } }

        private string _phone;
        public string Phone {
            get
            {
                return _phone;
            }
            set
            {
                if(value != _phone)
                {
                    _phone = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
                }
            }
        }

        private string _email;
        public string Email { get
            {
                return _email;
            }
            set
            {
                if(value != _email)
                {
                    _email = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }

        private string _street;
        public string Street {
            get
            {
                return _street;
            }
            set
            {
                if(value != _street)
                {
                    _street = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Street"));
                }
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("City"));
                }
            }
        }

        private string _state;
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                if (value != _state)
                {
                    _state = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
                }
            }
        }

        private string _zip;
        public string Zip
        {
            get
            {
                return _zip;
            }
            set
            {
                if (value != _zip)
                {
                    _zip = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Zip"));
                }
            }
        }

        private List<Order> _orders;
        public List<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                if (value != _orders)
                {
                    _orders = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Orders"));
                }
            }
        }
    }
}
