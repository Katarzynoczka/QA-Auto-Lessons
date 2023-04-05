using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class CreditCard : PaymentCard
    {
        public int InterestRate { get; set; }
        public int CreditLimit { get; set; }

        public CreditCard(int number, Validity validityYear, Customer name, int cvv, int interestRate, int creditLimit): base 
            (number, validityYear, name, cvv)
        {
            InterestRate = interestRate;
            CreditLimit = creditLimit;
        }

        public override string GetFullInformation()
        {
            return String.Format("Number:{0}, Customer:{1}, Validity:{2}, CVV:{3}, Interest Rate:{4}, Credit Limit:{5}",
                Number, Name, ValidityYear, CVV, InterestRate, CreditLimit);
        }
    }
}
