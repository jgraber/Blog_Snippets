using System;
using System.Collections.Generic;
using CodeGenerationPercentage.Domain;

namespace CodeGenerationPercentage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generated Code Percentage Calculator");

            if (args.Length != 2)
            {
                throw new Exception("Pfad und Namen nötig!");
            }

            var ordner = args[0];
            var name = args[1];
            Console.WriteLine($"Ordner: {ordner}");
            Console.WriteLine($"Name: {name}");

            var projects = new List<Project>();// FindProjects(projectRoot);

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
                //var codeFiles = GeneratedFilesCalculator(project.Path, project.Name, fileExtension, generatedFilesExtension, out var stats);
                //Assert.AreEqual(7, codeFiles.Count);
                //Assert.AreEqual(57.15, stats.PercentageGeneratedLines(), 0.01); // 7*12=84 4*12=48 100/84*48 = 
                //Assert.AreEqual(57.15, stats.PercentageGeneratedFiles(), 0.01);
                //Assert.AreEqual(48, stats.generatedLines);
                //Assert.AreEqual(36, stats.handWrittenLines);
                //Assert.AreEqual(84, stats.totalLines);

                //Console.WriteLine($"{project.Name} {stats.totalLines} {stats.handWrittenLines} {stats.generatedLines} {String.Format("{0:0.00}", stats.PercentageGeneratedLines())}");
            }
        }
    }
}
