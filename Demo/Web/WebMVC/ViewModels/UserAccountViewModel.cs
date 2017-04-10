using Nap.Demo.WebMVC.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nap.Demo.WebMVC.ViewModels
{
    public class UserAccountViewModel
    {
        const int DEFAULT_ID = -1;
        const string DEFAULT_NAME = "Please enter a name.";
        const string DEFAULT_ADDRESS = "Please enter a home address.";
        const string DEFAULT_POSTAL = "Please enter a postal address.";
        const string DEFAULT_EMAIL = "Please enter an email address.";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Postal { get; set; }

        public string Email { get; set; }

        public UserAccountViewModel()
        {
            // Default ctor uses default values
            Id = DEFAULT_ID;
            Name = DEFAULT_NAME;
            Address = DEFAULT_ADDRESS;
            Postal = DEFAULT_POSTAL;
            Email = DEFAULT_EMAIL;
        }

        public UserAccountViewModel(UserAccount ua)
        {
            Id = ua.Id;
            Name = ua.Name;
            Address = ua.Address;
            Postal = ua.Postal;
            Email = ua.Email;
        }

        public UserAccountViewModel(int id, string name, string address, string postal, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Postal = postal;
            Email = email;
        }
    }
}