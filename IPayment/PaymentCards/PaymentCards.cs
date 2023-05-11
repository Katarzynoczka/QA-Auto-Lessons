using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    abstract public class PaymentCards : IPayment
    {
        public abstract bool MakePayment(float amount);
        public abstract void TopUp(float amount);

        public abstract float GetBalance();
       
    }
}
