using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System.Reflection.Metadata;

namespace PlayWithRoslyn
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string solutionPath = @"..\..\..\..\..\..\NUnit\NunitUpgrade\NunitUpgrade.sln";

			// Register MSBuild
            MSBuildLocator.RegisterDefaults();

            var workspace = MSBuildWorkspace.Create();
            var solution = await workspace.OpenSolutionAsync(solutionPath);

            ListProjects(solution);
            ListProjectDependencies(solution);
            ListProjectDependenciesImproved(solution);
            await ListInterfaces(solution);
            await ListClasses(solution);
            await ListEnums(solution);

            var projectDict = new Dictionary<Guid, string>();
            foreach (var project in solution.Projects)
            {
                projectDict[project.Id.Id] = project.Name;
            }

            foreach (var project in solution.Projects)
            {
                Console.WriteLine("\n\n==========================================");
                Console.WriteLine($"Project {project.Name} [{project.Id.Id}]");
                Console.WriteLine("==========================================");

                Console.WriteLine("Project dependencies:");
                foreach (var projectReference in project.AllProjectReferences)
                {
                    Console.WriteLine($"\t- {projectDict[projectReference.ProjectId.Id]}");
                }

                foreach (var document in project.Documents)
                {
                    var root = await document.GetSyntaxTreeAsync().Result?.GetRootAsync()!;

                    var interfaces = root.DescendantNodes().OfType<InterfaceDeclarationSyntax>().ToList();
                    if (interfaces.Count > 0)
                    {
                        Console.WriteLine("Interfaces:");
                        foreach (var declarationExpressionSyntax in interfaces)
                        {
                            Console.WriteLine(
                                $"\t[{declarationExpressionSyntax.Identifier.Text} - {declarationExpressionSyntax.Keyword}]");
                        }
                    }

                    var enums = root.DescendantNodes().OfType<EnumDeclarationSyntax>().ToList();
                    if (enums.Count > 0)
                    {
                        Console.WriteLine("Enums:");
                        foreach (var enumDeclarationSyntax in enums)
                        {
                            Console.WriteLine(
                                $"\t[{enumDeclarationSyntax.Identifier.Text} - {enumDeclarationSyntax.EnumKeyword}]");
                        }
                    }

                    

                    var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
                    if (classes.Count > 0)
                    {
                        Console.WriteLine("Classes:");
                        foreach (var classDeclaration in classes)
                        {
                            Console.WriteLine(
                                $"\t[{classDeclaration.Identifier.Text} - {classDeclaration.Keyword}]");
                        }
                    }

                    var nodes = root.DescendantNodes()
                        .OfType<MethodDeclarationSyntax>().ToList();
                    if (nodes.Count > 0)
                    {
                        Console.WriteLine("Methods:");
                        foreach (var method in nodes)
                        {
                            Console.WriteLine("\t - " + method.Identifier + "()");
                        }
                    }
                }
            }
        }

        private static void ListProjects(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Project {project.Name} [{project.Id.Id}]\n");
            }

            Console.WriteLine("\n==========================================\n");
        }

        private static void ListProjectDependencies(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Project '{project}' depends on:");

                foreach (var projectReference in project.AllProjectReferences)
                {
                    Console.WriteLine($"\t- {projectReference.ProjectId.Id}");
                }
            }

            Console.WriteLine("\n==========================================\n");
        }

        private static void ListProjectDependenciesImproved(Solution solution)
        {
            var projectDict = new Dictionary<Guid, string>();
            foreach (var project in solution.Projects)
            {
                projectDict[project.Id.Id] = project.Name;
            }

            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Project '{project}' depends on:");

                foreach (var projectReference in project.AllProjectReferences)
                {
                    Console.WriteLine($"\t- {projectDict[projectReference.ProjectId.Id]}");
                }
            }

            Console.WriteLine("\n==========================================\n");
        }

        private static async Task ListInterfaces(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                foreach (var document in project.Documents)
                {
                    var root = await document.GetSyntaxTreeAsync().Result?.GetRootAsync()!;
                    var interfaces = root.DescendantNodes().OfType<InterfaceDeclarationSyntax>().ToList();
                    
                    if (interfaces.Count > 0)
                    {
                        Console.WriteLine($"Interfaces in {project.Name}:");
                        foreach (var declarationExpressionSyntax in interfaces)
                        {
                            Console.WriteLine(
                                $"\t[{declarationExpressionSyntax.Identifier.Text} - {declarationExpressionSyntax.Keyword}]");

                            var nodes = root.DescendantNodes()
                                .OfType<MethodDeclarationSyntax>().ToList();
                            if (nodes.Count > 0)
                            {
                                foreach (var method in nodes)
                                {
                                    Console.WriteLine("\t - " + method.Identifier + "()");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n==========================================\n");
        }
        private static async Task ListClasses(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Classes in {project.Name}:");
                foreach (var document in project.Documents)
                {
                    var root = await document.GetSyntaxTreeAsync().Result?.GetRootAsync()!;

                    var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
                    if (classes.Count > 0)
                    {
                        foreach (var classDeclaration in classes)
                        {
                            Console.WriteLine(
                                $"\t[{classDeclaration.Identifier.Text} - {classDeclaration.Keyword}]");

                            var nodes = root.DescendantNodes()
                                .OfType<MethodDeclarationSyntax>().ToList();
                            if (nodes.Count > 0)
                            {
                                foreach (var method in nodes)
                                {
                                    Console.WriteLine("\t - " + method.Identifier + "()");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n==========================================\n");
        }

        private static async Task ListEnums(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Enums in {project.Name}:");
                foreach (var document in project.Documents)
                {
                    var root = await document.GetSyntaxTreeAsync().Result?.GetRootAsync()!;

                    var enums = root.DescendantNodes().OfType<EnumDeclarationSyntax>().ToList();
                    if (enums.Count > 0)
                    {
                        foreach (var enumDeclarationSyntax in enums)
                        {
                            Console.WriteLine(
                                $"\t[{enumDeclarationSyntax.Identifier.Text} - {enumDeclarationSyntax.EnumKeyword}]");
                        }
                    }
                }
            }

            Console.WriteLine("\n==========================================\n");
        }



    }
}