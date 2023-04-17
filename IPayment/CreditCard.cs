using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class CreditCard : IPayment
    {
        public BankClient BankClient { get; set; }
        public Validity Validity { get; set; }
        public int CVV { get; set; }
        public float BalanceCredit { get; set; }
        public float CreditLimit { get; set; }

        public CreditCard(BankClient bankClient, Validity validity, int cvv, float balanceCredit, float creditLimit)
        {
            BankClient = bankClient;
            Validity = validity;
            CVV = cvv;
            BalanceCredit = balanceCredit;
            CreditLimit = creditLimit;
        }

        public void MakePayment(float amount)
        {
            if (BalanceCredit >= amount)
            {
                BalanceCredit -= amount;
                Console.WriteLine($"Payment of {amount} has been made using credit card.");
            }
            else if (BalanceCredit + CreditLimit >= amount)
            {
                float amountToCharge = amount - BalanceCredit;
                BalanceCredit = 0;
                CreditLimit -= amountToCharge;
                Console.WriteLine($"Payment of {amount} has been made using credit limit.");
            }
            else
            {
                Console.WriteLine("Not enough balance and credit limit on the credit card to make the payment.");
            }
        }

        public void TopUp(float amount)
        {
            BalanceCredit += amount;
            Console.WriteLine($"The balance has been topped up with {amount} using credit card.");
        }

        public float GetBalance()
        {
            return BalanceCredit + CreditLimit;
        }
    }
}
