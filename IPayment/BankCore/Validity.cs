using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public class Validity
    {
        public int _validityDay;
        public int ValidityDay
        {
            get
            {
                return _validityDay;
            }
            set
            {
                if (value <= 12)
                {
                    _validityDay = value;
                }
            }
        }
        
        public int _validityYear;
        public int ValidityYear
        {
            get
            {
                return _validityYear;
            }
            set
            {
                if (value >= 2023)
                {
                    _validityYear = value;
                }
                /*else
                {
                    _validityYear = "Your card is not valid";
                }*/
            }
        }
        public Validity(int validityDay, int validityYear)
        {
            ValidityDay = validityDay;
            ValidityYear = validityYear;
        }
        
     }
}
