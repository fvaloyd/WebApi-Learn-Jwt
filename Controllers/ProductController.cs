using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningJWT.Dtos;
using LearningJWT.Models;
using LearningJWT.Repository;
using LearningJWT.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningJWT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productDtos = await _repo.GetAllAsync();
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id == 0)BadRequest("Invalid id");
            
            var productDto = await _repo.GetByIdDtoAsync(id);
            
            if(productDto == null)NotFound("Product not found");
            
            return Ok(productDto);
        }
        
        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var productDto = await _repo.GetByNameAsync(name);
            
            if(productDto == null)NotFound("Product not found");

            return Ok(productDto);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDto productDto)
        {
            var productToCreate = _mapper.Map<Product>(productDto);

            _repo.Add(productToCreate);
            
            if(await _repo.SaveAllAsync()) return Ok(productToCreate);
            
            return BadRequest("Can't create the product");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductDto productDto)
        {
            if(id != productDto.Id) return NotFound("Not a equals ids");

            var productToUpdate = await _repo.GetByIdAsync(id);

            _mapper.Map(productDto, productToUpdate);
            
            if(await _repo.SaveAllAsync()) return Ok(id); 

            return BadRequest("no se guardo");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)BadRequest("Invalid id");

            var productdtoToDelete = await _repo.GetByIdAsync(id);
            var productToDelete = _mapper.Map<Product>(productdtoToDelete);
            
            if(productToDelete != null)_repo.Delete(productToDelete);

            if(!await _repo.SaveAllAsync())NoContent();
            
            return Ok(id);
        }
    }
}