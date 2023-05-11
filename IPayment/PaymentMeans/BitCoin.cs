using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public class BitCoin : IPayment
    {
        private float _balanceBitCoin;
        public float BalanceBitCoin
        {
            get
            {
                return _balanceBitCoin;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The BitCoin balance cannot be negative");
                }
                else
                {
                    _balanceBitCoin = value;
                }
            }
        }

        public BitCoin(float balanceBitCoin)
        {
            BalanceBitCoin = balanceBitCoin;
        }

        public override bool Equals(object obj)
        {
            if (obj is BitCoin)
            {
                BitCoin bitCoin = obj as BitCoin;
                return bitCoin.BalanceBitCoin == BalanceBitCoin;
            }
            return false;
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


