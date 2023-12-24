using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public class CategoryListItemDto
    {
        public int CategoryId { get; set; }
        public Category category { get; set; }  
        public Task<IQueryable<Category>> categories { get; set; }
    }
}
