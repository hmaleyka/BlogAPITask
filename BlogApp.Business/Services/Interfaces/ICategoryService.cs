using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
       Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> Create(CategoryCreateDto category);
        Task<Category> Update(int id, CategoryUpdateDto category);

        Task<Category> Delete(int id);
    }
}
