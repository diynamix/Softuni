namespace Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> validCards = new List<Card>();

            string[][] cards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray())
                .ToArray();

            foreach (string[] card in cards)
            {
                try
                {
                    validCards.Add(new Card(card[0], card[1]));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(String.Join(" ", validCards));
        }
    }

    public class Card
    {
        private string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private Dictionary<string, string> suits = new Dictionary<string, string>()
        {
            { "S", "\u2660" },
            { "H", "\u2665" },
            { "D", "\u2666" },
            { "C", "\u2663" }
        };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            set
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get { return suit; }
            set
            {
                if (!suits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString()
        {
            return $"[{Face}{suits[Suit]}]";
        }
    }
}
