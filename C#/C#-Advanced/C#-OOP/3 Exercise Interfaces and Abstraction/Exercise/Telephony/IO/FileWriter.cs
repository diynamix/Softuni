namespace Telephony.IO
{
    using System.IO;

    using Interfaces;

    public class FileWriter : IWriter
    {
        // TODO... Implement the class -> DONE!!!

        private string filePath;

        public FileWriter(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath
        {
            get { return filePath; }
            private set
            {
                //if (!Directory.Exists(value))
                //{
                //    throw new ArgumentException("Invalid file path!");
                //}
                filePath = value;
            }
        }

        public void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(text);
            }
        }

        public void WriteLine(string text)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(text);
            }
        }
    }
}
