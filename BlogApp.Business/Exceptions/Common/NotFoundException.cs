using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Common
{
    public class NotFoundException<T>: Exception where T : class
    {
        public NotFoundException() :base(typeof(T).Name+ " Not Found")
        {
            
        }

        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
