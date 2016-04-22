using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop.Customers
{
    public class SimpleEditableCustomer : ValidatableBindableBase
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string firstName;
        [Required(ErrorMessage = "First name is required")]
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string lastName;
        [Required(ErrorMessage = "Last name is required")]
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private string phone;
        [Phone]
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        private string email;
        [EmailAddress(ErrorMessage = "Yeah... I'm SURE that's a legit email... NOT!")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
    }
}
