using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class CashBackCard : PaymentCards
    {
        Validity Validity { get; set; }
        public float BalanceCashBack { get; set; }
        public float PercentCashBack { get; set; }


        public CashBackCard(Validity validity, float balanceCashBack, float percentCashBack) 
        {
            Validity = validity;
            BalanceCashBack = balanceCashBack;
            PercentCashBack = percentCashBack;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceCashBack >= amount)
            {
                BalanceCashBack -= amount;
                float cashBackAmount = amount * PercentCashBack / 100;
                BalanceCashBack += cashBackAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void TopUp(float amount)
        {
            BalanceCashBack += amount;
            Console.WriteLine($"The balance has been topped up with {amount}");
        }

        public override float GetBalance()
        {
            return BalanceCashBack;
        }
    }
}
