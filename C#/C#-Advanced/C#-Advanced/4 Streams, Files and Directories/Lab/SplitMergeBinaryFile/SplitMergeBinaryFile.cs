namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                byte[] firstBuffer = new byte[(sourceFile.Length + 1) / 2];
                sourceFile.Read(firstBuffer, 0, firstBuffer.Length);
                using (FileStream firstHalf = new FileStream(partOneFilePath, FileMode.Create))
                {
                    firstHalf.Write(firstBuffer, 0, firstBuffer.Length);
                }

                byte[] secondBuffer = new byte[sourceFile.Length / 2];
                sourceFile.Read(secondBuffer, 0, secondBuffer.Length);
                using (FileStream secondHalf = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    secondHalf.Write(secondBuffer, 0, secondBuffer.Length);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] firstBuffer = null;
                using (FileStream firstFile = new FileStream(partOneFilePath, FileMode.Open))
                {
                    firstBuffer = new byte[firstFile.Length];
                    joinedFile.Write(firstBuffer);
                }

                byte[] secondBuffer = null;
                using (FileStream secondFile = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    secondBuffer = new byte[secondFile.Length];
                    joinedFile.Write(secondBuffer, 0, secondBuffer.Length);
                }
            }
        }
    }
}