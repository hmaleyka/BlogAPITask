using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Configurations
{
	public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
	{
		public void Configure(EntityTypeBuilder<BlogCategory> builder)
		{
			builder.HasOne(bc => bc.category)
				.WithMany(c => c.blogCategories)
				.HasForeignKey(bc => bc.CategoryId);

			builder.HasOne(bc => bc.blog)
				.WithMany(b => b.blogCategories)
				.HasForeignKey(bc => bc.BlogId);

		}
	}
}
