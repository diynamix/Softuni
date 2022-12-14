namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader reader1 = new StreamReader(firstInputFilePath);
            StreamReader reader2 = new StreamReader(secondInputFilePath);
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                while (true)
                {
                    if (!reader1.EndOfStream)
                    {
                        string line1 = reader1.ReadLine();
                        writer.WriteLine(line1);
                    }
                    if (!reader2.EndOfStream)
                    {
                        string line2 = reader2.ReadLine();
                        writer.WriteLine(line2);
                    }
                    if (reader1.EndOfStream && reader2.EndOfStream)
                    {
                        break;
                    }
                }
            }

            reader1.Close();
            reader2.Close();
        }
    }
}