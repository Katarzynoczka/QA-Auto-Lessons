using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public class Cash : IPayment
    {
        private float _balanceCash;
        public float BalanceCash
        {
            get
            {
                return _balanceCash;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Debet balance cannot be negative");
                }
                else
                {
                    _balanceCash = value;
                }
            }
        }

        public Cash(float balanceCash)
        {
            BalanceCash = balanceCash;
        }

        public override bool Equals(object obj)
        {
            if (obj is Cash)
            {
                Cash cash = obj as Cash;
                return cash.BalanceCash == BalanceCash;
            }
            return false;
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
