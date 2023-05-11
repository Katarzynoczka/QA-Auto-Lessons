using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                Validity validity1 = new Validity(02, 2023);
                Validity validity2 = new Validity(12, 2026);
                Validity validity3 = new Validity(01, 2027);
                Validity validity4 = new Validity(07, 2023);
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
                Validity validity15 = new Validity(08, 2023);
           
            BankClient bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            BankClient bankClient2 = new BankClient("Artyom", "Vasilyev", "Minskaya 1");
            BankClient bankClient3 = new BankClient("Anna", "Antonova", "Pragskaya 123");
            BankClient bankClient4 = new BankClient("Kirill", "Kirkorov", "lotnicza 18");
            BankClient bankClient5 = new BankClient("Anton", "Gigros", "Koszykarska 983");

            List<BankClient> bankClients = new List<BankClient> { bankClient1, bankClient2, bankClient3, bankClient4, bankClient5 };
           
            bankClient1.AddPaymentMethod(new Cash(100000f));
            bankClient1.AddPaymentMethod(new CashBackCard(validity1, 1000f, 12f));
            bankClient1.AddPaymentMethod(new CreditCard(validity6, 13f, 2000f));
            bankClient1.AddPaymentMethod(new DebetCard(validity11, 100f));
            //bankClient1.AddPaymentMethod(new BitCoin(100f));

            bankClient2.AddPaymentMethod(new Cash(10f));
            bankClient2.AddPaymentMethod(new CashBackCard(validity2, 100f, 2f));
            bankClient2.AddPaymentMethod(new CreditCard(validity7, 22f, 100f));
            bankClient2.AddPaymentMethod(new DebetCard(validity12, 999f));
            bankClient2.AddPaymentMethod(new BitCoin(100f));

            bankClient3.AddPaymentMethod(new Cash(1000f));
            bankClient3.AddPaymentMethod(new CashBackCard(validity3, 300f, 5f));
            bankClient3.AddPaymentMethod(new CreditCard(validity8, 1f, 150f));
            bankClient3.AddPaymentMethod(new DebetCard(validity13, 10f));
            bankClient3.AddPaymentMethod(new BitCoin(100f));

            bankClient4.AddPaymentMethod(new Cash(5000f));
            bankClient4.AddPaymentMethod(new CashBackCard(validity4, 2200f, 20f));
            bankClient4.AddPaymentMethod(new CreditCard(validity9, 30f, 1000f));
            bankClient4.AddPaymentMethod(new DebetCard(validity14, 68543f));
            bankClient4.AddPaymentMethod(new BitCoin(100f));

            bankClient5.AddPaymentMethod(new Cash(10f));
            bankClient5.AddPaymentMethod(new CashBackCard(validity5, 500f, 25f));
            bankClient5.AddPaymentMethod(new CreditCard(validity10, 90f, 5555f));
            bankClient5.AddPaymentMethod(new DebetCard(validity15, 9999f));
            bankClient5.AddPaymentMethod(new BitCoin(100f));


            var sortedName = bankClients.OrderBy(x => x.Name).ToList();

            var sortAddres = bankClients.OrderBy(x => x.Addres).ToList();

            var sortAmountCards = bankClients.OrderBy(x => x.paymentMethods.Count).ToList();
          
            Console.WriteLine("Sort by the total amount of money available:");
            var filteredClients = bankClients
                .Select(bankClient => new {Name = bankClient.Name, Surname = bankClient.SurName, Balance = bankClient.paymentMethods.Sum(x => x.GetBalance()) })
                .OrderBy(x => x.Balance);
            foreach (var x in filteredClients)
            {
                Console.WriteLine($"{x.Balance} - {x.Name} {x.Surname}");
            }     
            
            Console.WriteLine("\nList of all debet cards for the client:");
            var sumDebet = bankClients.SelectMany(bankClient => bankClient.paymentMethods.OfType<DebetCard>(),
             (bankClient, debetCard) => new { bankClient.Name, bankClient.SurName, debetCard.Validity, debetCard.BalanceDebet});
            foreach (var x in sumDebet)
            {
                Console.WriteLine($"{x.Name} {x.SurName}: Validity-{x.Validity.ValidityDay}/{x.Validity.ValidityYear}, Balance:{x.BalanceDebet} ");
            }

            Console.WriteLine("\nThe richest client:");
            var richestClient = bankClients.Select(bankClient => new {BankClient = bankClient, TotalBalance = bankClient.paymentMethods
                .Sum(paymentMethod => paymentMethod.GetBalance())}).OrderByDescending(x => x.TotalBalance).First();
            Console.WriteLine($"{richestClient.BankClient.Name} {richestClient.BankClient.SurName}: {richestClient.TotalBalance}");

            Console.WriteLine("\nClients with BitCoin:");
            var bitCoinClients = bankClients.Where(bankClient => bankClient.paymentMethods.Any(x => x is BitCoin))
                .Select(bankClient => new { Name = bankClient.Name, Surname = bankClient.SurName, Balance = bankClient.paymentMethods.Sum(paymentMethod => paymentMethod.GetBalance()) })
                .OrderByDescending(x => x.Balance);
            foreach (var x in bitCoinClients)
            {
                Console.WriteLine($"{x.Name} {x.Surname}");
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

            catch (Exception ex)
            {
               Console.WriteLine (ex.Message );
               Console.WriteLine (ex.StackTrace);
            }
            
        }
    }
}
