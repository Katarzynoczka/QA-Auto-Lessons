using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Comparers
{
    internal class ClientPaymentMethodsCountComparer : IComparer<BankClient>
    {
        public int Compare(BankClient x, BankClient y)
        {
            return x.paymentMethods.Count.CompareTo(y.paymentMethods.Count);
        }
    }
}
