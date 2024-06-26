﻿using System;

namespace GenerateCodeFromDb.FromDb.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
    }
}

