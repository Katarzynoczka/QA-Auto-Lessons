using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class Program
    {

        static void Main(string[] args)
        {
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

            BankClient bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            BankClient bankClient2 = new BankClient("Artyom", "Vasilyev", "minskaya 1");
            BankClient bankClient3 = new BankClient("Anna", "Antonova", "pragskaya 123");
            BankClient bankClient4 = new BankClient("Kirill", "Kirkorov", "lotnicza 18");
            BankClient bankClient5 = new BankClient("Anton", "Gigros", "Koszykarska 983");

            CashBackCard paymentMethod1 = new CashBackCard(bankClient1, validity1, 123, 1000, 12);
            CashBackCard paymentMethod2 = new CashBackCard(bankClient2, validity2, 234, 100, 2);
            CashBackCard paymentMethod3 = new CashBackCard(bankClient3, validity3, 157, 300, 5);
            CashBackCard paymentMethod4 = new CashBackCard(bankClient4, validity4, 888, 2200, 20);
            CashBackCard paymentMethod5 = new CashBackCard(bankClient5, validity5, 987, 500, 25);
            
             CreditCard paymentMethod6 = new CreditCard(bankClient1, validity6, 001, 13f, 2000f);
             CreditCard paymentMethod7 = new CreditCard(bankClient2, validity7, 999, 22f, 100f);
             CreditCard paymentMethod8 = new CreditCard(bankClient3, validity8, 191, 1f, 150f);
             CreditCard paymentMethod9 = new CreditCard(bankClient4, validity9, 010, 30f, 100000000f);
             CreditCard paymentMethod10 = new CreditCard(bankClient5, validity10, 009, 90f, 55555f);
            
            DebetCard paymentMethod11 = new DebetCard(bankClient1, validity11, 666, 100000000f);
            DebetCard paymentMethod12 = new DebetCard(bankClient2, validity12, 455, 999f);
            DebetCard paymentMethod13 = new DebetCard(bankClient3, validity13, 000, 10f);
            DebetCard paymentMethod14 = new DebetCard(bankClient4, validity14, 883, 68543f);
            DebetCard paymentMethod15 = new DebetCard(bankClient5, validity15, 546, 9999f);

            Cash paymentMethod16 = new Cash(bankClient1, 10000f);
            Cash paymentMethod17 = new Cash(bankClient2, 100f);
            Cash paymentMethod18 = new Cash(bankClient3, 1000f);
            Cash paymentMethod19 = new Cash(bankClient4, 5000f);
            Cash paymentMethod20 = new Cash(bankClient5, 10f);



            List<IPayment> paymentMethods1 = new List<IPayment>() { paymentMethod1, paymentMethod6, paymentMethod11, paymentMethod16 };
            List<IPayment> paymentMethods2 = new List<IPayment>() { paymentMethod2, paymentMethod7, paymentMethod12, paymentMethod17 };
            List<IPayment> paymentMethods3 = new List<IPayment>() { paymentMethod3, paymentMethod8, paymentMethod13, paymentMethod18 };
            List<IPayment> paymentMethods4 = new List<IPayment>() { paymentMethod4, paymentMethod9, paymentMethod14, paymentMethod19 };
            List<IPayment> paymentMethods5 = new List<IPayment>() { paymentMethod5, paymentMethod10, paymentMethod15, paymentMethod20 };

            // производим несколько платежей
            bankClient1.Pay(1000, paymentMethods1);
            bankClient2.Pay(10, paymentMethods2);
            bankClient3.Pay(500, paymentMethods3);
            bankClient4.Pay(10000, paymentMethods4);
            bankClient5.Pay(100, paymentMethods5);

            bankClient1.DisplayBalances(paymentMethods1);
            bankClient2.DisplayBalances(paymentMethods2);
            bankClient3.DisplayBalances(paymentMethods3);
            bankClient4.DisplayBalances(paymentMethods4);
            bankClient5.DisplayBalances(paymentMethods5);
        }
    }
}
