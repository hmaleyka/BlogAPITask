﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Common
{
    public class NotFoundException<T>: Exception, IBaseException where T : class
    {
        public string ErrorMessage { get; }
        public int StatusCode => StatusCodes.Status404NotFound;
        public NotFoundException() 
        {
            ErrorMessage = typeof(T).Name + "Not Found";
        }

        public NotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
        

    }
}
