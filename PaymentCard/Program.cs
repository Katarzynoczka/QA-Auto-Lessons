using System;
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
            foreach (PaymentCard paymentCard in paymentCards)
                {
                Console.WriteLine("Number:{0}, Validity:{1}, Name:{2}, Surname:{3}, CVV:{4}", paymentCard.GetNumber(), 
                                                                                              paymentCard.GetValidityYear(), 
                                                                                              paymentCard.GetName(), 
                                                                                              paymentCard.GetSurName(), 
                                                                                              paymentCard.GetCVV());
                }
            /*{
            Console.WriteLine(paymentCard.GetFullInformation());
            }*/
            return true;
        }
        static void Main(string[] args)
        {
            PaymentCard paymentCard1 = new PaymentCard(1, 2027, "Kate", "Bayok", 123);
       
            PaymentCard paymentCard2 = new PaymentCard(2, 2024, "Artyom", "Vasilyev", 234);
         
            PaymentCard paymentCard3 = new PaymentCard(3, 2026, "Anna", "Antonova", 157);
           
            PaymentCard paymentCard4 = new PaymentCard(4, 2025, "Kirill", "Kirkorov", 888);
           
            PaymentCard paymentCard5 = new PaymentCard(5, 2023, "Anton", "Gigros", 987);
          
            PaymentCard[] paymentCards = new PaymentCard[] { paymentCard1, paymentCard2, paymentCard3, paymentCard4, paymentCard5 };
            InformationCard(paymentCards); 
        }
    }
}
