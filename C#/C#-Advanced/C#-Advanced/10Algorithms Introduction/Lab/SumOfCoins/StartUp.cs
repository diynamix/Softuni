namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> result = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {result.Sum(c => c.Value)}");

            foreach (var coin in result.OrderByDescending(c => c.Key))
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderBy(c => c).ToList();
            Dictionary<int, int> coinsCount = new Dictionary<int, int>();

            int index = coins.Count - 1;

            // 1, 2, 5, 10, 20, 50
            // 923
            while (index > -1)
            {
                // 50
                int currentCoin = coins[index];

                // 923 / 50 = 18
                int result = targetSum / currentCoin;

                if (result < 1)
                {
                    index--;
                    continue;
                }

                // 50, 18
                coinsCount.Add(currentCoin, result);

                // 923 - 50 * 18
                targetSum -= currentCoin * result;

                if (targetSum == 0)
                {
                    break;
                }
            }

            if (targetSum > 0)
            {
                throw new InvalidOperationException();
            }

            return coinsCount;
        }
    }
}