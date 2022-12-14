namespace Chainblock.Models
{
    using System;

    using Contracts;

    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;

        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id should be a positive number!");
                }
                id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get
            {
                return from;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Receiver name cannot be null or white space string!");
                }
                from = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name cannot be null or white space string!");
                }
                to = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount should be a positive number!");
                }
                amount = value;
            }
        }
    }
}
