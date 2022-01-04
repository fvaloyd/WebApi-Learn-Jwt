using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningJWT.Dtos;
using LearningJWT.Models;

namespace LearningJWT.Repository.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdDtoAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<ProductDto> GetByNameAsync(string name);
        Task<bool> SaveAllAsync();
    }
}