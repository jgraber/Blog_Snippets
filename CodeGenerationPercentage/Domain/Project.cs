namespace CodeGenerationPercentage.Domain
{
    public class Project
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string Bereich()
        {
            return Name.Split(".")[1];
        }

        public string Typ()
        {
            if (Name.EndsWith("Test") || Name.EndsWith("BDD") || Name.EndsWith("Integration"))
            {
                return "Qualitaet";
            }
            else
            {
                return "Domain";
            }
        }
    }
}