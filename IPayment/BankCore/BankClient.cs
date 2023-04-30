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
       
        public List<IPayment> paymentMethods {  get; set; }

        public BankClient(string name, string surName, string addres)
        {
            Name = name;
            SurName = surName;
            Addres = addres;
            paymentMethods = new List<IPayment>();
        }
 
        public bool AddPaymentMethod(IPayment Mean)
        {
            paymentMethods.Add(Mean);
            return true;
        }

        public bool Pay(float amount)
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
                        Console.WriteLine($"\nPayment {amount} made with Cash");
                        break;
                    }
                }
                else if (paymentMethod is CashBackCard cashBackCard)
                {
                    if (cashBackCard.GetBalance() >= amount)
                    {
                        cashBackCard.MakePayment(amount);
                        paymentSuccessful = true;
                        Console.WriteLine($"\nPayment {amount} made with CashBackCard");
                        break;
                    }
                }
                else if (paymentMethod is DebetCard debetCard)
                {
                    if (debetCard.GetBalance() >= amount)
                    {
                        debetCard.MakePayment(amount);
                        paymentSuccessful = true;
                        Console.WriteLine($"\nPayment {amount} made with DebetCard");
                        break;
                    }
                }
                else if (paymentMethod is CreditCard creditCard)
                {
                    if (creditCard.GetBalance() >= amount)
                    {
                        creditCard.MakePayment(amount);
                        paymentSuccessful = true;
                        Console.WriteLine($"\nPayment {amount} made with CreditCard");
                        break;
                    }
                }
                else if (paymentMethod is BitCoin bitCoin)
                {
                    if (bitCoin.GetBalance() >= amount)
                    {
                        bitCoin.MakePayment(amount);
                        paymentSuccessful = true;
                        Console.WriteLine($"\nPayment {amount} made with BitCoin");
                        break;
                    }
                }

            }

            if (!paymentSuccessful)
            {
                Console.WriteLine("\nPayment failed. Insufficient funds.");
            }

            return paymentSuccessful;
        }

        public void DisplayBalances(List<IPayment> paymentMethods)
        {
            Console.WriteLine("\nCurrent balances:");
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

