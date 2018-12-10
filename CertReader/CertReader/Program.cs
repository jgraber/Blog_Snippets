namespace CertReader
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    public class Program
    {
        public static void Main(string[] args)
        {
            var str = "test.com";

            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.OpenExistingOnly);

            var collection = store.Certificates.Find(X509FindType.FindBySubjectName, str, false);

            store.Close();

            if (collection.Count == 1)
            {
                var myCert = new X509Certificate2(collection[0]);
                Console.WriteLine($"Certificate '{myCert.FriendlyName}' is found");
                Console.WriteLine($"Has private key? {myCert.HasPrivateKey}");
                Console.WriteLine($"Private key: {myCert.PrivateKey.ToXmlString(true)}");
            }
            else
            {
                Console.WriteLine("Certificate {0} is not found!!", str);
            }


            Console.ReadKey();
        }
    }
}