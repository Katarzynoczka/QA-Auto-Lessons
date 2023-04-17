using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class CashBackCard : IPayment
    {
        public BankClient BankClient { get; set; }
        public Validity Validity { get; set; }
        public int CVV { get; set; }
        public float BalanceCashBack { get; set; }
        public float PercentCashBack { get; set; }


        public CashBackCard(BankClient bankClient, Validity validity, int cvv, float balanceCashBack, float percentCashBack)
        {
            BankClient = bankClient;
            Validity = validity;
            CVV = cvv;
            BalanceCashBack = balanceCashBack;
            PercentCashBack = percentCashBack;
        }

        public void MakePayment(float amount)
        {
            if (BalanceCashBack >= amount)
            {
                BalanceCashBack -= amount;
                float cashBackAmount = amount * PercentCashBack / 100;
                BalanceCashBack += cashBackAmount;
                Console.WriteLine($"Payment of {amount} has been made using cashback card. Cash back of {cashBackAmount} ({PercentCashBack}% of {amount}) has been added to the balance.");
            }
            else
            {
                Console.WriteLine("Not enough balance on the cashback card to make the payment.");
            }
        }

        public void TopUp(float amount)
        {
            BalanceCashBack += amount;
            Console.WriteLine("The balance has been topped up");
        }

        public float GetBalance()
        {
            return BalanceCashBack;
        }
    }
}
