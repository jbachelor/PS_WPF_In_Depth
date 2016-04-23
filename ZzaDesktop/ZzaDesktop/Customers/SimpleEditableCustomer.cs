using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZzaDesktop.Validation;

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
        [Display(Name = "first name")]
        [Required]
        [AtLeastNCharacters(2)]
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string lastName;
        [Required(ErrorMessage = "Last name is required")]
        [AtLeastNCharacters(2, "Sorry, I can't trust you without at least a two-letter last name")]
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
