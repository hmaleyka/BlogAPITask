using AutoMapper;
using BlogApp.Business.DTOs.BlogDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
	public class BlogMapProfile : Profile
	{
        public BlogMapProfile()
        {
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<Blog, BlogListItemDto>();
            CreateMap<Blog, BlogListItemDto>().ReverseMap();

        }
    }
}
