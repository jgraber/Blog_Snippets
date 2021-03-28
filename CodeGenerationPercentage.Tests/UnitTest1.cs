using System;
using System.Collections.Generic;
using System.IO;

using NUnit.Framework;

namespace CodeGenerationPercentage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Spike_OverallPercentage()
        {
            var projectRoot = TestContext.CurrentContext.TestDirectory + @"\DemoProject";
            var fileExtension = "*.cs";
            var generatedFilesExtension = ".g.cs";

            var codeFiles = new List<CodeFile>();

            string[] entries = Directory.GetFileSystemEntries(projectRoot, fileExtension, SearchOption.AllDirectories);
            foreach (var entry in entries)
            {
                var fileInfo = new FileInfo(entry);

                var codeFile = new CodeFile();
                codeFile.FileName = fileInfo.Name;
                codeFile.NumberOfLines = File.ReadAllLines(entry).Length;
                codeFile.Namespace = Path.GetRelativePath(projectRoot, fileInfo.DirectoryName);
                codeFile.Generated = entry.EndsWith(generatedFilesExtension);
                Console.WriteLine(codeFile);
                codeFiles.Add(codeFile);
            }

            var percentage = CalculatePercentage(codeFiles);

            Assert.AreEqual(7, codeFiles.Count);
            Assert.AreEqual(57.15, percentage, 0.01); // 7*12=84 4*12=48 100/84*48 = 
        }

        private double CalculatePercentage(List<CodeFile> codeFiles)
        {
            long totalLines = 0;
            long generatedLines = 0;
            long handWrittenLines = 0;
            
            long totalFiles = 0;
            long totalGeneratedFiles = 0;
            long totalhandWrittenFiles = 0;

            foreach (var codeFile in codeFiles)
            {
                totalLines += codeFile.NumberOfLines;
                totalFiles++;

                if (codeFile.Generated)
                {
                    generatedLines += codeFile.NumberOfLines;
                    totalGeneratedFiles++;
                }
                else
                {
                    handWrittenLines += codeFile.NumberOfLines;
                    totalhandWrittenFiles++;
                }
            }

            return 100.0 / totalLines * generatedLines;
        }

        [Test]
        public void RelativePath()
        {
            var fullPath =
                @"C:\_Projects\Blog_Snippets\CodeGenerationPercentage.Tests\bin\Debug\net5.0\DemoProject\modulB";
            var startPoint = @"C:\_Projects\Blog_Snippets\CodeGenerationPercentage.Tests\bin\Debug\net5.0\DemoProject";

            var relativePath = Path.GetRelativePath(startPoint, fullPath);

            Assert.AreEqual("modulB", relativePath);
        }
    }

    public class CodeFile
    {
        public string FileName { get; set; }

        public string Namespace { get; set; }

        public int NumberOfLines { get; set; }

        public bool Generated { get; set; }

        public override string ToString()
        {
            return $"{Namespace.Replace(Path.DirectorySeparatorChar, '.')}.{FileName}: [{Generated}] {NumberOfLines}";
        }
    }
}