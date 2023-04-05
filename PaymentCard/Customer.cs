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

      
        public override string ToString ()
        {
            return "Name:" + Name + ", Sur Name:" + SurName + ", Addres:" + Addres + ", Phone Number:" + PhoneNumber;
        }

    }
}
