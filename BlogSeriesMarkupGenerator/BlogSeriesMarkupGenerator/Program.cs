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
            var title = "Protecting Passwords";
            var posts = new List<Post>();
            posts.Add(new Post() { Text = "Do Something Good for You: Use a Password Manager", Url = "https://improveandrepeat.com/2018/10/do-something-good-for-you-use-a-password-manager/" });
            posts.Add(new Post() { Text = "KeePass – the Cloud-Free Solution to Manage Your Passwords", Url = "https://improveandrepeat.com/2018/10/keepass-the-cloud-free-solution-to-manage-your-passwords/" });
            posts.Add(new Post() { Text = "Use BCrypt to Save Password (Hashes)", Url = "https://improveandrepeat.com/2018/10/use-bcrypt-to-save-password-hashes/" });
            posts.Add(new Post() { Text = "How to Find out If Your User’s Password Is in a Data Breach", Url = "https://improveandrepeat.com/2018/10/how-to-find-out-if-your-users-password-is-in-a-data-breach/" });
            //posts.Add(new Post() { Text = "Transformation", Url = "https://demo.ch/end" });
            
            var generatedToC = generator.Generate(title, posts);
            File.WriteAllText(title.Replace(" ", "_")+".txt", generatedToC);
        }
    }
}
