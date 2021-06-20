using System.IO;

namespace CodeGenerationPercentage.Tests
{
    public class CodeFile
    {
        public string FileName { get; set; }

        public string Namespace { get; set; }

        public int NumberOfLines { get; set; }

        public bool Generated { get; set; }
        public string Project { get; set; }

        public override string ToString()
        {
            return $"{Project} {Namespace.Replace(Path.DirectorySeparatorChar, '.')}.{FileName}: [{Generated}] {NumberOfLines}";
        }
    }
}