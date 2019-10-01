using System;
using System.IO;

namespace TempFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempFilePath = CreateTemporaryFile();
            MarkAsTemporary(tempFilePath);
            WorkWithTemporaryFile(tempFilePath);
            DeleteTemporaryFile(tempFilePath);
        }

        private static string CreateTemporaryFile()
        {
            var tempFilePath = Path.GetTempFileName();
            // something like C:\Users\USER\AppData\Local\Temp\tmp35C7.tmp

            Console.WriteLine(tempFilePath);
            
            return tempFilePath;
        }

        private static void MarkAsTemporary(string tempFilePath)
        {
            // can give a performance boost - but measure first!
            FileInfo fileInfo = new FileInfo(tempFilePath);
            fileInfo.Attributes = FileAttributes.Temporary;
        }

        private static void WorkWithTemporaryFile(string tempFilePath)
        {
            using (StreamWriter outputFile = new StreamWriter(tempFilePath))
            {
                outputFile.WriteLine("This is a test");
            }
            
            using (StreamReader inputFile = new StreamReader(tempFilePath))
            {
                String line = inputFile.ReadToEnd();
                Console.WriteLine(line);
            }
        }

        private static void DeleteTemporaryFile(string tempFilePath)
        {
            //File.Delete(tempFilePath);

            var file = new FileInfo(tempFilePath);
            file.Delete();

            if (file.Exists)
            {
                Console.WriteLine("File still exists!");
            }
            else
            {
                Console.WriteLine($"File {tempFilePath} is deleted");
            }
        }
    }
}
