using BlogApp.Business.DTOs.BlogDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsController : ControllerBase
	{
		private readonly IBlogService _service;

		public BlogsController(IBlogService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(_service.GetAllAsync());
		}
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
		{
			return Ok(await _service.GetByIdAsync(id));
		}

        [HttpPost]
		public async Task<IActionResult> Post([FromForm] BlogCreateDto dto)
		{
			try
			{
				if (await _service.CreateAsync(dto)) return Ok();
				return BadRequest();
			}
			catch (Exception )
			{
				throw;
			}
		}
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateDto blogUpdateDto)
        {
			try
			{
                if(await _service.UpdateAsync(id, blogUpdateDto)) return Ok();
				return BadRequest();
            }
			catch
			{
				throw;
			}
            
        }




    }
}
