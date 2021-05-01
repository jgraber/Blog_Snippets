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

            var codeFiles = GeneratedFilesCalculator(projectRoot, fileExtension, generatedFilesExtension, out var stats);

            Assert.AreEqual(7, codeFiles.Count);
            Assert.AreEqual(57.15, stats.PercentageGeneratedLines(), 0.01); // 7*12=84 4*12=48 100/84*48 = 
            Assert.AreEqual(57.15, stats.PercentageGeneratedFiles(), 0.01);
        }

        private List<CodeFile> GeneratedFilesCalculator(string projectRoot, string fileExtension, string generatedFilesExtension,
            out OverallStats stats)
        {
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


            stats = CalculatePercentage(codeFiles);
            return codeFiles;
        }

        private OverallStats CalculatePercentage(List<CodeFile> codeFiles)
        {
            var stats = new OverallStats();

            foreach (var codeFile in codeFiles)
            {
                stats.totalLines += codeFile.NumberOfLines;
                stats.totalFiles++;

                if (codeFile.Generated)
                {
                    stats.generatedLines += codeFile.NumberOfLines;
                    stats.totalGeneratedFiles++;
                }
                else
                {
                    stats.handWrittenLines += codeFile.NumberOfLines;
                    stats.totalhandWrittenFiles++;
                }
            }

            return stats;
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

    public class OverallStats
    {
        public long totalLines { get; set; }

        public long generatedLines { get; set; }

        public long handWrittenLines { get; set; }

        public long totalFiles { get; set; }

        public long totalGeneratedFiles { get; set; }

        public long totalhandWrittenFiles { get; set; }

        public double PercentageGeneratedLines()
        {
            return 100.0 / this.totalLines * this.generatedLines;
        }

        public double PercentageGeneratedFiles()
        {
            return 100.0 / this.totalFiles * this.totalGeneratedFiles;
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