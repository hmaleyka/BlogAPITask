using AutoMapper;
using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.DTOs.BlogDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
	public class BlogService : IBlogService
	{
		private readonly IMapper _mapper;
		private readonly IBlogRepository _repo;
		private readonly IHttpContextAccessor _context;
		private readonly UserManager<AppUser> _userManager;
		private string userId;
		public BlogService(IMapper mapper , IBlogRepository repo , IHttpContextAccessor context
			,UserManager<AppUser> userManager)
		{
			_mapper = mapper;
			_repo = repo;
			_context = context;
			_userManager = userManager;
			userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}

		public Task<bool> CreateAsync(BlogCreateDto blogDto)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<BlogListItemDto>> GetAllAsync()
		{
		    var dto = new List<BlogListItemDto>();
			string[] includes = { "AppUser", "BlogCategory", "BlogCategory.Category" };
			var blogs = await _repo.GetAllAsync(includes: includes);
			var categories = new List<Category>();
			foreach (var item in blogs)
			{
				categories.Clear();
				foreach (var cat in item.blogCategories)
				{
					categories.Add(cat.category);
				}
				var dtoItem = _mapper.Map<BlogListItemDto>(blogs);
				dtoItem.Categories = _mapper.Map<IEnumerable<CategoryListItemDto>>(categories);
				dtoItem.User = _mapper.Map<AuthorDto>(item.AppUser);
				dto.Add(dtoItem);
			}
			//var user = await _userManager.FindByNameAsync(userId);
			return dto;
		}


		public Task<BlogDetailDto> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
