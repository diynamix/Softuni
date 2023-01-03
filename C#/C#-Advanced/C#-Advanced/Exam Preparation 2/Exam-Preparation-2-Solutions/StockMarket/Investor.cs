using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        private List<Stock> portfolio;

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000
                && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var company = portfolio.Find(c => c.CompanyName == companyName);

            if (company == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < company.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(company);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(c => c.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (!portfolio.Any())
            {
                return null;
            }

            return portfolio.OrderByDescending(c => c.MarketCapitalization).First();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var company in portfolio)
            {
                sb.AppendLine(company.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}