using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningJWT.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public UserRegisterDto()
        {
            CreationDate = DateTime.Now;
        }
    }
}