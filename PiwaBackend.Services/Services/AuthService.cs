using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PiwaBackend.Data.DTOs;
using PiwaBackend.Data.Models;
using PiwaBackend.Repository.Interfaces;
using PiwaBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PiwaBackend.Services.Services
{
	public class AuthService : IAuthService
	{
		private readonly IRepository<User> _userRepository;
		private readonly IConfiguration _config;
		private readonly IPasswordHasher<User> _passwordHasher;

		public AuthService(IRepository<User> userRepository, IConfiguration config, IPasswordHasher<User> passwordHasher)
		{
			_userRepository = userRepository;
			_config = config;
			_passwordHasher = passwordHasher;
		}

		public ServiceResult<User> Register(RegisterDTO userData)
		{
			if (_userRepository.Exists(u => u.EmailAddress == userData.EmailAddress))
			{
				return new ServiceResult<User>("Email already used");
			}
			var hashedPassword = _passwordHasher.HashPassword(null, userData.Password);
			var newUser = new User { EmailAddress = userData.EmailAddress, FirstName = userData.FirstName, LastName = userData.LastName, PasswordHash = hashedPassword};

			_userRepository.Insert(newUser);
			return new ServiceResult<User>(newUser);
		}

		public ServiceResult<TokenDTO> Login(LoginDTO loginData)
		{
			var user = Authenticate(loginData);
			if (user != null)
			{
				var tokenString = BuildToken(user);
				return new ServiceResult<TokenDTO>(new TokenDTO(tokenString));
			}
			return new ServiceResult<TokenDTO>("Incorrect login data");
		}
		private User Authenticate(LoginDTO loginData)
		{
			User user = null;
			var emailMatchingUser = _userRepository.GetBy(u => u.EmailAddress == loginData.Email);
			if (emailMatchingUser != null)
			{
				var hashVerificationResult = _passwordHasher.VerifyHashedPassword(null, emailMatchingUser.PasswordHash, loginData.Password);
				if (hashVerificationResult == PasswordVerificationResult.Success)
					user = emailMatchingUser;
			}
			return user;
		}
		private string BuildToken(User user)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Issuer"],
				expires: DateTime.Now.AddMinutes(_config.GetValue<int>("Jwt:TTL", 30)), //czas z configu, jesli w configu brak to 30min
				signingCredentials: creds,
				claims: new Claim[] { new Claim(ClaimTypes.Sid, user.Id.ToString()) }
				);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
