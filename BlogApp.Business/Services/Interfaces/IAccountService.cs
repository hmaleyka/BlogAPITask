using BlogApp.Business.DTOs.AcountDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public  interface IAccountService
    {
        Task Register(AccountCreateDto accountdto);
        void Login(AccountLoginDto logindto);
    }
}
