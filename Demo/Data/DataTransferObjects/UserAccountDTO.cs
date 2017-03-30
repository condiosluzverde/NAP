using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nap.Demo.Data
{
    public class UserAccountDTO
    {
        public UserAccountDTO()
        {
            Id = -1;
            Name = string.Empty;
            Address = string.Empty;
            Postal = string.Empty;
            Email = string.Empty;
        }

        public UserAccountDTO(int id, string name, string address, string postal, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Postal = postal;
            Email = email;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Postal { get; set; }

        public string Email { get; set; }
    }
}
