using BlogApp.DAL.Repositories.Implementations;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL
{
	public static class RepositoryRegistration
	{
		public static void AddRepository(this IServiceCollection service)
		{
			service.AddScoped<IBlogRepository, BlogRepository>();
			service.AddScoped<ICategoryRepository, CategoryRepository>();
			
		}
	}
}
