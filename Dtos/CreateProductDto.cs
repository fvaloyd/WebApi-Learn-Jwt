using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningJWT.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CreationDate { get; set; } 
        public CreateProductDto()
        {
            CreationDate = DateTime.Now;
        }
    }
}