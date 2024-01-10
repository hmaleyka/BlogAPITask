using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BlogDTOs
{
	public class BlogListItemDto
	{
		public string Title { get; set; }
		public AuthorDto User { get; set; }
	    public IEnumerable<CategoryListItemDto> Categories { get; set; }
	}
}
