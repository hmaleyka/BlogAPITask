using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register ([FromForm] AccountCreateDto accountDto)
        {
            await _service.Register(accountDto);
            return Ok(new { Message = "User registered successfully" });
        }
    
    }
}
