using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public class DebetCard : PaymentCards
    {
        public Validity Validity { get; set; }
        private float _balanceDebet;
        public float BalanceDebet
        {
            get
            {
                return _balanceDebet;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Debet balance cannot be negative");
                }
                else
                {
                    _balanceDebet = value;
                }
            }
        }

        public DebetCard(Validity validity, float balanceDebet)
        {
            Validity = validity;
            BalanceDebet = balanceDebet;
        }

        public override bool Equals(object obj)
        {
            if (obj is DebetCard)
            {
                DebetCard debetCard = obj as DebetCard;
                return debetCard.BalanceDebet == BalanceDebet;
            }
            return false;
        }

        public override bool MakePayment(float amount)
        {
            if (BalanceDebet >= amount)
            {
                BalanceDebet -= amount;
                return true;
            }
            return false;
        }

        public override void TopUp(float amount)
        {
            BalanceDebet += amount;
            Console.WriteLine($"The balance has been topped up with {amount}");
        }

        public override float GetBalance()
        {
            return BalanceDebet;
        }
    }
 }
