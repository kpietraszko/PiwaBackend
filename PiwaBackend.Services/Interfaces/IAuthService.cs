using PiwaBackend.Data.DTOs;
using PiwaBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Services.Interfaces
{
	public interface IAuthService
	{
		ServiceResult<User> Register(RegisterDTO model);
		ServiceResult<TokenDTO> Login(LoginDTO model);
	}
}
