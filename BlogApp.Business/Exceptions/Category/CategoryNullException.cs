using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Category
{
    public class CategoryNullException : Exception
    {
        public CategoryNullException() : base("Category should not be null")
        {
            
        }
        public CategoryNullException(string message) : base(message)
        {

        }
       
    }
}
