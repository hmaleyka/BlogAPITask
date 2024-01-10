using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.ExternalService.Interfaces;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _tokenservice;
		public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenservice)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenservice = tokenservice;
		}

		private readonly SignInManager<AppUser> _signInManager;

        public async Task Register(AccountCreateDto accountdto)
        {
            AppUser appUser = new AppUser()
            {
                Name = accountdto.Name,
                Surname = accountdto.Surname,
                Email = accountdto.Email,
                UserName = accountdto.Username
            };
             
           var result= await  _userManager.CreateAsync(appUser, accountdto.Password);
            if(result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return;
                }
            
            }
            //if (!result.Succeeded)
            //{
            //    
            //    throw new Exception();
            //}



        }

		public async Task<TokenResponseDto> Login(AccountLoginDto logindto)
		{
			var user = await _userManager.FindByEmailAsync(logindto.UserNameOrEmail) ?? await _userManager.FindByNameAsync(logindto.UserNameOrEmail);
			if (user == null) throw new UserNotFoundException();
			if (!await _userManager.CheckPasswordAsync(user, logindto.Password)) throw new UserNotFoundException();

			return _tokenservice.CreateToken(user);

		}
	}
}
