using System;
using System.Collections.Generic;
using System.IO;
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
                Console.WriteLine(args.Length);
                throw new Exception("Pfad und Namen nötig!");
            }

            var ordner = args[0];
            var name = args[1];
            Console.WriteLine($"Ordner: {ordner}");
            Console.WriteLine($"Name: {name}");

            var walker = new FileSystemWalker();

            var projects = walker.FindProjects(ordner);

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
            var lines = new List<string>();

            foreach (var project in projects)
            {
                var codeFiles = walker.GeneratedFilesCalculator(project.Path, project.Name, fileExtension, generatedFilesExtension, out var stats);
                //Assert.AreEqual(7, codeFiles.Count);
                //Assert.AreEqual(57.15, stats.PercentageGeneratedLines(), 0.01); // 7*12=84 4*12=48 100/84*48 = 
                //Assert.AreEqual(57.15, stats.PercentageGeneratedFiles(), 0.01);
                //Assert.AreEqual(48, stats.generatedLines);
                //Assert.AreEqual(36, stats.handWrittenLines);
                //Assert.AreEqual(84, stats.totalLines);

                var line = $"{project.Name};{name};{stats.totalLines};";
                lines.Add(line);
                Console.WriteLine(line);
            }

            var datei = $@"c:\Temp\{name}.csv";
            File.WriteAllLinesAsync(datei, lines);
            Console.WriteLine($"Datei geschrieben: {datei}");
        }
    }
}
