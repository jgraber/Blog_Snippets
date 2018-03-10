using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackagesConfigReader
{
    using PackagesConfigReader.BusinessLogic;

    class Program
    {
        static void Main(string[] args)
        {
            var startPath = args[0];

            var finder = new Finder();
            var packageFiles = finder.Search(startPath);
            var packages = finder.GetPackages(packageFiles);

            var orderedPackages = packages.OrderByDescending(x => x.Occurrences);

            foreach (var package in orderedPackages)
            {
                Console.WriteLine($"{package.Name}, {package.Occurrences}");
            }
        }
    }
}
