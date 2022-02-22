using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeGenerationPercentage.Domain
{
    public class FileSystemWalker
    {
        public List<Project> FindProjects(string projectRoot)
        {
            string[] entries = Directory.GetFileSystemEntries(projectRoot, "*.csproj", SearchOption.AllDirectories);

            var projects = new List<Project>();

            foreach (var entry in entries)
            {
                var fileInfo = new FileInfo(entry);

                if (fileInfo.FullName.Contains("Sandbox"))
                {
                    continue;
                }
                
                projects.Add(
                    new Project()
                    {
                        Name = fileInfo.Name.Substring(0, fileInfo.Name.Length - 7),
                        Path = fileInfo.DirectoryName

                    });

                //Console.WriteLine($"{fileInfo.Directory} : {fileInfo.Name}");
                //Console.WriteLine(fileInfo.Name);
            }

            return projects;
        }

        public List<CodeFile> GeneratedFilesCalculator(string projectRoot, string projectName, string fileExtension, string generatedFilesExtension,
            out OverallStats stats)
        {
            var codeFiles = new List<CodeFile>();

            var allowedExtensions = new[] { ".cs", ".g.cs", ".sql", ".cshtml", ".feature", ".resx", ".ts", ".js", ".scss", ".html", ".json", ".razor" };

            string[] entries = Directory.GetFileSystemEntries(projectRoot, "*.*", SearchOption.AllDirectories);
            foreach (var entry in entries)
            {
                var fileInfo = new FileInfo(entry);

                if (fileInfo.DirectoryName.Contains("wwwroot") || fileInfo.DirectoryName.Contains("Scripts"))
                {
                    continue;
                }

                if (allowedExtensions.Any(x => fileInfo.Extension.ToLower() == x))
                {
                    var codeFile = new CodeFile();
                    codeFile.FileName = fileInfo.Name;
                    try
                    {
                        var contentAll = File.ReadAllLines(entry);
                        var content = contentAll.Where(x => string.IsNullOrWhiteSpace(x) == false);
                        codeFile.NumberOfLines = content.Count();
                    }
                    catch (Exception e)
                    {
                        codeFile.NumberOfLines = 0;
                        //Console.WriteLine(e);
                    }
                    
                    codeFile.Namespace = Path.GetRelativePath(projectRoot, fileInfo.DirectoryName);
                    codeFile.Generated = fileInfo.Name.Contains(".g.");
                    codeFile.Project = projectName;
                    //Console.WriteLine(codeFile);
                    codeFiles.Add(codeFile);
                }
            }


            stats = CalculatePercentage(codeFiles);
            return codeFiles;
        }

        public OverallStats CalculatePercentage(List<CodeFile> codeFiles)
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
    }
}