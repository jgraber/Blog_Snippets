using System.Collections.Generic;
using Xunit;
using BlogSeriesMarkupGenerator;

namespace BlogSeriesMarkupGenerator.Tests
{
    public class MarkupGeneratorTests
    {
        [Fact]
        public void Generate_with2Posts_creates2ToC()
        {
            var testee = new MarkupGenerator();
            var posts = new List<Post>();
            posts.Add(new Post(){Text = "Extraction", Url = "https://demo.ch/start"});
            posts.Add(new Post() { Text = "Transformation", Url = "https://demo.ch/end" });

            var expected = @"This post is part of the Minimal Example series. You can find the other parts here:
<ul>
  <li><strong>Part 1: Extraction</strong></li>
  <li><a href=""https://demo.ch/end"">Part 2: Transformation</a></li>
</ul>



This post is part of the Minimal Example series. You can find the other parts here:
<ul>
  <li><a href=""https://demo.ch/start"">Part 1: Extraction</a></li>
  <li><strong>Part 2: Transformation</strong></li>
</ul>



";

            var result = testee.Generate("Minimal Example", posts);

            Assert.Equal(expected, result);
        }
    }
}
