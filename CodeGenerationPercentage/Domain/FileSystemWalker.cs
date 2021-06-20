using System.Collections.Generic;
using System.IO;

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

            string[] entries = Directory.GetFileSystemEntries(projectRoot, fileExtension, SearchOption.AllDirectories);
            foreach (var entry in entries)
            {
                var fileInfo = new FileInfo(entry);

                var codeFile = new CodeFile();
                codeFile.FileName = fileInfo.Name;
                codeFile.NumberOfLines = File.ReadAllLines(entry).Length;
                codeFile.Namespace = Path.GetRelativePath(projectRoot, fileInfo.DirectoryName);
                codeFile.Generated = entry.EndsWith(generatedFilesExtension);
                codeFile.Project = projectName;
                //Console.WriteLine(codeFile);
                codeFiles.Add(codeFile);
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