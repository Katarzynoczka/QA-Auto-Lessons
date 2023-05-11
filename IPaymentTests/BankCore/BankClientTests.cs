using System.Linq;
using System.Net.Sockets;
using System.Xml.Linq;
using PaymentCard;


namespace IPaymentTests.BankCore
{
    [TestClass]
    public class BankClientTests
    {
        [TestMethod]
        public void BankClientToStringMethodTestPositive()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            string expectedResult = "Kate Bayok, Goreckogo 9";
            string actualResult = bankClient.ToString();

            Assert.IsTrue(actualResult == expectedResult);
        }

        [TestMethod]
        public void BankClientToStringMethodTestNegative()
        {

            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            string expectedResult = "Kate Bayok Goreckogo 9";
            string actualResult = bankClient.ToString();

            Assert.IsFalse(actualResult == expectedResult);
        }

        [TestMethod]
        public void BankClientEqualsMethodTestPositive()
        {
            BankClient bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            bankClient1.AddPaymentMethod(new CashBackCard(null, 300f, 5f));
            BankClient bankClient2 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient2.AddPaymentMethod(new Cash(1000f));
            bankClient2.AddPaymentMethod(new CashBackCard(null, 300f, 5f));

            Assert.AreEqual(bankClient1, bankClient2);
        }

        [TestMethod]
        [DataRow("K", "Bayok", "Goreckogo 9")]
        [DataRow("Kate", "B", "Goreckogo 9")]
        [DataRow("Kate", "Bayok", "G")]

        public void BankClientEqualsTestNegative(string name, string surName, string addres)
        {
            BankClient bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            BankClient bankClient2 = new BankClient(name, surName, addres);
            bankClient2.AddPaymentMethod(new Cash(1000f));

            Assert.AreNotEqual(bankClient1, bankClient2);
        }

        [TestMethod]
        public void BankClientEqualsMethodTestWithListNegative()
        {
            BankClient bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            BankClient bankClient2 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient2.AddPaymentMethod(new Cash(1000f));
            bankClient2.AddPaymentMethod(new CashBackCard(null, 300f, 5f));

            Assert.AreNotEqual(bankClient1, bankClient2);
        }

        [TestMethod]
        public void BankClientEqualsMethodTestWithOnePaymentMethodNegative()
        {
            BankClient bankClient1 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient1.AddPaymentMethod(new Cash(1000f));
            BankClient bankClient2 = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient2.AddPaymentMethod(new Cash(2000f));

            Assert.AreNotEqual(bankClient1, bankClient2);
        }
        [TestMethod]
        public void BankClientAddPaymentMethodTestPositive()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            Assert.AreEqual(0, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(1, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreEqual(2, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new CreditCard(null, 13f, 2000f));
            Assert.AreEqual(3, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new DebetCard(null, 100f));
            Assert.AreEqual(4, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new BitCoin(100f));
            Assert.AreEqual(5, bankClient.paymentMethods.Count);
        }

        [TestMethod]
        public void BankClientAddPaymentMethodTestNegative()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(0, bankClient.paymentMethods.Count);
        }

        [TestMethod]
        public void BankClientAddPaymentMethodTestDuplicatePositive()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(1, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreEqual(2, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new CreditCard(null, 13f, 2000f));
            bankClient.AddPaymentMethod(new CreditCard(null, 13f, 2000f));
            Assert.AreEqual(3, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new DebetCard(null, 100f));
            bankClient.AddPaymentMethod(new DebetCard(null, 100f));
            Assert.AreEqual(4, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new BitCoin(100f));
            bankClient.AddPaymentMethod(new BitCoin(100f));
            Assert.AreEqual(5, bankClient.paymentMethods.Count);
        }

