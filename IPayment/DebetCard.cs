using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class DebetCard : IPayment
    {
        public BankClient BankClient { get; set; }
        public Validity Validity { get; set; }
 
        public int CVV { get; set; }
        public float BalanceDebet { get; set; }

        public DebetCard(BankClient bankClient, Validity validity, int cvv, float balanceDebet)
        {
            BankClient = bankClient;
            Validity = validity;
            CVV = cvv;
            BalanceDebet = balanceDebet;
        }

        public void MakePayment(float amount)
        {
            if (BalanceDebet >= amount)
            {
                BalanceDebet -= amount;
                Console.WriteLine($"Payment of {amount} has been made using debit card.");
            }
            else
            {
                Console.WriteLine("Not enough balance on the debit card to make the payment.");
            }
        }

        public void TopUp(float amount)
        {
            BalanceDebet += amount;
            Console.WriteLine($"The balance has been topped up with {amount} using debit card.");
        }

        public float GetBalance()
        {
            return BalanceDebet;
        }
    }
 }
