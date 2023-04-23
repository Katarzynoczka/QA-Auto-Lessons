using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class DebetCard : PaymentCards
    {
        Validity Validity { get; set; }
        public float BalanceDebet { get; set; }

        public DebetCard(Validity validity, float balanceDebet)
        {
            Validity = validity;
            BalanceDebet = balanceDebet;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceDebet >= amount)
            {
                BalanceDebet -= amount;
                return true;
            }
            return false;
        }

        public override void TopUp(float amount)
        {
            BalanceDebet += amount;
            Console.WriteLine($"The balance has been topped up with {amount}");
        }

        public override float GetBalance()
        {
            return BalanceDebet;
        }
    }
 }
