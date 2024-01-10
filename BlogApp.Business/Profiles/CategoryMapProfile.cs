using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
	public class CategoryMapProfile : Profile
	{
        public CategoryMapProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryListItemDto, Category>();
            CreateMap<CategoryListItemDto, Category>().ReverseMap();
        }
    }
}
