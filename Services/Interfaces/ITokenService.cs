using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningJWT.Models;

namespace LearningJWT.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user); 
    }
}