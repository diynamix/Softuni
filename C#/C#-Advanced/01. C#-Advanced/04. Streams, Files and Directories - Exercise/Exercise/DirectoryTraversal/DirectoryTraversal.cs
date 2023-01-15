namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new SortedDictionary<string, List<FileInfo>>();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                string fileExtension = fileInfo.Extension;

                if (!extensionsFiles.ContainsKey(fileExtension))
                {
                    extensionsFiles.Add(fileExtension, new List<FileInfo>());
                }

                extensionsFiles[fileExtension].Add(fileInfo);
            }

            var orderedExtensionsFiles = extensionsFiles.OrderByDescending(ef => ef.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var extensionFiles in orderedExtensionsFiles)
            {
                sb.AppendLine(extensionFiles.Key);

                var orderedFiles = extensionFiles.Value.OrderByDescending(f => f.Length);

                foreach (var file in orderedFiles)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length/1024}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}