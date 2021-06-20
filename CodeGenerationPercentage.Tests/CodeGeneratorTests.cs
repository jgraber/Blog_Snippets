using System;
using System.IO;
using CodeGenerationPercentage.Domain;
using NUnit.Framework;

namespace CodeGenerationPercentage.Tests
{
    public class CodeGeneratorTests
    {
        private readonly FileSystemWalker _fileSystemWalker = new FileSystemWalker();

        public FileSystemWalker FileSystemWalker
        {
            get { return _fileSystemWalker; }
        }

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

            var codeFiles = _fileSystemWalker.GeneratedFilesCalculator(projectRoot, "X", fileExtension, generatedFilesExtension, out var stats);

            Assert.AreEqual(7, codeFiles.Count);
            Assert.AreEqual(57.15, stats.PercentageGeneratedLines(), 0.01); // 7*12=84 4*12=48 100/84*48 = 
            Assert.AreEqual(57.15, stats.PercentageGeneratedFiles(), 0.01);
        }

        [Test]
        public void CombineAsTest()
        {
            var projectRoot = TestContext.CurrentContext.TestDirectory + @"\DemoProject";
            var projects = _fileSystemWalker.FindProjects(projectRoot);

            var fileExtension = "*.cs";
            var generatedFilesExtension = ".g.cs";

            foreach (var project in projects)
            {
                var codeFiles = _fileSystemWalker.GeneratedFilesCalculator(project.Path, project.Name, fileExtension, generatedFilesExtension, out var stats);
                Assert.AreEqual(7, codeFiles.Count);
                Assert.AreEqual(57.15, stats.PercentageGeneratedLines(), 0.01); // 7*12=84 4*12=48 100/84*48 = 
                Assert.AreEqual(57.15, stats.PercentageGeneratedFiles(), 0.01);
                Assert.AreEqual(48, stats.generatedLines);
                Assert.AreEqual(36, stats.handWrittenLines);
                Assert.AreEqual(84, stats.totalLines);
                Console.WriteLine($"{project.Name} {stats.totalLines} {stats.handWrittenLines} {stats.generatedLines} {String.Format("{0:0.00}", stats.PercentageGeneratedLines())}");
            }
        }

        [Test]
        public void CombineAsExample()
        {
            var projectRoot = TestContext.CurrentContext.TestDirectory + @"\DemoProject";
            var projects = _fileSystemWalker.FindProjects(projectRoot);

            var fileExtension = "*.cs";
            var generatedFilesExtension = ".g.cs";

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name}");
            }
            Console.WriteLine();

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name},X,{project.Bereich()},{project.Typ()} ");
            }

            Console.WriteLine();

            foreach (var project in projects)
            {
                var codeFiles = _fileSystemWalker.GeneratedFilesCalculator(project.Path, project.Name, fileExtension, generatedFilesExtension, out var stats);
                //Assert.AreEqual(7, codeFiles.Count);
                //Assert.AreEqual(57.15, stats.PercentageGeneratedLines(), 0.01); // 7*12=84 4*12=48 100/84*48 = 
                //Assert.AreEqual(57.15, stats.PercentageGeneratedFiles(), 0.01);
                //Assert.AreEqual(48, stats.generatedLines);
                //Assert.AreEqual(36, stats.handWrittenLines);
                //Assert.AreEqual(84, stats.totalLines);

                Console.WriteLine($"{project.Name} {stats.totalLines} {stats.handWrittenLines} {stats.generatedLines} {String.Format("{0:0.00}", stats.PercentageGeneratedLines())}");
            }
        }

        [Test]
        public void Finde_alle_ProjetDateien()
        {
            //var projectRoot = @"D:\_DEV\Apps\__eLog2Stat";
            var projectRoot = TestContext.CurrentContext.TestDirectory + @"\DemoProject";


            var projects = _fileSystemWalker.FindProjects(projectRoot);

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Path} => {project.Name}");
            }
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
}