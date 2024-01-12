using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BlogDTOs
{
	public class BlogDetailDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string? CoverImageUrl { get; set; }
		public int ViewerCount { get; set; }
		public AuthorDto User {  get; set; }
		public IEnumerable<CategoryListItemDto> categories { get; set; }
	}
}
