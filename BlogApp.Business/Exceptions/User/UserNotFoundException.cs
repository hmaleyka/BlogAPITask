using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.User
{
	public  class UserNotFoundException : Exception
	{
		public UserNotFoundException() : base("user/email or password is incorrect")
		{
		}

		public UserNotFoundException(string? message) : base(message)
		{
		}
	}
}
