using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningJWT.Models;

namespace LearningJWT.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> UserExist(string email);
    }
}