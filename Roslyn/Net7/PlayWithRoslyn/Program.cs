using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System.Reflection.Metadata;
using System.Text;
using Document = Microsoft.CodeAnalysis.Document;

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

            CreatePythonCode(solution);
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
            var names = new Dictionary<Guid, string>();
            foreach (var project in solution.Projects)
            {
                names[project.Id.Id] = project.Name;
            }

            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Project '{project}' depends on:");

                foreach (var reference in project.AllProjectReferences)
                {
                    Console.WriteLine($"\t- {names[reference.ProjectId.Id]}");
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
                    var root = await GetRootNode(document);
                    var interfaces = FilterNodes<InterfaceDeclarationSyntax>(root);
                    
                    if (interfaces.Count > 0)
                    {
                        Console.WriteLine($"Interfaces in {project.Name}:");
                        foreach (var unit in interfaces)
                        {
                            Console.WriteLine(
                                $" - [{unit.Identifier.Text} - {unit.Keyword}]");

                            ShowMethods(root);
                        }
                    }
                }
            }

            Console.WriteLine("\n==========================================\n");
        }

        private static async Task<SyntaxNode> GetRootNode(Document document)
        {
            var root = await document.GetSyntaxTreeAsync()
                .Result?.GetRootAsync()!;
            return root;
        }

        private static List<T> FilterNodes<T>(SyntaxNode root)
        {
            List<T> interfaces = root.DescendantNodes().OfType<T>().ToList();
            return interfaces;
        }

        private static void ShowMethods(SyntaxNode root)
        {
            var nodes = root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>().ToList();
            if (nodes.Count > 0)
            {
                foreach (var method in nodes)
                {
                    Console.WriteLine($"   * {method.Identifier}()");
                }
            }
        }

        private static async Task ListClasses(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                Console.WriteLine($"Classes in {project.Name}:");
                foreach (var document in project.Documents)
                {
                    var root = await GetRootNode(document);
                    var classes = FilterNodes<ClassDeclarationSyntax>(root);
                    
                    if (classes.Count > 0)
                    {
                        foreach (var unit in classes)
                        {
                            Console.WriteLine(
                                $" - [{unit.Identifier.Text} - {unit.Keyword}]");

                            ShowMethods(root);
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
                foreach (var document in project.Documents)
                {
                    var root = await GetRootNode(document);
                    var enums = FilterNodes<EnumDeclarationSyntax>(root);
                    
                    if (enums.Count > 0)
                    {
                        Console.WriteLine($"Enums in {project.Name}:");

                        foreach (var unit in enums)
                        {
                            Console.WriteLine(
                                $" - [{unit.Identifier.Text} - {unit.EnumKeyword}]");

                            foreach (var member in unit.Members)
                            {
                                Console.WriteLine($"   * {member}");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n==========================================\n");
        }

        private static void CreatePythonCode(Solution solution)
        {
            var python = new StringBuilder();
            python.AppendLine("import networkx as nx\n");
            python.AppendLine("G = nx.DiGraph()");

            var names = new Dictionary<Guid, string>();
            foreach (var project in solution.Projects)
            {
                names[project.Id.Id] = project.Name;
                python.AppendLine($"G.add_node('{project.Name}')");
            }

            foreach (var project in solution.Projects)
            {
                foreach (var reference in project.AllProjectReferences)
                {
                    python.AppendLine($"G.add_edge('{project.Name}', '{names[reference.ProjectId.Id]}')");
                }
            }

            python.AppendLine("\nprint(f'Nodes: {G.number_of_nodes()}')");
            python.AppendLine("print(f'Edged: {G.number_of_edges()}')");

            File.WriteAllText("project_graph.py", python.ToString());

            Console.WriteLine("Python file project_graph.py generated");
        }
    }
}