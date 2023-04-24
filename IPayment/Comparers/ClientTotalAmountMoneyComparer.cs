using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Comparers
{
    internal class ClientTotalAmountMoneyComparer : IComparer<BankClient>
    {
        public int Compare(BankClient x, BankClient y)
        {
           float xTotalAmountMoney = GetTotalAmountMoney(x);
           float yTotalAmountMoney = GetTotalAmountMoney(y);

           return xTotalAmountMoney.CompareTo(yTotalAmountMoney);
        }

        public float GetTotalAmountMoney(BankClient bankClient)
        {
            float totalAmountMoney = 0;

            foreach (IPayment paymentMethod in bankClient.paymentMethods)
            {
                totalAmountMoney += paymentMethod.GetBalance();
            }

            return totalAmountMoney;
        }
    }
    
}
