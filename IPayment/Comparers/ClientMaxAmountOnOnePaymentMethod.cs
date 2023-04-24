using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Comparers
{
    internal class ClientMaxAmountOnOnePaymentMethod : IComparer<BankClient>
    {
        public int Compare(BankClient x, BankClient y)
        {
            float xMaxAmountMoney = GetMaxAmountMoney(x);
            float yMaxAmountMoney = GetMaxAmountMoney(y);

            return xMaxAmountMoney.CompareTo(yMaxAmountMoney);
        }

        public float GetMaxAmountMoney(BankClient bankClient)
        {
            float maxAmountMoney = 0;

            foreach (IPayment paymentMethod in bankClient.paymentMethods)
            {
                if (paymentMethod.GetBalance() > maxAmountMoney)
                {
                    maxAmountMoney = paymentMethod.GetBalance();
                }

            }

            return maxAmountMoney;
        }
    }
}
