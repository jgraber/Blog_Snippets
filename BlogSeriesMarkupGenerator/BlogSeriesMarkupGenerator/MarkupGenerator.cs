using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSeriesMarkupGenerator
{
    public class MarkupGenerator
    {
        public string Generate(string seriesName, List<Post> posts)
        {
            var explanationText = $"This post is part of the {seriesName} series. You can find the other parts here:";
            
            var builder = new StringBuilder();

            for (int markAsCurrentPost = 1; markAsCurrentPost <= posts.Count; markAsCurrentPost++)
            {
                PrintToCForSeries(posts, builder, explanationText, markAsCurrentPost);
                builder.Append(Environment.NewLine);
                builder.Append(Environment.NewLine);
                builder.Append(Environment.NewLine);
            }

            return $@"{builder.ToString()}"; 
        }

        private void PrintToCForSeries(List<Post> posts, StringBuilder builder, string explanationText, int markAsCurrentPost)
        {
            builder.Append(explanationText);
            builder.Append(Environment.NewLine);
            builder.Append("<ul>");
            builder.Append(Environment.NewLine);

            int i = 0;
            foreach (var post in posts)
            {
                i++;
                builder.Append("  <li>");
                if (i == markAsCurrentPost)
                {
                    builder.Append(FormatCurrentLink(post, i));
                }
                else
                {
                    builder.Append(FormatOtherLinksInSeries(post, i));
                }

                builder.Append("</li>");
                builder.Append(Environment.NewLine);
            }

            builder.Append("</ul>");
            builder.Append(Environment.NewLine);
        }

        public string FormatCurrentLink(Post post, int currentNumber)
        {
            return $"<strong>Part {currentNumber}: {post.Text}</strong>";
        }

        public string FormatOtherLinksInSeries(Post post, int currentNumber)
        {
            return $"<a href=\"{post.Url}\">Part {currentNumber}: {post.Text}</a>";
        }
    }
}