using BlogApp.Business.DTOs.AcountDTOs;
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

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private readonly SignInManager<AppUser> _signInManager;
    
        public void Login(AccountLoginDto logindto)
        {
          
        }

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
    }
}
