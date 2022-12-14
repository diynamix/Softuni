namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = i + ". " + lines[i];
            }
            File.WriteAllLines(outputFilePath, lines);
        }

        //public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        //{
        //    using (StreamReader reader = new StreamReader(inputFilePath))
        //    {
        //        using (StreamWriter writer = new StreamWriter(outputFilePath))
        //        {
        //            int lineNumber = 1;
        //            while (!reader.EndOfStream)
        //            {
        //                writer.WriteLine($"{lineNumber++}. {reader.ReadLine()}");
        //            }
        //        }
        //    }
        //}
    }
}