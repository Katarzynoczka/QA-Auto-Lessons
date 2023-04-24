using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PaymentCard.Comparers;

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

            List<BankClient> bankClients = new List<BankClient> { bankClient1, bankClient2, bankClient3, bankClient4, bankClient5 };
           
            Console.WriteLine("Sort by the name of bank client:");
            bankClients.Sort((x, y) => string.Compare(x.Name, y.Name));
            foreach (BankClient bankClient in bankClients) 
            { 
                Console.WriteLine(bankClient.Name); 
            }

            Console.WriteLine("Sort by the address of bank client:");
            bankClients.Sort(new ClientAddresComparer());
            foreach (BankClient bankClient in bankClients)
            {
                Console.WriteLine(bankClient.Addres);
            }


            bankClient1.AddPaymentMethod(new Cash(1000f));
            bankClient1.AddPaymentMethod(new CashBackCard(validity1, 1000, 12));
            bankClient1.AddPaymentMethod(new CreditCard(validity6, 13f, 2000f));
            bankClient1.AddPaymentMethod(new DebetCard(validity11, 100f));


            bankClient2.AddPaymentMethod(new Cash(10f));
            //bankClient2.AddPaymentMethod(new CashBackCard(validity2, 100, 2));
            bankClient2.AddPaymentMethod(new CreditCard(validity7, 22f, 100f));
            bankClient2.AddPaymentMethod(new DebetCard(validity12, 999f));

            bankClient3.AddPaymentMethod(new Cash(1000f));
            bankClient3.AddPaymentMethod(new CashBackCard(validity3, 300, 5));
            bankClient3.AddPaymentMethod(new CreditCard(validity8, 1f, 150f));
            //bankClient3.AddPaymentMethod(new DebetCard(validity13, 10f));

            bankClient4.AddPaymentMethod(new Cash(5000f));
            //bankClient4.AddPaymentMethod(new CashBackCard(validity4, 2200, 20));
            //bankClient4.AddPaymentMethod(new CreditCard(validity9, 30f, 100000000f));
            //bankClient4.AddPaymentMethod(new DebetCard(validity14, 68543f));

            bankClient5.AddPaymentMethod(new Cash(10f));
            bankClient5.AddPaymentMethod(new CashBackCard(validity5, 500, 25));
            //bankClient5.AddPaymentMethod(new CreditCard(validity10, 90f, 5555f));
            //bankClient5.AddPaymentMethod(new DebetCard(validity15, 9999f));

            Console.WriteLine("Sort by the amount of plastic cards:");
            bankClients.Sort(new ClientPaymentMethodsCountComparer());
            foreach (BankClient bankClient in bankClients)
            {
               Console.WriteLine($"{bankClient.paymentMethods.Count} - { bankClient.Name} { bankClient.SurName}");
            }

            Console.WriteLine("Sort by the total amount of money available:");
            var comparer = new ClientTotalAmountMoneyComparer();
            bankClients.Sort(new ClientTotalAmountMoneyComparer());
            foreach (BankClient bankClient in bankClients)
            {
                Console.WriteLine($"{comparer.GetTotalAmountMoney(bankClient)} - {bankClient.Name} {bankClient.SurName}");
            }

            Console.WriteLine("Sort by maximum amount of money on one method payment:");
            var comparer1 = new ClientMaxAmountOnOnePaymentMethod();
            bankClients.Sort(new ClientMaxAmountOnOnePaymentMethod());
            foreach (BankClient bankClient in bankClients)
            {
                Console.WriteLine($"{comparer1.GetMaxAmountMoney(bankClient)} - {bankClient.Name} {bankClient.SurName}");
            }


            bankClient1.Pay(1000);
            bankClient1.DisplayBalances(bankClient1.paymentMethods);

            bankClient2.Pay(100);
            bankClient2.DisplayBalances(bankClient2.paymentMethods);

            bankClient3.Pay(50000);
            bankClient3.DisplayBalances(bankClient3.paymentMethods);

            bankClient4.Pay(10000);
            bankClient4.DisplayBalances(bankClient4.paymentMethods);

            bankClient5.Pay(9999);
            bankClient5.DisplayBalances(bankClient5.paymentMethods);

  

        }
    }
}
