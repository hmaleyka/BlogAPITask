using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Helpers;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IWebHostEnvironment _env;

        public CategoryService(ICategoryRepository repo , IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }
        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();

            return await categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            var category = await _repo.GetByIdAsync(id);
            if(category==null) throw new CategoryNullException();
            return category;
        }
        public async Task<Category> Create(CategoryCreateDto createcategorydto)
        {
            if (createcategorydto == null) throw new CategoryNullException();
            if (!createcategorydto.Logo.CheckType("image/"))
            {
                throw new Exception("its type should be image");
            }
            if (!createcategorydto.Logo.CheckLong(2097152))
            {
                throw new Exception("Its size should be less than 3 mb");
            }
            Category category = new Category()
            {
                Name = createcategorydto.Name,
                LogoUrl = createcategorydto.Logo.Upload(_env.WebRootPath , @"\Upload\Category\")

            };
            await _repo.Create(category);
            await _repo.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(int id, CategoryUpdateDto updatecategorydto)
        {
            Category category = await _repo.GetByIdAsync(id);
            if (category == null) throw new CategoryNullException();
            category.Name = updatecategorydto.Name;
            category.LogoUrl = updatecategorydto.Logo.UpdateFile(category.LogoUrl,_env.WebRootPath, @"\Upload\Category\");
            //category.Id= updatecategorydto.Id;
             _repo.Update(category);
            await _repo.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) throw new CategoryNullException();
            _repo.Delete(category);
            await _repo.SaveChangesAsync();
            return category;
        }
    }
}
