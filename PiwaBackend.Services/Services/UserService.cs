using PiwaBackend.Data.Models;
using PiwaBackend.Repository.Interfaces;
using PiwaBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwaBackend.Services.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _userRepository;

		public UserService(IRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}
		public ServiceResult<object> GetUserName(int userId)
		{
			var user = _userRepository.GetBy(u => u.Id == userId);
			if (user == null)
			{
				return new ServiceResult<object>("User doesn't exist");
			}
			return new ServiceResult<object>(new { FirstName = user.FirstName, LastName = user.LastName });
		}
	}
}
