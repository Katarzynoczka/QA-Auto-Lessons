using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class DebetCard : PaymentCard
    {
        public int InterestDeposit { get; set; }
        public int FundsAccount { get; set; }

        public DebetCard (int number, Validity validityYear, Customer name, int cvv, int interestDeposit, int fundsAccount) : base
            (number, validityYear, name, cvv)
        {
            InterestDeposit = interestDeposit;
            FundsAccount = fundsAccount;
        }

        public override string GetFullInformation()
        {
            return String.Format("Number:{0}, Customer:{1}, Validity:{2}, CVV:{3}, Interest Deposit:{4}, Funds Account:{5}",
                Number, Name, ValidityYear, CVV, InterestDeposit, FundsAccount);
        }
    }
 }
