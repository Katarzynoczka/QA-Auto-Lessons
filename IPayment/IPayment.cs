﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public interface IPayment
    {
        bool MakePayment(float amount);

        void TopUp(float amount);

        float GetBalance();
    }  
}
