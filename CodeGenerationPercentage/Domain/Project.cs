namespace CodeGenerationPercentage.Domain
{
    public class Project
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string Bereich()
        {
            if (Name.EndsWith("Test") || Name.EndsWith("Tests") || Name.EndsWith("BDD") || Name.EndsWith("Integration") | Name.EndsWith("Akzeptanzpruefung"))
            {
                return "Qualitaet";
            }

            if (Name.Equals("eLog2.Web"))
            {
                return "Basis";
            }

            if (Name.Contains("Wartung") || Name.Contains("Navision") || Name.Contains("Migration") || Name.Contains("Hangfire") || Name.Contains("Param"))
            {
                return "Helfer";
            }

            if (Name.Contains("."))
            {
                return Name.Split(".")[1];
            }

            return Name;
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