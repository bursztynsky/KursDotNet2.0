using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_BazaDanych
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public User(int id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public string GetUserInfo()
        {
            return $"{Id} {Name} {Surname} {Email}";
        }
    }
}
