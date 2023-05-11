using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public class Validity
    {
        private int _validityDay;
        public int ValidityDay
        {
            get
            {
                return _validityDay;
            }
            set
            {
                if (value <= 12 && value > 0)
                {
                    _validityDay = value;
                }
                else
                {
                    throw new FormatException("Invalid month format");
                }
            }
        }
        
        private int _validityYear;
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
                else
                {
                    throw new FormatException("Invalid year format");
                }
            }
        }
        public Validity(int validityDay, int validityYear)
        {
            ValidityDay = validityDay;
            ValidityYear = validityYear;
        }

        public override bool Equals(object obj)
        {
            if (obj is Validity)
                {
                Validity validity = obj as Validity;
                return validity.ValidityDay == ValidityDay &&
                    validity.ValidityYear == ValidityYear;
                }
            return false;
        }

    }
}
