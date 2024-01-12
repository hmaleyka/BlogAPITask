using AutoMapper;
using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.DTOs.BlogDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
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
        private readonly ICategoryRepository _categoryRepository;
        private string userId;
		public BlogService(IMapper mapper , IBlogRepository repo , IHttpContextAccessor context
			,UserManager<AppUser> userManager , ICategoryRepository categoryRepository)
		{
			_mapper = mapper;
			_repo = repo;
			_context = context;
			_userManager = userManager;
            _categoryRepository = categoryRepository;
            userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}

		public async Task<bool> CreateAsync(BlogCreateDto blogDto)
		{
			if(userId == null) throw new ArgumentNullException();
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null) throw new UserNotFoundException();
			Blog blog = _mapper.Map<Blog>(blogDto);
			blog.AppUserId = userId;
			List<BlogCategory> blogCategories = new();
			foreach (var id in blogDto.CategoriesIds)
			{
				var category = await _categoryRepository.GetByIdAsync(id);
				if (category == null) continue;
				blogCategories.Add(new BlogCategory()
				{
					blog = blog,
					category = category
				});
			}
			blog.blogCategories = blogCategories;
			await _repo.Create(blog);
		    await _repo.SaveChangesAsync();
			return false;
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<BlogListItemDto>> GetAllAsync()
		{
		    var dto = new List<BlogListItemDto>();
			string[] includes = { "AppUser","blogCategories" ,  "BlogCategory.category" };
			var blogs = await _repo.GetAllAsync(includes: includes);
			var categories = new List<Category>();
			foreach (var item in blogs)
			{
				categories.Clear();
				foreach (var cat in item.blogCategories)
				{
					categories.Add(cat.category);
				}
				var dtoItem = _mapper.Map<BlogListItemDto>(item);
				dtoItem.Categories = _mapper.Map<IEnumerable<CategoryListItemDto>>(categories);
				dtoItem.User = _mapper.Map<AuthorDto>(item.AppUser);
				dto.Add(dtoItem);
			}
			//var user = await _userManager.FindByNameAsync(userId);
			return dto;
		}


		public async Task<BlogDetailDto> GetByIdAsync(int id)
		{
			if (id <= 0) throw new NegativeIdException();
			string[] includes = { "AppUser", "BlogCategory", "BlogCategory.Category" };
            Blog blog = await _repo.GetByIdAsync(id);
			if(blog==null) throw new NotFoundException<Blog>();
			blog.ViewerCount++;
			BlogDetailDto blogdetail =_mapper.Map<BlogDetailDto>(blog);
			List<CategoryListItemDto> categorylist = new List<CategoryListItemDto>();
			foreach (var item in blog.blogCategories)
			{
				var categoryDto= _mapper.Map<CategoryListItemDto>(item.category);
			    categorylist.Add(categoryDto);
			}
			blogdetail.categories = categorylist;
			blogdetail.User = _mapper.Map<AuthorDto>(blog.AppUser);
			await _repo.SaveChangesAsync();
			return blogdetail;
		
		}

        public async Task<bool> UpdateAsync(int id , BlogUpdateDto blogUpdateDto)
        {
            if (userId == null) throw new ArgumentNullException();
			Blog blogs = await _repo.GetByIdAsync(id);
			blogs.Title = blogUpdateDto.Title;
			blogs.Description = blogUpdateDto.Description;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new UserNotFoundException();
            Blog blog = _mapper.Map<Blog>(blogUpdateDto);
            var existingBlog = await _repo.GetByIdAsync(blogUpdateDto.Id);
			if (existingBlog == null) return false;
            List<BlogCategory> updatedCategories = new List<BlogCategory>();
            foreach (var categoryId in blogUpdateDto.CategoriesIds)
            {
                var category = await _categoryRepository.GetByIdAsync(categoryId);

                if (category != null)
                {
                    updatedCategories.Add(new BlogCategory
                    {
                        blog = existingBlog,
                        category = category
                    });
                }              
            }
            existingBlog.blogCategories = updatedCategories;
            _repo.Update(existingBlog);
            try
            {
                await _repo.SaveChangesAsync();
				return true;
            }
            catch (Exception)
            {
                return false; 
            }


        }
    }
}
