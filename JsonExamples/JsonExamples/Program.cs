using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace JsonExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new BlogPost
            {
                Id = 1,
                State = State.Published,
                PublishedAt = DateTime.Now,
                Title = "How to use JSON.net"
            };
            post.Tags.Add("C#");
            post.Tags.Add("JSON");

            string output = JsonConvert.SerializeObject(post, Formatting.Indented);

            Console.WriteLine(output);

            var deserializedPost = JsonConvert.DeserializeObject<BlogPost>(output);

            var post2 = new BlogPost
            {
                Id = 2,
                State = State.Draft,
                PublishedAt = null,
                Title = "More use cases for JSON.net"
            };

            var post3 = new BlogPost
            {
                Id = 3,
                State = State.Deleted,
                PublishedAt = DateTime.Now.AddMonths(-6),
                Title = "How to use ...."
            };

            var listOfPosts = new List<BlogPost>();
            listOfPosts.Add(post);
            listOfPosts.Add(post2);
            listOfPosts.Add(post3);

            var jsonList = JsonConvert.SerializeObject(listOfPosts, Formatting.Indented);

            Console.WriteLine(jsonList);


            //var deserializedListWrong = JsonConvert.DeserializeObject<BlogPost>(jsonList);


            var deserializedList = JsonConvert.DeserializeObject<List<BlogPost>>(jsonList);

            var defaultSerialisation = JsonConvert.SerializeObject(post2);
            Console.WriteLine(defaultSerialisation);


            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var postWithCamelCase = JsonConvert.SerializeObject(post3, settings);
            Console.WriteLine(postWithCamelCase);

           
            var comment = new Comment(){FullName = "JSON Demo", State = State.Published, Text = "Hello world!"};
            var jsonFromProperties = JsonConvert.SerializeObject(comment, Formatting.Indented);
            Console.WriteLine(jsonFromProperties);
        }
    }

    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? PublishedAt { get; set; }
        public State State { get; set; }
        public List<string> Tags { get; set; }

        public BlogPost()
        {
            Tags = new List<string>();
        }
    }

    public enum State
    {
        Draft = 1,
        Published = 2,
        Deleted = 3
    }

    public class Comment
    {
        public Guid Id { get; set; }

        [JsonPropertyAttribute("User")]
        public string FullName { get; set; }
        
        [JsonIgnore]
        public string Text { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public State State { get; set; }

        public Comment()
        {
            Id = Guid.NewGuid();
        }
    }
}
