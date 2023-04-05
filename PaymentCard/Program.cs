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
            Customer customer6 = new Customer("John", "Rolling", "First 5", 123456789);
            Customer customer7 = new Customer("Julia", "Poles", "Lockdauw 765", 11111111111111);
            Customer customer8 = new Customer("Валера", "Сидорович", "Купаловская 25", 291001010);
            Customer customer9 = new Customer("Grzegosz", "Bykinski", "Wroclawska 1a", 19191919191919);
            Customer customer10 = new Customer("$%%^&*()", "#$%$^&&", "@#$%^&*(", 90909090909090);
            Customer customer11 = new Customer("ვალერა", "ვალერიანი", "ჰამარჯობა 56", 995555917135);

            Validity validity1 = new Validity(02, 2023);
            Validity validity2 = new Validity(12, 2026);
            Validity validity3 = new Validity(01, 2027);
            Validity validity4 = new Validity(07, 2022);
            Validity validity5 = new Validity(10, 2028);
            Validity validity6 = new Validity(05, 2024);
            Validity validity7 = new Validity(01, 2030);
            Validity validity8 = new Validity(11, 2040);
            Validity validity9 = new Validity(03, 2050);
            Validity validity10 = new Validity(10, 2029);
            Validity validity11 = new Validity(11, 2031);
            Validity validity12 = new Validity(01, 2023);
            Validity validity13 = new Validity(04, 2025);
            Validity validity14 = new Validity(06, 2067);
            Validity validity15 = new Validity(06, 2067);

            PaymentCard paymentCard1 = new PaymentCard(1, validity1, customer1, 123);
            PaymentCard paymentCard2 = new PaymentCard(2, validity2, customer2, 234);
            PaymentCard paymentCard3 = new PaymentCard(3, validity3, customer3, 157);
            PaymentCard paymentCard4 = new PaymentCard(4, validity4, customer4, 888);
            PaymentCard paymentCard5 = new PaymentCard(5, validity5, customer5, 987);

            CreditCard paymentCard6 = new CreditCard(6, validity6, customer6, 001, 13, 2000);
            CreditCard paymentCard7 = new CreditCard(7, validity7, customer7, 999, 22, 100);
            CreditCard paymentCard8 = new CreditCard(8, validity8, customer8, 191, 1, 150);
            CreditCard paymentCard9 = new CreditCard(9, validity9, customer9, 010, 30, 100000000);
            CreditCard paymentCard10 = new CreditCard(10, validity10, customer10, 009, 90, 55555);

            DebetCard paymentCard11 = new DebetCard(11, validity11, customer5, 666, 100, 100000000);
            DebetCard paymentCard12 = new DebetCard(12, validity12, customer1, 456, 9, 999);
            DebetCard paymentCard13 = new DebetCard(13, validity13, customer11, 000, 1, 10);
            DebetCard paymentCard14 = new DebetCard(14, validity14, customer6, 8883, 707, 68543286);
            DebetCard paymentCard15 = new DebetCard(15, validity15, customer10, 546, 25, 9999);




            PaymentCard[] paymentCards = new PaymentCard[] { paymentCard1, paymentCard2, paymentCard3, paymentCard4, paymentCard5,
                                                             paymentCard6, paymentCard7, paymentCard8, paymentCard9, paymentCard10,
                                                             paymentCard11, paymentCard12, paymentCard13,paymentCard14,paymentCard15};
            CreditCard creditCard = (CreditCard)paymentCards[5];
            CreditCard creditCard1 = (CreditCard)paymentCards[6];
            CreditCard creditCard2 = (CreditCard)paymentCards[7];
            CreditCard creditCard3 = (CreditCard)paymentCards[8];
            CreditCard creditCard4 = (CreditCard)paymentCards[9];

            DebetCard debetCard = (DebetCard)paymentCards[10];
            DebetCard debetCard1 = (DebetCard)paymentCards[11];
            DebetCard debetCard2 = (DebetCard)paymentCards[12];
            DebetCard debetCard3 = (DebetCard)paymentCards[13];
            DebetCard debetCard4 = (DebetCard)paymentCards[14];


            InformationCard(paymentCards); 
        }
    }
}
