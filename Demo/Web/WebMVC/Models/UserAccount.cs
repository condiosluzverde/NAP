using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nap.Demo.WebMVC.Models
{
    public class UserAccount
    {
        const int DEFAULT_ID = -1;
        const string DEFAULT_NAME = "NO NAME SET";
        const string DEFAULT_ADDRESS = "NO ADDRESS SET";
        const string DEFAULT_POSTAL = "NO POSTAL SET";
        const string DEFAULT_EMAIL = "NO EMAIL SET";

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Postal { get; set; }

        public string Email { get; set; }

        public UserAccount()
        {
            // Default ctor uses default values
            Id = DEFAULT_ID;
            Name = DEFAULT_NAME;
            Address = DEFAULT_ADDRESS;
            Postal = DEFAULT_POSTAL;
            Email = DEFAULT_EMAIL;
        }

        public UserAccount(string name, string address, string postal, string email)
        {
            Id = DEFAULT_ID;
            Name = name;
            Address = address;
            Postal = postal;
            Email = email;
        }

        public UserAccount(int id, string name, string address, string postal, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Postal = postal;
            Email = email;
        }
    }
}