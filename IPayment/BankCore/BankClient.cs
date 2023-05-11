using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard
{
    public class BankClient
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentException("Invalid Name format");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private string _surName;
        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentException("Invalid Sur Name format");
                }
                else
                {
                    _surName = value;
                }
            }

        }
        private string _addres;
        public string Addres
        {
            get
            {
                return _addres;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid Address format");
                }
                else
                {
                    _addres = value;
                }
            }
        }

        public List<IPayment> paymentMethods;

        public BankClient(string name, string surName, string addres)
        {
            Name = name;
            SurName = surName;
            Addres = addres;
            paymentMethods = new List<IPayment>();
        }

        public override string ToString()
        {
            return Name + " " + SurName + ", " + Addres;
        }
        public override bool Equals(object obj)
        {
            if (obj is BankClient)
            {
                BankClient bankClient = obj as BankClient;
                return bankClient.Name == Name &&
                    bankClient.SurName == SurName &&
                    bankClient.Addres == Addres &&
                    bankClient.paymentMethods.Sum(x => x.GetBalance()) == paymentMethods.Sum(x => x.GetBalance());
            }
            return false;
        }

        public bool AddPaymentMethod(IPayment Mean)
        {
            foreach (var mean in paymentMethods)
                if (mean.Equals(Mean))
                {
                    return false;
                }
            paymentMethods.Add(Mean);
            return true;
        }

        public bool Pay(float amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid payment amount");
            }
            else
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
                else if (paymentMethod is BitCoin bitCoin)
                {
                    Console.WriteLine($"BitCoin: {bitCoin.GetBalance()}");
                }
            }
        }

    }
}

