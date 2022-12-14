namespace Chainblock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;

        public Chainblock()
        {
            transactions = new HashSet<ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx))
            {
                throw new InvalidOperationException("You cannot add already existing transaction");
            }

            if (Contains(tx.Id))
            {
                throw new InvalidOperationException("You cannot add transaction with already existing Id");
            }

            transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            try
            {
                ITransaction transaction = GetById(id);

                transaction.Status = newStatus;
            }
            catch(InvalidOperationException)
            {
                throw new ArgumentException("You cannot change the status of non existing transaction!");
            }
        }

        public bool Contains(ITransaction tx) => Contains(tx.Id);

        public bool Contains(int id) => transactions.Any(tx => tx.Id == id);

        // TODO...
        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById() => transactions
            .OrderByDescending(tx => tx.Amount)
            .ThenBy(tx => tx.Id)
            .ToArray();

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            ICollection<string> sendersWithGivenStatus = transactions
                .Where(tx => tx.Status == status)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.To)
                .ToArray();

            if (sendersWithGivenStatus.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided status!");
            }

            return sendersWithGivenStatus;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            ICollection<string> sendersWithGivenStatus = transactions
                .Where(tx => tx.Status == status)
                .OrderBy(tx => tx.Amount)
                .Select(tx => tx.From)
                .ToArray();

            if (sendersWithGivenStatus.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided status!");
            }

            return sendersWithGivenStatus;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = transactions
                .FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction with provided id does not exist!");
            }

            return transaction;
        }

        // TODO...
        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        // TODO...
        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        // TODO...
        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        // TODO...
        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            ICollection<ITransaction> transactionsWanted = transactions
                .Where(tx => tx.Status == status)
                .OrderByDescending(tx => tx.Amount)
                .ToArray();

            if (transactionsWanted.Count == 0)
            {
                throw new InvalidOperationException("There are no transactions with the provided status!");
            }

            return transactionsWanted;
        }

        // TODO...
        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        // TODO...
        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            try
            {
                ITransaction transaction = GetById(id);

                transactions.Remove(transaction);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("You cannot remove non existing transaction!");
            }
        }

        // TODO...
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
