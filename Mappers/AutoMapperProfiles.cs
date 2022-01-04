using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningJWT.Dtos;
using LearningJWT.Models;

namespace LearningJWT.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Product AM
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductDto>().ReverseMap();

            // User AM
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}