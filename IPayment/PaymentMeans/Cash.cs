using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class Cash : IPayment
    {
        public float BalanceCash { get; set; }

        public Cash(float balanceCash)
        {
            BalanceCash = balanceCash;
        }

        public bool MakePayment(float amount)
        {
            if (BalanceCash >= amount)
            {
                BalanceCash -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TopUp(float amount)
        {
            BalanceCash += amount;
            Console.WriteLine($"The balance has been topped up with {amount}");
        }

        public float GetBalance()
        {
            return BalanceCash;
        }

    }
}
