using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteSpecial
{
    using System.IO;
    using System.Xml.Serialization;

    using PasteSpecial.Pasted;

    class Program
    {
        static void Main(string[] args)
        {
            var pathToXmlFile = @"Source\CT007.xml";

            CT007 result = new CT007();
            XmlSerializer serializer = new XmlSerializer(typeof(CT007));

            using (FileStream fileStream = new FileStream(pathToXmlFile, FileMode.Open))
            {
                result = (CT007)serializer.Deserialize(fileStream);
            }
        }
    }
}
