using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class Customer
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Addres{ get; set; }
        public long PhoneNumber { get; set; }

        public Customer(string name, string surName, string addres, long phoneNumber)
        {
            Name = name;
            SurName = surName;
            Addres = addres;
            PhoneNumber = phoneNumber;
        }

      
        public string GetFullInformation()
        {
            return String.Format("Name:{0}, Sur Name:{1}, Addres:{2}, Phone Number:{3}", Name, SurName, Addres, PhoneNumber);
        }

    }
}
