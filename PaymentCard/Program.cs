﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class Program
    {
        static bool InformationCard(PaymentCard[] paymentCards)
        {
            for (int i = 0; i < paymentCards.Length; i++)
                {
                Console.WriteLine("Number:{0}, Validity:{1}, Name:{2}, Surname:{3}, CVV:{4}", paymentCards[i].Number, paymentCards[i].ValidityYear, paymentCards[i].Name, paymentCards[i].SurName, paymentCards[i].CVV);
                }
            return true;
        }
        static void Main(string[] args)
        {
            PaymentCard paymentCard1 = new PaymentCard();
            paymentCard1.Number = 1;
            paymentCard1.ValidityYear = 2027;
            paymentCard1.Name = "Kate";
            paymentCard1.SurName = "Bayok";
            paymentCard1.CVV = 123;

            PaymentCard paymentCard2 = new PaymentCard();
            paymentCard2.Number = 2;
            paymentCard2.ValidityYear = 2024;
            paymentCard2.Name = "Artyom";
            paymentCard2.SurName = "Vasilyev";
            paymentCard2.CVV = 234;

            PaymentCard paymentCard3 = new PaymentCard();
            paymentCard3.Number = 3;
            paymentCard3.ValidityYear = 2026;
            paymentCard3.Name = "Anna";
            paymentCard3.SurName = "Antonova";
            paymentCard3.CVV = 157;

            PaymentCard paymentCard4 = new PaymentCard();
            paymentCard4.Number = 4;
            paymentCard4.ValidityYear = 2025;
            paymentCard4.Name = "Kirill";
            paymentCard4.SurName = "Kirkorov";
            paymentCard4.CVV = 888;

            PaymentCard paymentCard5 = new PaymentCard();
            paymentCard5.Number = 5;
            paymentCard5.ValidityYear = 2023;
            paymentCard5.Name = "Anton";
            paymentCard5.SurName = "Gigros";
            paymentCard5.CVV = 987;

            PaymentCard[] paymentCards = new PaymentCard[] { paymentCard1, paymentCard2, paymentCard3, paymentCard4, paymentCard5 };
            InformationCard(paymentCards); 
        }
    }
}