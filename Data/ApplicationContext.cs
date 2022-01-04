using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningJWT.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}