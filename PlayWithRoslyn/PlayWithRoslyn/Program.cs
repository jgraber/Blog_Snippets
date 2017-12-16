using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithRoslyn
{
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.MSBuild;

    class Program
    {
        static void Main(string[] args)
        {
            var solutionPath = @"C:\_Projects\Blog_Snippets\NunitUpgrade\NunitUpgrade\NunitUpgrade.sln";

            var workspace = MSBuildWorkspace.Create();
            var solution =  workspace.OpenSolutionAsync(solutionPath).Result;
            var projects = solution.Projects.ToList();
            foreach (var project in projects)
            {
                Console.WriteLine(project.Name + "\t" + project.AssemblyName + "\t" + project.Id.Id);

                foreach (var reference in project.ProjectReferences)
                {
                    Console.WriteLine("\t * "+reference.ProjectId); 
                    
                }

                foreach (var projectDocument in project.Documents)
                {
                    Console.WriteLine("\t - " + projectDocument.Name);

                    var root = projectDocument.GetSyntaxTreeAsync().Result.GetRoot();

                    var enums = root.DescendantNodes().OfType<EnumDeclarationSyntax>().ToList();
                    foreach (var enumDeclarationSyntax in enums)
                    {
                        Console.WriteLine($"[{enumDeclarationSyntax.Identifier.Text} - {enumDeclarationSyntax.EnumKeyword}");
                    }

                    var interfaces = root.DescendantNodes().OfType<InterfaceDeclarationSyntax>().ToList();
                    foreach (var declarationExpressionSyntax in interfaces)
                    {
                        Console.WriteLine($"[[{declarationExpressionSyntax.Identifier.Text} - {declarationExpressionSyntax.Keyword}");
                    }

                    var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
                    foreach (var classDeclaration in classes)
                    {
                        Console.WriteLine($"[{classDeclaration.Identifier.Text} - {classDeclaration.Keyword} - {String.Join(String.Empty, classDeclaration.Identifier.GetAnnotations().Select(x => x.Data))}]");
                        Console.WriteLine($"{projectDocument.GetSyntaxTreeAsync()}");
                    }

                    var nodes = root.DescendantNodes()
                        .OfType<MethodDeclarationSyntax>().ToList();
                    foreach (var method in nodes)
                    {
                        Console.WriteLine("\t\t - " + method.Identifier);
                    }
                    

   
                }

                
            }
        }

    }
}
