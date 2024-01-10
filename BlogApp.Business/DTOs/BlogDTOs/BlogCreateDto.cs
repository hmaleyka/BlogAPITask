using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BlogDTOs
{
	public class BlogCreateDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile? file { get; set; }
		public IEnumerable<int> CategoriesIds { get; set; }
	}
	public class BlogCreateDtoValidation: AbstractValidator<BlogCreateDto>
	{
		public BlogCreateDtoValidation() 
		{
			RuleFor(x => x.Title).NotEmpty()
				.WithMessage("It shouldn't be empty")
				.MaximumLength(73);
			RuleFor(x => x.Description).NotEmpty();
			RuleFor(x => x.CategoriesIds).NotEmpty()
					.Must(b => checkEmpty(b))
					.WithMessage("Category should be entered");
		}	
		public bool checkEmpty(IEnumerable<int> ids)
		{
			foreach (var id in ids)
			{
				if(id<=0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
