using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Services.Interfaces
{
	public interface IUserService
	{
		ServiceResult<object> GetUserName(int userId);
	}
}
