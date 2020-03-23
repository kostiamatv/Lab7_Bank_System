using System;

namespace Lab7
{
    public class User
    {
        public string Name { get; }
        public string Surname { get; }
        public string Address { get; }
        public string PassportId { get; }

        public User(string name, string surname, string address = null, string passportId = null)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PassportId = passportId;
        }

        public bool IsTrusted() => Address != null && PassportId != null;
    }
}