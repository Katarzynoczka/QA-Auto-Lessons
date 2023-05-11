using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentCard;

namespace IPaymentTests.BankCore
{
    [TestClass]
    public class ValidityTests
    {
        [TestMethod]
        public void ValidityEqualsMethodTestPositive()
        {
            Validity validity1 = new Validity(12, 2023);
            Validity validity2 = new Validity(12, 2023);

            Assert.AreEqual(validity1, validity2);
        }

        [TestMethod]
        public void ValidityEqualsMethodTestNegative()
        {
            Validity validity1 = new Validity(12, 2023);
            Validity validity2 = new Validity(1, 2023);

            Assert.AreNotEqual(validity1, validity2);
        }

        [TestMethod]
        [DataRow(0, 2023)]
        [DataRow(1, 2022)]
        [DataRow(13, 2024)]
        [ExpectedException(typeof(FormatException))]
        public void ValidityExceptionTest(int validityDay, int validityYear)
        {
            Validity validity = new Validity(validityDay, validityYear);
        }

    }
}
