namespace Telephony.IO
{
    using System;
    using System.IO;

    using Interfaces;

    public class FileReader : IReader
    {
        private string filePath;
        private string[] fileAllLines;

        public FileReader(string filePath)
        {
            FilePath = filePath;
            fileAllLines = File.ReadAllLines(filePath);
            RowNumber = 0;
        }

        public string FilePath
        {
            get { return filePath; }
            private set
            {
                if (!Directory.Exists(value))
                {
                    throw new ArgumentException("Invalid file path!");
                }
                filePath = value;
            }
        }

        public int RowNumber { get; private set; }

        public string ReadLine()
        {
            if (RowNumber >= fileAllLines.Length)
            {
                throw new InvalidOperationException("No more content in the file!");
            }

            return fileAllLines[RowNumber++];
        }
    }
}
