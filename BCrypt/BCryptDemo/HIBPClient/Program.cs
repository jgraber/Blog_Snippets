using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIBPClient
{
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Cryptography;

    using Newtonsoft.Json;

    public class Program
    {
        static HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# App ImproveAndRepeat.com");

            try
            {

                HttpResponseMessage response =
                    await client.GetAsync("https://haveibeenpwned.com/api/v2/breachedaccount/jg@jgraber.ch");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var breaches = JsonConvert.DeserializeObject<Breach[]>(json);

                    foreach (var breach in breaches)
                    {
                        Console.WriteLine($"({breach.BreachDate}) {breach.Title}");
                        Console.WriteLine($"Domain: {breach.Domain}");
                        Console.WriteLine($"is Verified: {breach.IsVerified}");

                        Console.WriteLine(new string('-', 50));
                    }
                }


                var hash = Hash("test");
                var first5 = hash.Substring(0, 5);
                var restOfHash = hash.Substring(5);
                Console.WriteLine(first5);

                response = await client.GetAsync($"https://api.pwnedpasswords.com/range/{first5}");
                if (response.IsSuccessStatusCode)
                {
                    var range = await response.Content.ReadAsStringAsync();
                    var lines = range.Split(
                        new[] { Environment.NewLine },
                        StringSplitOptions.None);

                    var directory = new Dictionary<string, int>();

                    foreach (var line in lines)
                    {
                        //Console.WriteLine(line);
                        var parts = line.Split(':');
                        directory[parts[0]] = int.Parse(parts[1]);
                    }

                    if (directory.ContainsKey(restOfHash))
                    {
                        Console.WriteLine($"Your password is used in {directory[restOfHash]} pawned accounts");
                    }
                    else
                    {
                        Console.WriteLine("Your password was not found in pawned accounts");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        public static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public class Breach
        {
            public string Name { get; set; }
            public string Title { get; set; }
            public string Domain { get; set; }
            public string BreachDate { get; set; }
            public DateTime AddedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
            public int PwnCount { get; set; }
            public string Description { get; set; }
            public string LogoType { get; set; }
            public string[] DataClasses { get; set; }
            public bool IsVerified { get; set; }
            public bool IsFabricated { get; set; }
            public bool IsSensitive { get; set; }
            public bool IsRetired { get; set; }
            public bool IsSpamList { get; set; }
        }

    }
}
