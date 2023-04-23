using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class CreditCard : PaymentCards
    {
        Validity Validity { get; set; }
        public float BalanceCredit { get; set; }
        public float CreditLimit { get; set; }

        public CreditCard(Validity validity, float balanceCredit, float creditLimit)
        {
            Validity = validity;
            BalanceCredit = balanceCredit;
            CreditLimit = creditLimit;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceCredit >= amount)
            {
                BalanceCredit -= amount;
                return true;
            }
            else if (BalanceCredit + CreditLimit >= amount)
            {
                float amountToCharge = amount - BalanceCredit;
                BalanceCredit = 0;
                CreditLimit -= amountToCharge;
                return true;
            }
            else
            {
                return false;    
            }
        }

        public override void TopUp(float amount)
        {
            BalanceCredit += amount;
            Console.WriteLine($"The balance has been topped up with {amount}");
        }

        public override float GetBalance()
        {
            return BalanceCredit + CreditLimit;
        }
    }
}
