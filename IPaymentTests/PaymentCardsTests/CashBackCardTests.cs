﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentCard;

namespace IPaymentTests.PaymentCardsTests
{
    [TestClass]
    public class CashBackCardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CashBackExceptionTest()
        {
            var cashBackCard = new CashBackCard(null, -1000f, 1f);
        }

        [TestMethod]
        public void CashBackCardEqualsMethodTestPositive()
        {
            var cashBackCard1 = new CashBackCard(null, 1000f, 1f);
            var cashBackCard2 = new CashBackCard(null, 1000f, 1f);
            Assert.AreEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        [DataRow(null, 2000f, 1f)]
        [DataRow(null, 1000f, 10f)]
        public void CashBackCardEqualsMethodTestNegative(Validity validity, float balanceCashBack, float percentCashBack)
        {
            var cashBackCard1 = new CashBackCard(null, 1000f, 1f);
            var cashBackCard2 = new CashBackCard(validity, balanceCashBack, percentCashBack);
            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardMakePaymentMethodTestPositive()
        {
            var cashBackCard = new CashBackCard(null, 1000f, 1f);
            var result = cashBackCard.MakePayment(1000f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CashBackCardMakePaymentMethodTestNegative()
        {
            var cashBackCard = new CashBackCard(null, 1000f, 1f);
            var result = cashBackCard.MakePayment(5000f);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CashBackCardGetBalanceMethodTestPositive()
        {
            var cashBackCard = new CashBackCard(null, 1000f, 1f);
            var result = cashBackCard.GetBalance();
            Assert.AreEqual(1000f, result);
        }

        [TestMethod]
        public void CashBackCardTopUpMethodTestPositive()
        {
            var cashBackCard = new CashBackCard(null, 1000f, 1f);
            cashBackCard.TopUp(1000f);
            var result = cashBackCard.GetBalance();
            Assert.AreEqual(2000f, result);
        }

        [TestMethod]
        public void CashBackCardTopUpMethodTestNegative()
        {
            var cashBackCard = new CashBackCard(null, 1000f, 1f);
            cashBackCard.TopUp(1000f);
            var result = cashBackCard.GetBalance();
            Assert.AreNotEqual(1000f, result);
        }
    }
}
