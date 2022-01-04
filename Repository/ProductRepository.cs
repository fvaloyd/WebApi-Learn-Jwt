using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningJWT.Data;
using LearningJWT.Dtos;
using LearningJWT.Models;
using LearningJWT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearningJWT.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToListAsync();
        }

        public async Task<ProductDto> GetByIdDtoAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id); 
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id); 
            if(product != null) return product;

            return null;
        }

        public async Task<ProductDto> GetByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}