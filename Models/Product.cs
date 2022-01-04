using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningJWT.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }

    }
}