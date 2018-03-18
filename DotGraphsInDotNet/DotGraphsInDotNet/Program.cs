using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotGraphsInDotNet
{
    using System.Collections.Immutable;
    using System.IO;
    using System.Threading;

    using Shields.GraphViz.Components;
    using Shields.GraphViz.Models;
    using Shields.GraphViz.Services;

    class Program
    {
        static void Main()
        {
            MainAsync(null).Wait();
        }

        public static async Task MainAsync(string[] args)
        {
            var node = NodeStatement.For("k");
            node = node.Set(new Id("shape"), "box")
                .Set(new Id("style"),"filled")
                .Set(new Id("color"), ".7 .3 1.0");
            

            Graph graph = Graph.Directed
                .Add(EdgeStatement.For("a", "b"))
                .Add(EdgeStatement.For("a", "c"))
                .Add(node)
                .Add(new NodeStatement("b", node.Attributes))
                .Add(EdgeStatement.For("c", "k"));

            var graphVizBin = @"C:\Program Files (x86)\Graphviz2.38\bin";
            IRenderer renderer = new Renderer(graphVizBin);
            using (Stream file = File.Create("graph.svg"))
            {
                await renderer.RunAsync(
                    graph, file,
                    RendererLayouts.Dot,
                    RendererFormats.Svg,
                    CancellationToken.None);
            }
        }
    }
}
