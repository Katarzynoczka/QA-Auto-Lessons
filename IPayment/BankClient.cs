using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    internal class BankClient
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Addres{ get; set; }
       
        public List<IPayment> paymentMethods;

        public BankClient(string name, string surName, string addres)
        {
            Name = name;
            SurName = surName;
            Addres = addres;
        }

        public bool Pay(float amount, List<IPayment> paymentMethods)
        {
            bool paymentSuccessful = false;

            foreach (IPayment paymentMethod in paymentMethods)
            {
                if (paymentMethod is Cash cash)
                {
                    if (cash.GetBalance() >= amount)
                    {
                        cash.MakePayment(amount);
                        paymentSuccessful = true;
                        break;
                    }
                }
                else if (paymentMethod is CashBackCard cashBackCard)
                {
                    if (cashBackCard.GetBalance() >= amount)
                    {
                        cashBackCard.MakePayment(amount);
                        paymentSuccessful = true;
                        break;
                    }
                }
                else if (paymentMethod is DebetCard debetCard)
                {
                    if (debetCard.GetBalance() >= amount)
                    {
                        debetCard.MakePayment(amount);
                        paymentSuccessful = true;
                        break;
                    }
                }
                else if (paymentMethod is CreditCard creditCard)
                {
                    if (creditCard.GetBalance() >= amount)
                    {
                        creditCard.MakePayment(amount);
                        paymentSuccessful = true;
                        break;
                    }
                }
            }

            if (!paymentSuccessful)
            {
                Console.WriteLine("Payment failed. Insufficient funds.");
            }

            return paymentSuccessful;
        }

        public void DisplayBalances(List<IPayment> paymentMethods)
        {
            Console.WriteLine("Current balances:");
            foreach (IPayment paymentMethod in paymentMethods)
            {
                if (paymentMethod is Cash cash)
                {
                    Console.WriteLine($"Cash: {cash.GetBalance()}");
                }
                else if (paymentMethod is CashBackCard cashBackCard)
                {
                    Console.WriteLine($"CashBack card: {cashBackCard.GetBalance()}");
                }
                else if (paymentMethod is DebetCard debetCard)
                {
                    Console.WriteLine($"Debet card: {debetCard.GetBalance()}");
                }
                else if (paymentMethod is CreditCard creditCard)
                {
                    Console.WriteLine($"Credit card: {creditCard.GetBalance()}");
                }
            }
        }
    }


}