        [TestMethod]
        public void BankClientAddPaymentMethodTestDuplicateNegative()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(2, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreNotEqual(4, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new CreditCard(null, 13f, 2000f));
            bankClient.AddPaymentMethod(new CreditCard(null, 13f, 2000f));
            Assert.AreNotEqual(6, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new DebetCard(null, 100f));
            bankClient.AddPaymentMethod(new DebetCard(null, 100f));
            Assert.AreNotEqual(8, bankClient.paymentMethods.Count);
            bankClient.AddPaymentMethod(new BitCoin(100f));
            bankClient.AddPaymentMethod(new BitCoin(100f));
            Assert.AreNotEqual(10, bankClient.paymentMethods.Count);
        }

        [TestMethod]
        [DataRow("", "Bayok", "Goreckogo 9")]
        [DataRow(null, "Bayok", "Goreckogo 9")]
        [DataRow("qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm", "Bayok", "Goreckogo 9")]
        [DataRow("Kate", "", "Goreckogo 9")]
        [DataRow("Kate", null, "Goreckogo 9")]
        [DataRow("Kate", "qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmBayok", "Goreckogo 9")]
        [ExpectedException(typeof(ArgumentException))]
        public void BankClientNameSurNameExceptionTest(string name, string surName, string addres)
        {
            BankClient bankClient = new BankClient(name, surName, addres);
        }

        [TestMethod]
        [DataRow("Kate", "Bayok", "")]
        [DataRow("Kate", "Bayok", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BankClientAddresExceptionTest(string name, string surName, string addres)
        {
            BankClient bankClient = new BankClient(name, surName, addres);
        }

        [TestMethod]
        public void BankClientPayMethodEnoughMoneyTestPositive()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CreditCard(null, 1000f, 2000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new DebetCard(null, 1000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreEqual(true, bankClient.Pay(1000f));
        }

        [TestMethod]
        public void BankClientPayMethodEnoughMoneyTestNegative()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new CreditCard(null, 1000f, 2000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new DebetCard(null, 1000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreNotEqual(false, bankClient.Pay(1000f));
        }

        [TestMethod]
        public void BankClientPayMethodNotEnoughMoneyTestPositive()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CreditCard(null, 1000f, 2000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new DebetCard(null, 1000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreEqual(false, bankClient.Pay(5000f));
        }

        [TestMethod]
        public void BankClientPayMethodNotEnoughMoneyTestNegative()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.AddPaymentMethod(new Cash(1000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CashBackCard(null, 1000f, 12f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new CreditCard(null, 1000f, 2000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new DebetCard(null, 1000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
            bankClient.AddPaymentMethod(new BitCoin(1000f));
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
        }

        [TestMethod]
        public void BankClientPayMethodZeroPaymentMethodTest()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            Assert.AreNotEqual(true, bankClient.Pay(5000f));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BankClientPayMethodNegativeSumExceptionTest()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.Pay(-1000f);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BankClientPayMethodZeroSumExceptionTest()
        {
            BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
            bankClient.Pay(0);
        }

        //[TestMethod]
        //public void BankClientDisplayBalanceTestPositive()
        //{
        //    BankClient bankClient = new BankClient("Kate", "Bayok", "Goreckogo 9");
        //    var paymentMethods = new List<IPayment> {new Cash(1000f), new CashBackCard(null, 1000f, 12f), new CreditCard(null, 1000f, 0f),
        //        new DebetCard(null, 1000f), new BitCoin(1000f)};

        //    var stringWriter = new StringWriter();
        //    Console.SetOut(stringWriter);
        //    bankClient.DisplayBalances(paymentMethods);

        //    var expectedResult =
        //    "\nCurrent balances:\n" +
        //    "Cash: 1000\n" +
        //    "CashBack card: 1000\n" +
        //    "Credit card: 1000\n" +
        //    "Debet card: 1000\n" +
        //    "BitCoin: 1000\n";

        //    var actualResult = stringWriter.ToString();
        //    Assert.AreEqual(expectedResult, actualResult);
        //}

    }
}
