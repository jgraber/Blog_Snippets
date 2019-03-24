using System;
using System.Collections.Generic;
using System.IO;

namespace BlogSeriesMarkupGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MarkupGenerator();
            var title = "NAME";
            var posts = new List<Post>();
            posts.Add(new Post() { Text = "", Url = "" });
            //posts.Add(new Post() { Text = "", Url = "" });
            
            var generatedToC = generator.Generate(title, posts);
            File.WriteAllText(title.Replace(" ", "_")+".txt", generatedToC);
        }
    }
}
