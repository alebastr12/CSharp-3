using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPFMailSender
{
    class Person
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public Person(string Email, string Name)
        {
            if (Email == string.Empty)
            {
                throw new ArgumentNullException("Значение Email не может быть пустым.");
            }
            this.Email = Email;
            this.Name = (Name == string.Empty) ? "Имя" : Name;
        }
        public bool isNotNull()
        {
            if (Email == String.Empty || Name == String.Empty)
                return false;
            else return true;
        }
    }
}
