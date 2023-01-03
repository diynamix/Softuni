namespace Chainblock.Tests
{
    using System;
    using Moq;

    using Chainblock.Contracts;
    using Chainblock.Models;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        //[Test]
        //public void ConstructorShouldInitializeIdProperly()
        //{
        //    int expectedId = 1;

        //    Mock<ITransaction> transactionMock = new Mock<ITransaction>();
        //    transactionMock.Setup(m => m.Id).Returns(1);
        //    transactionMock.Setup(m => m.Status).Returns(TransactionStatus.Successfull);
        //    transactionMock.Setup(m => m.From).Returns("Peter");
        //    transactionMock.Setup(m => m.To).Returns("George");
        //    transactionMock.Setup(m => m.Amount).Returns(1000);

        //    int actualId = transactionMock.Object.Id;

        //    Assert.AreEqual(expectedId, actualId);
        //}

        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            int expectedId = 1;

            ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "Peter", "George", 1000);

            int actualId = transaction.Id;
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void ConstructorShouldInitializeStatusProperly()
        {
            TransactionStatus expectedStatus = TransactionStatus.Successfull;

            ITransaction transaction = new Transaction(1, expectedStatus, "Peter", "George", 1000);

            TransactionStatus actualStatus = transaction.Status;
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ConstructorShouldInitializeSenderProperly()
        {
            string expectedSender = "Peter";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedSender, "George", 1000);

            string actualSender = transaction.From;
            Assert.AreEqual(expectedSender, actualSender);
        }

        [Test]
        public void ConstructorShouldInitializeReceiverProperly()
        {
            string expectedReceiver = "George";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Peter", expectedReceiver, 1000);

            string actualReceiver = transaction.To;
            Assert.AreEqual(expectedReceiver, actualReceiver);
        }

        [Test]
        public void ConstructorShouldInitializeAmountProperly()
        {
            decimal expectedAmount = 1000;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Peter", "George", expectedAmount);

            decimal actualAmount = transaction.Amount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }


        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(0)]
        public void IdSetterShouldThrowExceptionWithZeroOrNegativeId(int id)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(id, TransactionStatus.Successfull, "Peter", "George", 1000);
            }, "Id should be a positive number!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void SenderSetterShouldThrowExceptionWithNullOrWhiteSpaceString(string sender)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, sender, "George", 1000);
            }, "Sender name cannot be null or white space string!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void ReceiverSetterShouldThrowExceptionWithNullOrWhiteSpaceString(string receiver)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Peter", receiver, 1000);
            }, "Receiver name cannot be null or white space string!");
        }

        [TestCase(-100)]
        [TestCase(-0.00000001)]
        [TestCase(0)]
        public void AmountSetterShouldThrowExceptionWithZeroOrNegativeAmount(decimal amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Peter", "George", amount);
            }, "Amount should be a positive number!");
        }
    }
}
