﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public  record CategoryUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }

    public class CategoryUpdateValidation: AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(c => c.Name)
               .NotNull()
               .NotEmpty()
               .WithMessage("Name should not be empty")
               .MinimumLength(3).WithMessage("Name should have at least 3 characters.")
               .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
            RuleFor(c => c.Logo)
                .NotNull()
                .WithMessage("Tt should not be empty");
        }
    }


}
