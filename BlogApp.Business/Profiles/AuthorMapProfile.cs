using AutoMapper;
using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
	public class AuthorMapProfile : Profile
	{
        public AuthorMapProfile()
        {
            CreateMap<AuthorDto, AppUser>();
        }
    }
}
