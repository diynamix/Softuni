namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var wordCount = new Dictionary<string, int>();

            string[] words = File.ReadAllText(wordsFilePath).ToLower().Split();

            foreach (string word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount[word] = 0;
                }
            }

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                Regex splitPattern = new Regex(@"[^a-zA-Z]");
                int lineNumber = 1;
                while (!reader.EndOfStream)
                {
                    string[] text = splitPattern.Split(reader.ReadLine().ToLower()).Where(x => x != String.Empty).ToArray();
                    foreach (string word in text)
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine(word.Key + " - " + word.Value);
                }
            }
        }
    }
}