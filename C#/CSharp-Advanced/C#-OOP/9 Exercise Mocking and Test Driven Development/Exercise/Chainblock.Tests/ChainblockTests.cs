namespace Chainblock.Tests
{
    using NUnit.Framework;

    using Contracts;
    using Models;
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction testTransaction;

        [SetUp]
        public void Setup()
        {
            chainblock = new Chainblock();
            testTransaction = new Transaction(1, TransactionStatus.Successfull, "Peter", "George", 1000);
        }


        // Constuctor
        [Test]
        public void ConstuctorShouldInitializeTransactionCollection()
        {
            Type chainblockType = chainblock.GetType();
            FieldInfo transactionField = chainblockType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "transactions");

            object value = transactionField.GetValue(chainblock);

            Assert.IsNotNull(value);
        }


        // Add
        [Test]
        public void AddShouldAppendTheTransactionToDataCollection()
        {
            chainblock.Add(testTransaction);

            bool transactionAdded = chainblock.Contains(testTransaction);

            Assert.IsTrue(transactionAdded);
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            chainblock.Add(testTransaction);

            int expectedCount = 1;
            int actualCount = chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingSameTransaction()
        {
            chainblock.Add(testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.Add(testTransaction);
            }, "You cannot add already existing transaction");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingExistingId()
        {
            chainblock.Add(testTransaction);
            ITransaction copyTransaction = new Transaction(testTransaction.Id, TransactionStatus.Unauthorized, "John", "Smith", 500);

            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.Add(copyTransaction);
            }, "You cannot add transaction with already existing Id");
        }


        // ContainsByTransaction
        [Test]
        public void ContainsByTransactionShouldReturnTrueWhenExists()
        {
            chainblock.Add(testTransaction);

            bool transactionExists = chainblock.Contains(testTransaction);

            Assert.IsTrue(transactionExists);
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalseWhenNotExist()
        {
            bool transactionExists = chainblock.Contains(testTransaction);

            Assert.IsFalse(transactionExists);
        }


        // ContainsById
        [Test]
        public void ContainsByIdShouldReturnTrueWhenExists()
        {
            chainblock.Add(testTransaction);

            bool transactionExists = chainblock.Contains(testTransaction.Id);

            Assert.IsTrue(transactionExists);
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWhenNotExist()
        {
            bool transactionExists = chainblock.Contains(testTransaction.Id);

            Assert.IsFalse(transactionExists);
        }


        // Count
        [Test]
        public void CountShouldReturnZeroWhenNoTransactionsAreAdded()
        {
            int expectedCount = 0;
            int actualCount = chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        // ChangeTransactionStatus
        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);
            }, "You cannot change the status of non existing transaction!");
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatusIfItIsDifferent()
        {
            chainblock.Add(testTransaction);

            TransactionStatus expectedStatus = TransactionStatus.Unauthorized;

            chainblock.ChangeTransactionStatus(testTransaction.Id, expectedStatus);

            ITransaction changedTransaction = chainblock.GetById(testTransaction.Id);

            TransactionStatus actualStatus = changedTransaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatusShouldRemainStatusIfItIsTheSame()
        {
            chainblock.Add(testTransaction);

            TransactionStatus expectedStatus = testTransaction.Status;

            chainblock.ChangeTransactionStatus(testTransaction.Id, expectedStatus);

            ITransaction changedTransaction = chainblock.GetById(testTransaction.Id);

            TransactionStatus actualStatus = changedTransaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }


        // GetById
        [Test]
        public void GetByIdShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetById(10);
            }, "Transaction with provided id does not exist!");
        }

        [Test]
        public void GetByIdShouldReturnCorrectTransactionWhenExist()
        {
            chainblock.Add(testTransaction);

            ITransaction actualTransaction = chainblock.GetById(testTransaction.Id);

            Assert.AreEqual(testTransaction, actualTransaction);
        }


        // Remove()
        [Test]
        public void RemoveTransactionByIdShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.RemoveTransactionById(10);
            }, "You cannot remove non existing transaction!");
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionFromDataCollectionWhenExists()
        {
            ITransaction transaction = new Transaction(2, TransactionStatus.Failed, "John", "Smith", 500);
            chainblock.Add(testTransaction);
            chainblock.Add(transaction);

            chainblock.RemoveTransactionById(transaction.Id);

            bool transactionExists = chainblock.Contains(transaction);

            Assert.IsFalse(transactionExists);
        }

        [Test]
        public void RemoveTransactionByIdShouldDecreaseCountWhenExists()
        {
            ITransaction transaction = new Transaction(2, TransactionStatus.Failed, "John", "Smith", 500);
            chainblock.Add(testTransaction);
            chainblock.Add(transaction);

            chainblock.RemoveTransactionById(transaction.Id);

            int expectedCount = 1;
            int actualCount = chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        // GetByTransactionStatus
        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetByTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            chainblock.Add(testTransaction);
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetByTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetByTransactionStatusShouldReturnSingleTransactionWhenThereIsOneTransaction()
        {
            // Arrange
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            // Act
            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<ITransaction> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .ToArray();
            ICollection<ITransaction> actualTransactions = chainblock
                .GetByTransactionStatus(wantedStatus)
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetByTransactionStatusShouldReturnManyTransactionsOrderedCorrectly()
        {
            // Arrange
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(3, TransactionStatus.Failed, "Lissa", "Bob", 700),
                new Transaction(4, TransactionStatus.Failed, "John", "Johnny", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            // Act
            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<ITransaction> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();
            ICollection<ITransaction> actualTransactions = chainblock
                .GetByTransactionStatus(wantedStatus)
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }


        // GetAllSendersWithTransactionStatus
        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            chainblock.Add(testTransaction);
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }


        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnOneNameWhenThereIsOneTransactionWithGivenStatus()
        {
            chainblock.Add(testTransaction);

            TransactionStatus wantedStatus = testTransaction.Status;

            ICollection<string> expectedOutput = new string[] { testTransaction.From };

            ICollection<string> actualOutput = chainblock
                .GetAllSendersWithTransactionStatus(wantedStatus)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnManyNamesOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            // Arrange
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(3, TransactionStatus.Failed, "Lissa", "Bob", 700),
                new Transaction(4, TransactionStatus.Failed, "John", "Johnny", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            // Act
            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<string> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();
            ICollection<string> actualTransactions = chainblock
                .GetAllSendersWithTransactionStatus(wantedStatus)
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        // Test whether we receive dublicated names
        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnManyNamesDuplicatedOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            // Arrange
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(3, TransactionStatus.Failed, "Peter", "Bob", 700),
                new Transaction(4, TransactionStatus.Failed, "John", "Johnny", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            // Act
            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<string> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();
            ICollection<string> actualTransactions = chainblock
                .GetAllSendersWithTransactionStatus(wantedStatus)
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }


        // GetAllReceiversWithTransactionStatus
        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            chainblock.Add(testTransaction);
            Assert.Throws<InvalidOperationException>(() =>
            {
                chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed);
            }, "There are no transactions with the provided status!");
        }


        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnOneNameWhenThereIsOneTransactionWithGivenStatus()
        {
            chainblock.Add(testTransaction);

            TransactionStatus wantedStatus = testTransaction.Status;

            ICollection<string> expectedOutput = new string[] { testTransaction.To };

            ICollection<string> actualOutput = chainblock
                .GetAllReceiversWithTransactionStatus(wantedStatus)
                .ToArray();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnManyNamesOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            // Arrange
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(3, TransactionStatus.Failed, "Lissa", "Bob", 700),
                new Transaction(4, TransactionStatus.Failed, "John", "Johnny", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            // Act
            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<string> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();
            ICollection<string> actualTransactions = chainblock
                .GetAllReceiversWithTransactionStatus(wantedStatus)
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        // Test whether we receive dublicated names
        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnManyNamesDuplicatedOrderedWhenThereAreMoreTransactionsWithGivenStatus()
        {
            // Arrange
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(3, TransactionStatus.Failed, "Merry", "George", 700),
                new Transaction(4, TransactionStatus.Failed, "John", "Johnny", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            // Act
            TransactionStatus wantedStatus = TransactionStatus.Successfull;
            ICollection<string> expectedTransactions = transactionsToAppend
                .Where(tx => tx.Status == wantedStatus)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();
            ICollection<string> actualTransactions = chainblock
                .GetAllReceiversWithTransactionStatus(wantedStatus)
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }


        // GetAllOrderedByAmountDescendingThenById
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnEmptyCollectionWhenNoTransactions()
        {
            ICollection<ITransaction> actualTransactions = chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToArray();

            CollectionAssert.IsEmpty(actualTransactions);
        }
        
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnManyTransactionsOrderedByAmountDescending()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(3, TransactionStatus.Successfull, "Lissa", "Bob", 700),
                new Transaction(4, TransactionStatus.Successfull, "John", "Johnny", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            ICollection<ITransaction> expectedTransactions = transactionsToAppend
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();
            ICollection<ITransaction> actualTransactions = chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }
        
        // same amount => order by id
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnManyTransactionsOrderedByAmountDescendingThenByIdIfSameAmount()
        {
            ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
            {
                testTransaction,
                new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 100),
                new Transaction(4, TransactionStatus.Successfull, "John", "Johnny", 500),
                new Transaction(3, TransactionStatus.Successfull, "Lissa", "Bob", 500)
            };

            foreach (ITransaction transaction in transactionsToAppend)
            {
                chainblock.Add(transaction);
            }

            ICollection<ITransaction> expectedTransactions = transactionsToAppend
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToArray();
            ICollection<ITransaction> actualTransactions = chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }
    }
}
