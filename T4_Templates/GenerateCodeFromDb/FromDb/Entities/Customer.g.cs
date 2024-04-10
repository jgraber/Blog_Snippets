using System;

namespace GenerateCodeFromDb.FromDb.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string StreetAndNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
    }
}

