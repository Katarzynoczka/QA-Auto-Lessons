using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class Cash : IPayment
    {
        public BankClient BankClient { get; set; }
        public float BalanceCash { get; set; }

        public Cash(BankClient bankClient, float balanceCash)
        {
            BankClient = bankClient;
            BalanceCash = balanceCash;
        }

        public void MakePayment(float amount)
        {
            if (BalanceCash >= amount)
            {
                BalanceCash -= amount;
                Console.WriteLine($"Payment of {amount} has been made using cash");
            }
            else
            {
                Console.WriteLine("Not enough cash to make the payment.");
            }
        }

        public void TopUp(float amount)
        {
            BalanceCash += amount;
            Console.WriteLine("The balance has been topped up");
        }

        public float GetBalance()
        {
            return BalanceCash;
        }

    }
}
