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
                string informationCard = paymentCard.GetFullInformation();
                Console.WriteLine(informationCard);
            }
            return true;
        }
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("Kate", "Bayok", "Goreckogo 9", 293413917);
            Customer customer2 = new Customer("Artyom", "Vasilyev", "minskaya 1", 48674532888);
            Customer customer3 = new Customer("Anna", "Antonova", "pragskaya 123", 337685647);
            Customer customer4 = new Customer("Kirill", "Kirkorov", "lotnicza 18", 48572255187);
            Customer customer5 = new Customer("Anton", "Gigros", "Koszykarska 983", 48999999999);

            Validity validity1 = new Validity(02, 2023);
            Validity validity2 = new Validity(12, 2026);
            Validity validity3 = new Validity(01, 2027);
            Validity validity4 = new Validity(07, 2022);
            Validity validity5 = new Validity(10, 2028);

            PaymentCard paymentCard1 = new PaymentCard(1, validity1, customer1, 123);
            PaymentCard paymentCard2 = new PaymentCard(2, validity2, customer2, 234);
            PaymentCard paymentCard3 = new PaymentCard(3, validity3, customer3, 157);
            PaymentCard paymentCard4 = new PaymentCard(4, validity4, customer4, 888);
            PaymentCard paymentCard5 = new PaymentCard(5, validity5, customer5, 987);
          
            PaymentCard[] paymentCards = new PaymentCard[] { paymentCard1, paymentCard2, paymentCard3, paymentCard4, paymentCard5 };
            InformationCard(paymentCards); 
        }
    }
}
