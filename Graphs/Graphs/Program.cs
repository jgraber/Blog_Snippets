using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    using System.IO;

    using Graphviz4Net.Dot;
    using Graphviz4Net.Dot.AntlrParser;
    using Graphviz4Net.Graphs;

    public static class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<Person>();
            var a = new Person(){Name = "AAAAA"};
            var b = new Person() { Name = "BB BB" };

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddEdge(new Edge<Person>(a, b){Label = "reports to", Attributes = { new KeyValuePair<string, string>("color", "0.650 0.200 1.000"), new KeyValuePair<string, string>("size", "15") } });

            Console.WriteLine(graph.ToString());

            var writer = new StringWriter();
            new GraphToDotConverter().Convert(writer, graph, new AttributesProvider());
            var result = writer.GetStringBuilder().ToString().Trim();

            Console.WriteLine(result);
            
        }
    }

    public class AttributesProvider : IAttributesProvider
    {
        public IDictionary<string, string> GetVertexAttributes(object vertex)
        {
            return new Dictionary<string, string>();
        }
    }
}
