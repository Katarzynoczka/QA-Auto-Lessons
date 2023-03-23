using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class PaymentCard
    {
        private int Number;
        private int ValidityYear;
        private string Name;
        private string SurName;
        private int CVV;

        public PaymentCard(int number, int validityYear, string name, string surName, int cvv)
        {
            Number = number;
            ValidityYear = validityYear;
            Name = name;
            SurName = surName;
            CVV = cvv;
        }

        public int GetNumber()
        {
            return Number;
        }

        public int GetValidityYear()
        {
            return ValidityYear;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetSurName()
        {
            return SurName;
        }

        public int GetCVV()
        {
            return CVV;
        }

        /*public string GetFullInformation()
        {
            return String.Format("Number:{0}, Validity:{1}, Name:{2}, Surname:{3}, CVV:{4}", Number, ValidityYear, Name, SurName, CVV);
        }*/
    }
}
