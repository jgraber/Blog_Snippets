namespace PackagesConfigReader.BusinessLogic
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Finder
    {
        public List<FileInfo> Search(string searchPath)
        {
            DirectoryInfo di = new DirectoryInfo(searchPath);

            string searchPattern = "packages.config";

            ICollection<FileInfo> matchingFileInfos = di.GetFiles(searchPattern, SearchOption.AllDirectories)
                .Select(x => x)
                .ToList();
            return matchingFileInfos.ToList();
        }

        public List<NuGetPackage> GetPackages(List<FileInfo> fileList)
        {
            var packagesUsed = new List<NuGetPackage>();
            XmlSerializer serializer = new XmlSerializer(typeof(packages));

            foreach (var packageFile in fileList)
            {
                StreamReader reader = new StreamReader(packageFile.FullName);
                var packages = (packages)serializer.Deserialize(reader);
                reader.Close();

                foreach (var p in packages.package)
                {
                    var nuGetPackage = packagesUsed.FirstOrDefault(x => x.Name == p.id);

                    if (nuGetPackage == null)
                    {
                        var newPackage = new NuGetPackage(){Name = p.id, Occurrences = 1};
                        packagesUsed.Add(newPackage);
                    }
                    else
                    {
                        nuGetPackage.Occurrences += 1;
                    }
                }
            }
            
            return packagesUsed;
        }
    }
}