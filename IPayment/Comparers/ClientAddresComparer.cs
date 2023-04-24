using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Comparers
{
    internal class ClientAddresComparer : IComparer<BankClient>
    {
        public int Compare(BankClient x, BankClient y)
        {
            return x.Addres.CompareTo(y.Addres);
        }
    }
}
