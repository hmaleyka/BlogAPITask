using BlogApp.Business.DTOs.BlogDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
	public interface IBlogService 
	{
		Task<ICollection<BlogListItemDto>> GetAllAsync();
		Task<bool> CreateAsync(BlogCreateDto blogDto);
		Task<bool> UpdateAsync (int id, BlogUpdateDto blogUpdateDto);
		Task<BlogDetailDto> GetByIdAsync(int id);
		Task Delete(int id);
	}
}
