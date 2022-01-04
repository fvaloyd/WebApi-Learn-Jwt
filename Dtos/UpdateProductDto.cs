using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningJWT.Dtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}