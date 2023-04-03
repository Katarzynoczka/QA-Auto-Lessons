﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class PaymentCard
    {
        public int Number { get; set; }
        public Validity ValidityYear { get; set; }
       
        public Customer Name { get; set; }
        public int CVV { get; set; }

        public PaymentCard(int number, Validity validityYear, Customer name, int cvv)
        {
            Number = number;
            ValidityYear = validityYear;
            Name = name;
            CVV = cvv;
        }

        
        public string GetFullInformation()
        {
            return String.Format("Number:{0}, Validity:{1}, Customer:{2}, CVV:{3}", Number, ValidityYear, Name, CVV);
        }
    }
}
