using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class BitCoin : IPayment
    {
        public float BalanceBitCoin { get; set; }

        public BitCoin(float balanceBitCoin)
        {
            BalanceBitCoin = balanceBitCoin;
        }

        public bool MakePayment(float amount)
        {
            if (BalanceBitCoin >= amount)
            {
                BalanceBitCoin -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TopUp(float amount)
        {
            BalanceBitCoin += amount;
            Console.WriteLine($"The balance has been topped up with {amount}");
        }

        public float GetBalance()
        {
            return BalanceBitCoin;
        }
    }
   
}


